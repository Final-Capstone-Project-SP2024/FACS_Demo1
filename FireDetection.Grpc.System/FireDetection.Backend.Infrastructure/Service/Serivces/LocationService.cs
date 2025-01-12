﻿using AutoMapper;
using FireDetection.Backend.Domain.DTOs.Request;
using FireDetection.Backend.Domain.DTOs.Response;
using FireDetection.Backend.Domain.DTOs.State;
using FireDetection.Backend.Domain.Entity;
using FireDetection.Backend.Infrastructure.Helpers.ErrorHandler;
using FireDetection.Backend.Infrastructure.Repository.IRepositories;
using FireDetection.Backend.Infrastructure.Service.IServices;
using FireDetection.Backend.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FireDetection.Backend.Infrastructure.Service.Serivces
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;

        public LocationService(IUnitOfWork context, IMapper mapper, IClaimsService claimsService)
        {
            _context = context;
            _mapper = mapper;
            _claimsService = claimsService;
        }

        protected async Task<bool> ChecLocationId(Guid locationId)
        {
            var location = await _context.LocationRepository.GetById(locationId);
            if (location == null)
            {
                return false;
            }
           
            return true;
        }
        public async Task<LocationInformationResponse> AddNewLocation(AddLocationRequest request)
        {

            if (!await checkDuplicateLocationName(request.LocationName))
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Have already this location in system");
            };

            _context.LocationRepository.InsertAsync(_mapper.Map<Location>(request));
            await _context.SaveChangeAsync();

            return _mapper.Map<LocationInformationResponse>(await GetLocationByName(request.LocationName));
        }

        public async Task<bool> DeleteLocation(Guid id)
        {
            if (!await ChecLocationId(id)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this LocationId in system");
            
            Location location = await _context.LocationRepository.GetById(id);
            location.IsDeleted = true;
            await _context.CameraRepository.DeleteCamera(id);
            await _context.SaveChangeAsync();
            return true;
        }


        public async Task<bool> ActiveLocation(Guid id)
        {
            if (!await ChecLocationId(id)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this LocationId in system");
            Location location = await _context.LocationRepository.GetById(id);
            location.IsDeleted = false;
            await _context.CameraRepository.ActiveCamera(id);
            await _context.SaveChangeAsync();
            return true;
        }


        public async Task<IQueryable<LocationGeneralResponse>> GetLocation()
        {
            //? view by role 
            //todo user in manager role 
            IEnumerable<LocationGeneralResponse> data;
            if (_claimsService.GetCurrentUserRole == UserRole.User)
            {

                data = await _context.LocationRepository.GetLocationsByUserRole(_claimsService.GetCurrentUserId);

            }
            else
            {
                data = await _context.LocationRepository.GetLocations();
            }
            //todo user in user role
            var mapper = data.Select(x => _mapper.Map<LocationGeneralResponse>(x));
            return mapper.AsQueryable();
        }

        public async Task<LocationInformationResponse> UpdateLocation(Guid locationId, UpdateLocationRequest request)
        {
            if (!await ChecLocationId(locationId)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this LocationId in system");

            if (!await checkDuplicateLocationName(request.LocationName)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "This name is exist in system");
           
            Location location = await GetLocationByID(locationId);
            location.LocationName = request.LocationName;
            location.LastModified = DateTime.UtcNow;

            _context.LocationRepository.Update(location);
            await _context.SaveChangeAsync();

            return _mapper.Map<LocationInformationResponse>(await _context.LocationRepository.GetById(locationId));
        }

        private async Task<Location> GetLocationByName(string name)
        {
            IQueryable<Location> locations = await _context.LocationRepository.GetAll();

            return locations.FirstOrDefault(x => x.LocationName == name);

        }

        private async Task<Location> GetLocationByID(Guid id)
        {
            IQueryable<Location> locations = await _context.LocationRepository.GetAll();

            return locations.FirstOrDefault(x => x.Id == id);
        }


        private async Task<bool> checkDuplicateLocationName(string locationName)
        {
            IQueryable<Location> locations = await _context.LocationRepository.GetAll();
            if (locations.FirstOrDefault(x => x.LocationName == locationName) is null) return true;

            return false;
        }

        public async Task<LocationInformationResponse> AddStaffToLocation(Guid locationId, AddStaffRequest request)
        {
            int cameraCount = _context.CameraRepository.Where(x => x.LocationID == locationId).Count();
            if (cameraCount == 0) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Add Camera to this Location ");
           
            if (!await ChecLocationId(locationId)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this LocationId in system or have been banned");
            if (await _context.LocationRepository.Where(x => x.Id == locationId && x.IsDeleted == true).FirstOrDefaultAsync() is not null)
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Location have been banned");
            }
            int check = 0;
            List<Guid> duplicateGuid = new List<Guid>();
            foreach (var staff in request.staff)
            {
                if (await CheckDuplicateUserInControlCamera(locationId, staff))
                {
                    check++;
                    duplicateGuid.Add(staff);
                }
                else
                {
                    ControlCamera controlCamera = new ControlCamera()
                    {
                        LocationID = locationId,
                        UserID = staff
                    };
                    _context.ControlCameraRepository.InsertAsync(controlCamera);
                    await _context.SaveChangeAsync();

                };



            }
            if (check > 0)
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, $"Some user has been registered in another location");
            }

            var data = await _context.LocationRepository.GetStaffInLocation(locationId);
            List<Camera> cameras = _context.CameraRepository.Where(x => x.LocationID == locationId).ToList();
            var dataCheck = cameras.Select(x => _mapper.Map<CameraInLocation>(x)).ToList();
            return new LocationInformationResponse()
            {
                CreatedDate = _context.LocationRepository.GetById(locationId).Result.CreatedDate,
                LocationName = _context.LocationRepository.GetById(locationId).Result.LocationName,
                LocationId = locationId,
                Users = data,
                CameraInLocations = dataCheck
            };
        }


        private async Task<bool> CheckDuplicateUserInControlCamera(Guid locationId, Guid userId)
        {
            var user = _context.UserRepository.GetById(userId).Result;
            if (user.Status == UserState.Inactive)
            {
                return false;
            }
            var check = _context.ControlCameraRepository.Where(x => x.UserID == userId && x.LocationID == locationId).Count();
            if (check == 0)
            {
                return false;
            }

            return true;
        }

        public async Task<LocationInformationResponse> GetById(Guid locationId)
        {
            var data = await _context.LocationRepository.GetStaffInLocation(locationId);
            if (data is null) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this locationId");
            List<Camera> cameras = _context.CameraRepository.Where(x => x.LocationID == locationId).ToList();

            return new LocationInformationResponse()
            {
                CreatedDate = _context.LocationRepository.GetById(locationId).Result.CreatedDate,
                LocationName = _context.LocationRepository.GetById(locationId).Result.LocationName,
                LocationId = locationId,
                Users = data,
                CameraInLocations = cameras.Select(camera => _mapper.Map<CameraInLocation>(camera)).ToList(),
                CameraQuantity = _context.CameraRepository.Where(x => x.LocationID == locationId).Count(),
                UserQuantity = _context.ControlCameraRepository.Where(x => x.LocationID == locationId).Count()

            };
        }

        public async Task<LocationInformationResponse> RemoveSecurityInLocation(Guid locationId, AddStaffRequest request)
        {
            if (!await ChecLocationId(locationId)) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, "Not Found this LocationId in system");
            bool checkIsLocation = false;
            //? Check user in location
            foreach (var item in request.staff)
            {
                if (_context.ControlCameraRepository.Where(x => x.LocationID == locationId && x.UserID == item).FirstOrDefault() is not null)
                {
                    _context.ControlCameraRepository.HardDelete(_context.ControlCameraRepository.Where(x => x.LocationID == locationId && x.UserID == item).FirstOrDefault());
                    await _context.SaveChangeAsync();
                }
                else
                {
                    checkIsLocation = true;
                }
            }
            //        if (checkIsLocation) throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, $"Some user didn't register  in this location ");



            var data = await _context.LocationRepository.GetStaffInLocation(locationId);
            var cameras = _context.CameraRepository.Where(x => x.LocationID == locationId).ToList();

            return new LocationInformationResponse()
            {
                CreatedDate = _context.LocationRepository.GetById(locationId).Result.CreatedDate,
                LocationName = _context.LocationRepository.GetById(locationId).Result.LocationName,
                LocationId = locationId,
                Users = data,
                CameraInLocations = cameras.Select(camera => _mapper.Map<CameraInLocation>(camera)).ToList()
            };




        }
    }
}

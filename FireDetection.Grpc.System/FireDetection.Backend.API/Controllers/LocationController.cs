﻿using FireDetection.Backend.Domain.DTOs.Core;
using FireDetection.Backend.Domain.DTOs.Request;
using FireDetection.Backend.Domain.DTOs.Response;
using FireDetection.Backend.Domain.Entity;
using FireDetection.Backend.Infrastructure.Repository.IRepositories;
using FireDetection.Backend.Infrastructure.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FireDetection.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _context;

        public LocationController(ILocationService context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<RestDTO<LocationInformationResponse>>> Add(AddLocationRequest request)
        {
            LocationInformationResponse response = await _context.AddNewLocation(request);
            return new RestDTO<LocationInformationResponse>()
            {
                Message = "Add Location Successfully!",
                Data = response,
                Links = new List<LinkDTO>
                {
                    new LinkDTO(Url.Action("Add","LocationController",response, Request.Scheme)!,"self","Post")
                }
            };


        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<RestDTO<LocationInformationResponse>>> Update(Guid id, AddLocationRequest request)
        {
            LocationInformationResponse response = await _context.UpdateLocation(id, request);

            return new RestDTO<LocationInformationResponse>()
            {
                Message = "Update Location Successfully!",
                Data = response,
                Links = new List<LinkDTO>
                {
                    new LinkDTO(Url.Action("Update","LocationController",response, Request.Scheme)!,"self","Patch")
                }
            };
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<RestDTO<LocationInformationResponse>>> Delete(Guid id)
        {
            await _context.DeleteLocation(id);
            return new RestDTO<LocationInformationResponse>()
            {
                Message = "Delete Location Successfully!",
                Data = null,
                Links = new List<LinkDTO>
                {
                    new LinkDTO(Url.Action("Delete","LocationController",null, Request.Scheme)!,"self","Delete")
                }
            };
        }

        [HttpGet]
        public async Task<ActionResult<RestDTO<IQueryable<Location>>>> Get()
        {
            IQueryable<Location> location = await _context.GetLocation();

            return new RestDTO<IQueryable<Location>>()
            {
                Message = "Update Location Successfully!",
                Data = location,
                Links = new List<LinkDTO>
     {
         new LinkDTO(Url.Action("Update","LocationController",null, Request.Scheme)!,"self","Patch")
     }
            };
        }

    }
}

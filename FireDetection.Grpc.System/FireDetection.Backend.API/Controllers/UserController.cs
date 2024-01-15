﻿using FireDetection.Backend.Domain.DTOs.Core;
using FireDetection.Backend.Domain.DTOs.Request;
using FireDetection.Backend.Domain.DTOs.Response;
using FireDetection.Backend.Infrastructure.Repository.IRepositories;
using FireDetection.Backend.Infrastructure.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal.TypeHandlers;

namespace FireDetection.Backend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<RestDTO<UserInformationResponse>>> Add(CreateUserRequest request)
        {
            UserInformationResponse response = await _userService.CreateUser(request);
            return new RestDTO<UserInformationResponse>()
            {
                Message = "Create User Successfully",
                Data = response,
                Links = new List<LinkDTO> {
                    new LinkDTO(
                    Url.Action(
                        null,
                        "Add New User",
                        request,
                        Request.Scheme)!,
                    "self",
                    "Post")
                }
            };
        }

/*
        [HttpPatch("/{id}")]
        public async Task<ActionResult<RestDTO<UserInformationResponse>>> Update(Guid id, [FromBody] JsonPatchDocument<UpdateUserRequest> request)
        {
            throw new NotImplementedException();
        }*/

        [HttpPost("/active/{id}")]
        public async Task<ActionResult<RestDTO<UserInformationResponse>>> Active(Guid id)
        {
            throw new NotImplementedException();
        }


        [HttpPost("/inactive/{id}")]
        public async Task<ActionResult<RestDTO<UserInformationResponse>>> Inactive(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<RestDTO<UserInformationResponse>>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

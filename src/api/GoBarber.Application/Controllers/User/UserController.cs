using AutoMapper;
using GoBarber.Application.Config;
using GoBarber.Domain.Constants;
using GoBarber.Domain.Entities;
using GoBarber.Domain.Interfaces.Services;
using GoBarber.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;

namespace GoBarber.Application.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;
        private readonly IOptions<AppSettings> appSettings;
        public UserController(IUserService userService, IOptions<AppSettings> app, IMapper mapper)
        {
            _userService = userService;
            appSettings = app;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        //[Authorize(Roles = RoleConstant.Client)]
        public ActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação inválida
            }

            try
            {
                return Ok(_userService.Get());

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public ActionResult Get(Int32 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post([FromBody] UserInput user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                user.Role = RoleConstant.Client;
                user.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
                
                var createdUser = _userService.Insert(user);

                if (createdUser != null)
                {
                    return Ok(createdUser);
                }
                else
                {
                    return BadRequest(createdUser);
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] UserInput user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedUser = _userService.Update(user);

                if (updatedUser != null)
                {
                    return Ok(updatedUser);
                }
                else
                {
                    return BadRequest(updatedUser);
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(Int32 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(_userService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}

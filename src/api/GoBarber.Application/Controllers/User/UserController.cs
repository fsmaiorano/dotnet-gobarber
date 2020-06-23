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
        [Authorize(Roles = RoleConstant.Client)]
        public ActionResult GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação inválida
            }

            try
            {
                return Ok(_userService.SelectAll());

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
        public ActionResult Post([FromBody] UserInput user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userResult = new UserResult();

            try
            {
                user.Role = RoleConstant.Client;

                var userEntity = _mapper.Map<UserInput, UserEntity>(user);

                var createdUser = _userService.Insert(userEntity);

                if (createdUser != null)
                {
                    userResult.User = _mapper.Map<UserEntity, UserDTO>(createdUser);
                    userResult.User.Token = createdUser.Token;
                    userResult.User.Avatar = $"https://api.adorable.io/avatars/{new Random().Next(10000)}";
                    userResult.Success = true;

                    return Ok(userResult);
                }
                else
                {
                    userResult.Success = false;
                    return BadRequest(userResult);
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _userService.Update(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
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

﻿using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;

        public UserController(IUser IUser)
        {
            _IUser = IUser;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers()
        {
            return await Task.FromResult(_IUser.GetUsers());
        }

        [HttpGet("{email}")]
        public IActionResult GetUserByMail(string email) 
        {
            User user = _IUser.FindUserByMail(email);
            if(user != null) 
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public void RegisterUser(User user)
        {
            _IUser.RegisterUser(user);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            _IUser.UpdateUserInfo(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}
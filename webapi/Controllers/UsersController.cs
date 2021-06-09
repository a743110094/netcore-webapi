using demo.Models;
using demo.Models.vo;
using demo.Repository;
using demo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IUserService _userService;
        public UsersController(DemoContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }


        /// <summary>
        /// 获取用户列表： GET: api/Users
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<User>>>> GetUsers([FromQuery]UserListInput input)
        {
            return await _userService.GetUsers(input);
        }

        /// <summary>
        /// 获取用户详情：GET: api/Users/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseData<User>>> GetUser(String id)
        {
            var result = await _userService.GetUserById(id);
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// 修改用户信息：PUT: api/Users/5
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResponseData<bool>>> PutUser(User user)
        {
            return await _userService.UpdateUser(user);
        }

        /// <summary>
        /// 新增用户：POST: api/Users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<bool>>> PostUser(User user)
        {
            return await _userService.CreateUser(user);
        }

        /// <summary>
        /// 批量删除用户： DELETE: api/Users/5
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        public async Task<ActionResult<ResponseData<bool>>> DeleteUser(String ids)
        {
            return await _userService.DeleteUserByIds(ids);
        }


    }
}

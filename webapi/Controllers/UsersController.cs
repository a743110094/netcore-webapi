using demo.Models;
using demo.Models.vo;
using demo.Repository;
using demo.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo.Controllers
{
    [EnableCors("_demoOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IUserService _userService;
        private readonly IUserTokenService _tokenService;
        public UsersController(DemoContext context, IUserService userService, IUserTokenService tokenService)
        {
            _context = context;
            _userService = userService;
            _tokenService = tokenService;
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
        [EnableCors("_demoOrigins")]
        [HttpPost("login")]
        
        public async Task<ActionResult<ResponseData<User>>> Login(LoginInput input)
        {
            if (input == null || string.IsNullOrEmpty(input.LoginName) || string.IsNullOrEmpty(input.Password))
            {
                return new ResponseData<User> { Message="账号或密码不允许为空"};
            }
            var result = await _userService.GetUsers(input);
            List<User> users = (List <User> )result.Data;
            bool userEnable = users.FindIndex(0, u => u.EnableFlag == 0) == -1;
            bool loginSuccess = users.Count > 0 && userEnable;
            int code = loginSuccess ? 200 : 500;
            string msg = loginSuccess ?  "登录成功" : userEnable ? "用户名或密码错误" :  "用户被冻结，无法登录";
            User user = null;
            string token = "";
            if (loginSuccess)
            {

                token = Guid.NewGuid().ToString();
                user = users[0];
                 await _tokenService.CreateOne(new UserToken() { Token=token , UserId = user.Id});
            }
            

            return new ResponseData<User> { Message = msg,Code = code,Total = users.Count ,Data = user };
        }


        /// <summary>
        /// 修改用户信息：PUT: api/Users/5
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResponseData<bool>>> PutUser([FromBody]User user)
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

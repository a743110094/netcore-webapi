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
    public class RoleController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IRoleService _RoleService;
        public RoleController(DemoContext context,IRoleService Roleervice)
        {
            _context = context;
            _RoleService = Roleervice;
        }


        /// <summary>
        /// 获取角色列表： GET: api/Role
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Role>>>> GetMany([FromQuery]BaseListInput input)
        {
            return await _RoleService.GetMany(input);
        }

        /// <summary>
        /// 获取角色详情：GET: api/Role/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseData<Role>>> GetOneById(string id)
        {
            var result = await _RoleService.GetOneById(Int32.Parse(id));
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// 修改角色信息：PUT: api/Role/5
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResponseData<bool>>> UpdateOne(Role Role)
        {
            return await _RoleService.UpdateOne(Role);
        }

        /// <summary>
        /// 新增角色：POST: api/Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<bool>>> CreateOne(Role Role)
        {
            return await _RoleService.CreateOne(Role);
        }

        /// <summary>
        /// 批量删除角色： DELETE: api/Role/5
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        public async Task<ActionResult<ResponseData<bool>>> DeleteOneByIds(String ids)
        {
            return await _RoleService.DeleteOneByIds(ids);
        }


    }
}

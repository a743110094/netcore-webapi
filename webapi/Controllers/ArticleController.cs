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
    public class ArticleController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IArticleService _service;
        public ArticleController(DemoContext context, IArticleService Service)
        {
            _context = context;
            _service = Service;
        }


        /// <summary>
        /// 获取文章列表： GET: api/Article
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Article>>>> GetMany([FromQuery]ArticleInput input)
        {
            return await _service.GetMany(input);
        }

        /// <summary>
        /// 获取文章详情：GET: api/Article/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseData<Article>>> GetOneById(int id)
        {
            var result = await _service.GetOneById(id.ToString());
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }

        /// <summary>
        /// 修改文章信息：PUT: api/Article/5
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResponseData<bool>>> UpdateOne(Article one)
        {
            return await _service.UpdateOne(one);
        }

        /// <summary>
        /// 新增文章：POST: api/Article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<bool>>> PostOne(Article one)
        {
            return await _service.CreateOne(one);
        }

        /// <summary>
        /// 批量删除文章： DELETE: api/Article/5
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        public async Task<ActionResult<ResponseData<bool>>> DeleteOne(String ids)
        {
            return await _service.DeleteOneByIds(ids);
        }


    }
}

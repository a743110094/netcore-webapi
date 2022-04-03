using demo.Models;
using demo.Models.vo;
using demo.Repository;
using demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemarkController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IRemarkService _service;
   

        public RemarkController(DemoContext context, IRemarkService Service)
        {
            _context = context;
            _service = Service;
          
        }


  

        /// <summary>
        /// 获取评论列表： GET: api/Remark
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Remark>>>> GetMany([FromQuery]BaseListInput input)
        {
            return await _service.GetMany(input);
        }


        [HttpGet("articleId/{id}")]
        public async Task<ActionResult<ResponseData<List<ArticleRemark>>>> GetByArticleId(String id)
        {
            var result = await _service.GetByArticleId(id);
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpGet("articles")]
        public async Task<ActionResult<ResponseData<List<ArticleRemark>>>> GetByArticles([FromQuery] ArticleRemarkInput input)
        {
            var result = await _service.GetByArticles(input);
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }


        /// <summary>
        /// 获取评论详情：GET: api/Remark/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseData<Remark>>> GetOneById(String id)
        {
            var result = await _service.GetOneById(id);
            if (result.Data == null)
            {
                return NotFound();
            }
            return result;
        }


        /// <summary>
        /// 修改评论信息：PUT: api/Remark/5
        /// </summary>
        /// <param name="Remark"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ResponseData<bool>>> UpdateOne(Remark one)
        {
            return await _service.UpdateOne(one);
        }

        /// <summary>
        /// 新增评论：POST: api/Remark
        /// </summary>
        /// <param name="Remark"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData<bool>>> PostOne(Remark one)
        {
            return await _service.CreateOne(one);
        }

        [HttpPost("status")]
        public async Task<ActionResult<ResponseData<bool>>> UpdateStatus(string id, byte? status)
        {
            return await _service.UpdateStatus(id,status);
        }

        /// <summary>
        /// 批量删除评论： DELETE: api/Remark/5
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

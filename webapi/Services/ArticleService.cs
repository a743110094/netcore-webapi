using demo.Repository;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.vo;

namespace demo.Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        //查询评论分页列表
        public async Task<ResponseData<List<Article>>> GetMany(ArticleInput input)
        {
            return await _repository.GetMany(input);
        }

        //查询评论详情
        public async Task<ResponseData<Article>> GetOneById(string id)
        {
            return await _repository.GetOneById(id);
        }

        //添加评论
        public async Task<ResponseData<bool>> CreateOne(Article one)
        {
            return await _repository.CreateOne(one);
        }

        //更新评论
        public async Task<ResponseData<bool>> UpdateOne(Article one)
        {
            return await _repository.UpdateOne(one);
        }

        //删除评论
        public async Task<ResponseData<bool>> DeleteOneByIds(string ids)
        {
            return await _repository.DeleteOneByIds(ids);
        }
    }
}

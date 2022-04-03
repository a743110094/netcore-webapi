using demo.Repository;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.vo;

namespace demo.Services
{
    public class RemarkService : IRemarkService
    {
        private IRemarkRepository _repository;

        public RemarkService(IRemarkRepository repository)
        {
            _repository = repository;
        }

        //查询文章分页列表
        public async Task<ResponseData<List<Remark>>> GetMany(BaseListInput input)
        {
            return await _repository.GetMany(input);
        }

        //查询文章详情
        public async Task<ResponseData<Remark>> GetOneById(string id)
        {
            return await _repository.GetOneById(id);
        }

        public async Task<ResponseData<List<ArticleRemark>>> GetByArticleId(string id)
        {
            return await _repository.GetByArticleId(id);
        }

         public async Task<ResponseData<List<ArticleRemark>>> GetByArticles(ArticleRemarkInput input)
        {
            return await _repository.GetByArticles(input);
        }

        //添加文章
        public async Task<ResponseData<bool>> CreateOne(Remark one)
        {
            return await _repository.CreateOne(one);
        }

        //更新文章
        public async Task<ResponseData<bool>> UpdateOne(Remark one)
        {
            return await _repository.UpdateOne(one);
        }

        public Task<ResponseData<bool>> UpdateStatus(string id, byte? status)
        {
            return _repository.UpdateStatus(id,status);
        }

        //删除文章
        public async Task<ResponseData<bool>> DeleteOneByIds(string id)
        {
            return await _repository.DeleteOneByIds(id);
        }
    }
}

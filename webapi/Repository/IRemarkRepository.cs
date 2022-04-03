using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public interface IRemarkRepository
    {
        //查询评论分页列表
        Task<ResponseData<List<Remark>>> GetMany(BaseListInput input);

        //查询评论详情
        Task<ResponseData<Remark>> GetOneById(string id);

        Task<ResponseData<List<ArticleRemark>>> GetByArticleId(string id);
        Task<ResponseData<List<ArticleRemark>>> GetByArticles(ArticleRemarkInput input);

        //添加评论
        Task<ResponseData<bool>> CreateOne(Remark one);

        //更新评论
        Task<ResponseData<bool>> UpdateOne(Remark one);

        Task<ResponseData<bool>> UpdateStatus(string id, byte? status);

        //删除评论
        Task<ResponseData<bool>> DeleteOneByIds(string id);
    }
}

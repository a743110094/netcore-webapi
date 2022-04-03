using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public interface IArticleRepository
    {
        //查询文章分页列表
        Task<ResponseData<List<Article>>> GetMany(ArticleInput input);

        //查询文章详情
        Task<ResponseData<Article>> GetOneById(string id);

        //添加文章
        Task<ResponseData<bool>> CreateOne(Article one);

        //更新文章
        Task<ResponseData<bool>> UpdateOne(Article one);

        //删除文章
        Task<ResponseData<bool>> DeleteOneByIds(string ids);
    }
}

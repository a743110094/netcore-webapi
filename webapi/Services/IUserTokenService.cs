using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services
{
    public interface IUserTokenService
    {
        //查询文章分页列表
        Task<ResponseData<List<UserToken>>> GetMany(BaseListInput input);

        //查询文章详情
        Task<ResponseData<UserToken>> GetOneById(string id);

        //添加文章
        Task<ResponseData<bool>> CreateOne(UserToken one);

        //更新文章
        Task<ResponseData<bool>> UpdateOne(UserToken one);

        //删除文章
        Task<ResponseData<bool>> DeleteOneByIds(string id);
    }
}

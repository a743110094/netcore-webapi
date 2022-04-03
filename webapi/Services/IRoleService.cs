using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services
{
    public interface IRoleService
    {
        //查询文章分页列表
        Task<ResponseData<List<Role>>> GetMany(BaseListInput input);

        //查询文章详情
        Task<ResponseData<Role>> GetOneById(Object id);

        //添加文章
        Task<ResponseData<bool>> CreateOne(Role one);

        //更新文章
        Task<ResponseData<bool>> UpdateOne(Role one);

        //删除文章
        Task<ResponseData<bool>> DeleteOneByIds(string id);
    }
}

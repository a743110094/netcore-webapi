using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public interface IRoleRepository
    {
        //查询角色分页列表
        Task<ResponseData<List<Role>>> GetMany(BaseListInput input);

        //查询角色详情
        Task<ResponseData<Role>> GetOneById(object id);

        //添加角色
        Task<ResponseData<bool>> CreateOne(Role one);

        //更新角色
        Task<ResponseData<bool>> UpdateOne(Role one);

        //删除角色
        Task<ResponseData<bool>> DeleteOneByIds(string id);
    }
}

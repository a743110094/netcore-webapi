using demo.Repository;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.vo;

namespace demo.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }

        //查询角色分页列表
        public async Task<ResponseData<List<Role>>> GetMany(BaseListInput input)
        {
            return await _repository.GetMany(input);
        }

        //查询角色详情
        public async Task<ResponseData<Role>> GetOneById(object id)
        {
            return await _repository.GetOneById(id);
        }

        //添加角色
        public async Task<ResponseData<bool>> CreateOne(Role one)
        {
            return await _repository.CreateOne(one);
        }

        //更新角色
        public async Task<ResponseData<bool>> UpdateOne(Role one)
        {
            return await _repository.UpdateOne(one);
        }

        //删除角色
        public async Task<ResponseData<bool>> DeleteOneByIds(string id)
        {
            return await _repository.DeleteOneByIds(id);
        }
    }
}

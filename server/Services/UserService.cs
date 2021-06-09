using demo.Repository;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.vo;

namespace demo.Services
{
    public class UserService:IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository) {
            _repository = repository;
        }

        //查询用户分页列表
        public async Task<ResponseData<List<User>>> GetUsers(UserListInput input)
        {
            return await _repository.GetUsers(input);
        }

        //查询用户详情
        public async Task<ResponseData<User>> GetUserById(string id)
        {
            return await _repository.GetUserById(id);
        }

        //添加用户
        public async Task<ResponseData<bool>> CreateUser(User user)
        {
            return await _repository.CreateUser(user);
        }

        //更新用户
        public async Task<ResponseData<bool>> UpdateUser(User user)
        {
            return await _repository.UpdateUser(user);
        }

        //删除用户
        public async Task<ResponseData<bool>> DeleteUserByIds(string id)
        {
            return await _repository.DeleteUserByIds(id);
        }
    }
}

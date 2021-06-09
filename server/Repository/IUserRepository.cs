using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public interface IUserRepository
    {
        //查询用户分页列表
        Task<ResponseData<List<User>>> GetUsers(UserListInput input);

        //查询用户详情
        Task<ResponseData<User>> GetUserById(string id);

        //添加用户
        Task<ResponseData<bool>> CreateUser(User user);

        //更新用户
        Task<ResponseData<bool>> UpdateUser(User user);

        //删除用户
        Task<ResponseData<bool>> DeleteUserByIds(string id);
    }
}

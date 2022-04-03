using demo.Models;
using demo.Models.vo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DemoContext _context;

        public UserRepository(DemoContext context)
        {
            _context = context;
        }


        //查询用户分页列表
        public async Task<ResponseData<List<User>>> GetUsers(UserListInput input)
        {
            IQueryable<User> users = _context.User;
            if (!string.IsNullOrEmpty(input.LoginName))
            {
                users = users.Where(x => x.LoginName.Contains(input.LoginName));
            }
            if (!string.IsNullOrEmpty(input.NickName))
            {
                users = users.Where(x => x.NickName.Contains(input.NickName));
            }if (!string.IsNullOrEmpty(input.RealName))
            {
                users = users.Where(x => x.RealName.Contains(input.RealName));
            }
            // 分页
            int total = await users.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                users = users.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            ResponseData<List<User>> output = new ResponseData<List<User>>
            {
                Data = await users.ToListAsync(),
                Total = total,
            };
            return output;
        }


        public async Task<ResponseData<List<User>>> GetUsers(LoginInput input)
        {
            IQueryable<User> users = _context.User;
            if (!string.IsNullOrEmpty(input.LoginName))
            {
                users = users.Where(x => x.LoginName.Contains(input.LoginName));
            }
            if (!string.IsNullOrEmpty(input.Password))
            {
                users = users.Where(x => x.Password.Contains(input.Password));
            }
           
            // 分页
            int total = await users.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                users = users.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            ResponseData<List<User>> output = new ResponseData<List<User>>
            {
                Data = await users.ToListAsync(),
                Total = total,
            };
            return output;
        }


        //查询用户详情
        public async Task<ResponseData<User>> GetUserById(string id)
        {
            return new ResponseData<User>() { Data = await _context.User.FindAsync(id) };

        }

        //添加用户
        public async Task<ResponseData<bool>> CreateUser(User user)
        {
            user.CreateTime = DateTime.Now;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return new ResponseData<bool>() { Data = true };
        }

        //更新用户
        public async Task<ResponseData<bool>> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id.ToString()))
                {
                    return new ResponseData<bool>() { Data = false,Message="can not find entity by id" };
                }
                else
                {
                    throw;
                }
            }
            return new ResponseData<bool>() { Data = true };
        }

        //删除用户
        public async Task<ResponseData<bool>> DeleteUserByIds(string ids)
        {
            if (ids.Contains(","))
            {
                string[] idList = ids.Split(',');
                foreach (var id in idList)
                {
                    await DeleteUser(id);
                }
            }
            else
            {
                await DeleteUser(ids);
            }

            return new ResponseData<bool>() { Data = true };
        }

        private async Task DeleteUser(string id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        private bool UserExists(String id)
        {
            return _context.User.Any(e => e.Id.Equals(id));
        }
    }
}

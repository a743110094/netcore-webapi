using demo.Models;
using demo.Models.vo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DemoContext _context;

        public RoleRepository(DemoContext context)
        {
            _context = context;
        }


        //查询角色分页列表
        public async Task<ResponseData<List<Role>>> GetMany(BaseListInput input)
        {
            IQueryable<Role> query = _context.Role;
           /* if (!string.IsNullOrEmpty(input.LoginName))
            {
                Roles = Roles.Where(x => x.LoginName.Contains(input.LoginName));
            }*/
           /* if (input.Params != null && input.Params.Count == 2)
            {
                query = query.Where(x => x.CreatedTime >= input.Params["beginCreateTime"]
                && x.CreatedTime <= input.Params["endCreateTime"]);
            }*/
            // 分页
            int total = await query.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                query = query.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            ResponseData<List<Role>> output = new ResponseData<List<Role>>
            {
                Data = await query.ToListAsync(),
                Total = total,
            };
            return output;
        }

        //查询角色详情
        public async Task<ResponseData<Role>> GetOneById(object id)
        {
            return new ResponseData<Role>() { Data = await _context.Role.FindAsync(id) };

        }

        //添加角色
        public async Task<ResponseData<bool>> CreateOne(Role one)
        {
           /* one.CreatedTime = DateTime.Now;*/
            _context.Role.Add(one);
            await _context.SaveChangesAsync();
            return new ResponseData<bool>() { Data = true };
        }

        //更新角色
        public async Task<ResponseData<bool>> UpdateOne(Role one)
        {
            _context.Entry(one).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(one.Id.ToString()))
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

        //删除角色
        public async Task<ResponseData<bool>> DeleteOneByIds(string ids)
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
            return _context.Role.Any(e => e.Id.Equals(id));
        }
    }
}

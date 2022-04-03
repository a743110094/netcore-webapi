using demo.Models;
using demo.Models.vo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly DemoContext _context;

        public UserTokenRepository(DemoContext context)
        {
            _context = context;
        }


        //查询令牌分页列表
        public async Task<ResponseData<List<UserToken>>> GetMany(BaseListInput input)
        {
            IQueryable<UserToken> query = _context.UserToken;
           /* if (!string.IsNullOrEmpty(input.LoginName))
            {
                Tokens = Tokens.Where(x => x.LoginName.Contains(input.LoginName));
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
            ResponseData<List<UserToken>> output = new ResponseData<List<UserToken>>
            {
                Data = await query.ToListAsync(),
                Total = total,
            };
            return output;
        }

        //查询令牌详情
        public async Task<ResponseData<UserToken>> GetOneById(string id)
        {
            return new ResponseData<UserToken>() { Data = await _context.UserToken.FindAsync(id) };

        }

        //添加令牌
        public async Task<ResponseData<bool>> CreateOne(UserToken one)
        {
            one.ExpireTime = DateTime.Now.AddHours(12);
            _context.UserToken.Add(one);
            await _context.SaveChangesAsync();
            return new ResponseData<bool>() { Data = true };
        }

        //更新令牌
        public async Task<ResponseData<bool>> UpdateOne(UserToken one)
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

        //删除令牌
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
            return _context.UserToken.Any(e => e.Id.Equals(id));
        }
    }
}

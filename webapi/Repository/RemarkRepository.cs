using demo.Models;
using demo.Models.vo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class RemarkRepository : IRemarkRepository
    {
        private readonly DemoContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemarkRepository(DemoContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        //查询评论分页列表
        public async Task<ResponseData<List<Remark>>> GetMany(BaseListInput input)
        {
            IQueryable<Remark> query = _context.Remark;
           /* if (!string.IsNullOrEmpty(input.LoginName))
            {
                Remarks = Remarks.Where(x => x.LoginName.Contains(input.LoginName));
            }*/
            if (input.Params != null && input.Params.Count == 2)
            {
                query = query.Where(x => x.CreatedTime >= input.Params["beginCreateTime"]
                && x.CreatedTime <= input.Params["endCreateTime"]);
            }
            // 分页
            int total = await query.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                query = query.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            ResponseData<List<Remark>> output = new ResponseData<List<Remark>>
            {
                Data = await query.ToListAsync(),
                Total = total,
            };
            return output;
        }

        //查询评论详情
        public async Task<ResponseData<Remark>> GetOneById(string id)
        {
            return new ResponseData<Remark>() { Data = await _context.Remark.FindAsync(id) };

        } 
        
        public async Task<ResponseData<List<ArticleRemark>>> GetByArticleId(string id)
        {
            string currentUserId = _httpContextAccessor.HttpContext.Request.Headers["userId"]; 
            IQueryable<ArticleRemark> remarks = _context.ArticleRemark; 
            if (!string.IsNullOrEmpty(id))
            {
                remarks = remarks.Where(x => (x.ArticleId== int.Parse(id) && x.Status == 1) || (x.ArticleId == int.Parse(id) &&  x.UserId == int.Parse(currentUserId) && x.Status == 0));
            }
            ResponseData<List<ArticleRemark>> output = new ResponseData<List<ArticleRemark>>
            {
                Data = await remarks.ToListAsync(),
                Total = await remarks.CountAsync(),
            };
            return output;
        }


        public async Task<ResponseData<List<ArticleRemark>>> GetByArticles(ArticleRemarkInput input)
        {
            IQueryable<ArticleRemark> query = _context.ArticleRemark;
            if (!string.IsNullOrEmpty(input.Content))
            {
                query = query.Where(x => (x.Content.Contains(input.Content)));
            }
            // 分页
            int total = await query.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                query = query.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            ResponseData<List<ArticleRemark>> output = new ResponseData<List<ArticleRemark>>
            {
                Data = await query.ToListAsync(),
                Total = total,
            };
            return output;
        }
        //添加评论
        public async Task<ResponseData<bool>> CreateOne(Remark one)
        {
            one.CreatedTime = DateTime.Now;
            one.Status = 0;
            _context.Remark.Add(one);
            await _context.SaveChangesAsync();
            return new ResponseData<bool>() { Data = true };
        }

        //更新评论
        public async Task<ResponseData<bool>> UpdateOne(Remark one)
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

        public async Task<ResponseData<bool>> UpdateStatus(string id,byte? status)
        {
            Remark one = new Remark { Id = Int32.Parse(id) , Status = status };
            string sqlstr = string.Format("update remark set Status = {0} where Id = {1}", status, id);
            
            try
            {
                await _context.Database.ExecuteSqlCommandAsync(sqlstr);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(one.Id.ToString()))
                {
                    return new ResponseData<bool>() { Data = false, Message = "can not find entity by id" };
                }
                else
                {
                    throw;
                }
            }
            return new ResponseData<bool>() { Message="成功" };
        }

        //删除评论
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
            return _context.Remark.Any(e => e.Id.Equals(id));
        }
    }
}

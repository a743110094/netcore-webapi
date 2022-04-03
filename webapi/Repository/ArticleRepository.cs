using demo.Models;
using demo.Models.vo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DemoContext _context;

        public ArticleRepository(DemoContext context)
        {
            _context = context;
        }


        //查询文章分页列表
        public async Task<ResponseData<List<Article>>> GetMany(ArticleInput input)
        {
            IQueryable<Article> query = _context.Article;
            if (!string.IsNullOrEmpty(input.Title))
            {
                query = query.Where(x => x.Title.Contains(input.Title));
            }
            if (!string.IsNullOrEmpty(input.Author))
            {
                query = query.Where(x => x.Author.Contains(input.Author));
            }
            if (!string.IsNullOrEmpty(input.Series))
            {
                query = query.Where(x => x.Series.Contains(input.Series));
            }
            if (input.Params != null && input.Params.Count == 2)
            {
                query = query.Where(x => x.CreateTime >= input.Params["beginCreateTime"]
                && x.CreateTime <= input.Params["endCreateTime"]);
            }
            query = query.OrderByDescending(x => x.Id);
            // 分页
            int total = await query.CountAsync();
            if (input.PageSize != 0 && input.PageNum != 0)
            {
                query = query.Skip((input.PageNum - 1) * input.PageSize).Take(input.PageSize);
            }
            
            ResponseData<List<Article>> output = new ResponseData<List<Article>>
            {
                Data = await query.ToListAsync(),
                Total = total,
            };
            return output;
        }

        //查询文章详情
        public async Task<ResponseData<Article>> GetOneById(string id)
        {
            return new ResponseData<Article>() { Data = await _context.Article.FindAsync(Int32.Parse(id)) };

        }

        //添加文章
        public async Task<ResponseData<bool>> CreateOne(Article one)
        {
            one.CreateTime = DateTime.Now;
            _context.Article.Add(one);
            await _context.SaveChangesAsync();
            return new ResponseData<bool>() { Data = true };
        }

        //更新文章
        public async Task<ResponseData<bool>> UpdateOne(Article one)
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

        //删除文章
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
            return _context.Article.Any(e => e.Id.Equals(id));
        }
    }
}

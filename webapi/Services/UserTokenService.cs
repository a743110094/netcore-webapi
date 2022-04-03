using demo.Repository;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Models.vo;

namespace demo.Services
{
    public class UserTokenService : IUserTokenService
    {
        private IUserTokenRepository _repository;

        public UserTokenService(IUserTokenRepository repository)
        {
            _repository = repository;
        }

        //查询文章分页列表
        public async Task<ResponseData<List<UserToken>>> GetMany(BaseListInput input)
        {
            return await _repository.GetMany(input);
        }

        //查询文章详情
        public async Task<ResponseData<UserToken>> GetOneById(string id)
        {
            return await _repository.GetOneById(id);
        }

        //添加文章
        public async Task<ResponseData<bool>> CreateOne(UserToken one)
        {
            return await _repository.CreateOne(one);
        }

        //更新文章
        public async Task<ResponseData<bool>> UpdateOne(UserToken one)
        {
            return await _repository.UpdateOne(one);
        }

        //删除文章
        public async Task<ResponseData<bool>> DeleteOneByIds(string id)
        {
            return await _repository.DeleteOneByIds(id);
        }
    }
}

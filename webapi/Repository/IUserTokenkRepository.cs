using demo.Models;
using demo.Models.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Repository
{
    public interface IUserTokenRepository
    {
        //查询令牌分页列表
        Task<ResponseData<List<UserToken>>> GetMany(BaseListInput input);

        //查询令牌详情
        Task<ResponseData<UserToken>> GetOneById(string id);

        //添加令牌
        Task<ResponseData<bool>> CreateOne(UserToken one);

        //更新令牌
        Task<ResponseData<bool>> UpdateOne(UserToken one);

        //删除令牌
        Task<ResponseData<bool>> DeleteOneByIds(string id);
    }
}

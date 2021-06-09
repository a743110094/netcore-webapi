import request from '@/utils/request'

// 查询用户列表
export function listUser(query) {
  return request({
    url: '/api/users',
    method: 'get',
    params: query
  })
}

// 查询用户详细
export function getUser(UserId) {
  return request({
    url: '/api/users/' + UserId,
    method: 'get'
  })
}

// 新增用户
export function addUser(data) {
  return request({
    url: '/api/users',
    method: 'post',
    data: data
  })
}

// 修改用户
export function updateUser(data) {
  return request({
    url: '/api/users',
    method: 'put',
    data: data
  })
}

// 删除用户
export function delUser(UserId) {
  return request({
    url: '/api/users/' + UserId,
    method: 'delete'
  })
}


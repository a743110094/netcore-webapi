<template>
  <div class="hello">
    <h1>{{ msg }}</h1>

    <div class="container">
        <el-form :model="queryParams" ref="queryForm" :inline="true" label-width="68px">
          <el-form-item label="登录名称" prop="LoginName">
            <el-input
              v-model="queryParams.LoginName"
              placeholder="请输入登录名称"
              clearable
              size="small"
              @keyup.enter.native="handleQuery"
            />
          </el-form-item>
          <el-form-item label="创建时间">
            <el-date-picker
              v-model="daterangeCreateTime"
              size="small"
              style="width: 240px"
              value-format="yyyy-MM-dd"
              type="daterange"
              range-separator="-" 
              start-placeholder="开始日期"
              end-placeholder="结束日期"
            ></el-date-picker>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="handleQuery">搜索</el-button>
            <el-button icon="el-icon-refresh" size="mini" @click="resetQuery">重置</el-button>
          </el-form-item>
        </el-form>

        <el-row :gutter="10" class="mb8" style="margin-bottom:10px;">
          <el-col :span="1.5">
            <el-button
              type="primary"
              plain
              icon="el-icon-plus"
              size="mini"
              @click="handleAdd"
            >新增</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button
              type="success"
              plain
              icon="el-icon-edit"
              size="mini"
              :disabled="single"
              @click="handleUpdate"
            >修改</el-button>
          </el-col>
          <el-col :span="1.5">
            <el-button
              type="danger"
              plain
              icon="el-icon-delete"
              size="mini"
              :disabled="multiple"
              @click="handleDelete"
            >删除</el-button>
          </el-col>
        </el-row>

        <el-table v-loading="loading" :data="UserList" @selection-change="handleSelectionChange" border>
          <el-table-column type="selection" width="55" align="center" />
          <el-table-column label="唯一标识符" align="center" prop="id" width="300" />
          <el-table-column label="登录用户名" align="center" prop="loginName" />
          <el-table-column label="登录密码" align="center" prop="password" />
          <el-table-column label="性别" align="center" prop="gender" />
          <el-table-column label="创建时间" align="center" prop="createTime" />
          <el-table-column label="操作" align="center" class-name="small-padding fixed-width">
            <template slot-scope="scope">
              <el-button
                size="mini"
                type="text"
                icon="el-icon-edit"
                @click="handleUpdate(scope.row)"
              >修改</el-button>
              <el-button
                size="mini"
                type="text"
                icon="el-icon-delete"
                @click="handleDelete(scope.row)"
              >删除</el-button>
            </template>
          </el-table-column>
        </el-table>
        
        <pagination
          v-show="total>0"
          :total="total"
          :page.sync="queryParams.PageNum"
          :limit.sync="queryParams.PageSize"
          @pagination="getList"
        />

        <!-- 添加或修改分组对话框 -->
        <el-dialog :title="title" :visible.sync="open" width="500px" append-to-body>
          <el-form ref="form" :model="form" :rules="rules" label-width="80px">
            <el-form-item label="登录名称" prop="loginName">
              <el-input v-model="form.loginName" placeholder="请输入登录名称名称" />
            </el-form-item>
            <el-form-item label="密码" prop="password">
              <el-input v-model="form.password" placeholder="请输入排序" />
            </el-form-item>
            <el-form-item label="性别" prop="gender">
              <el-input v-model="form.gender" placeholder="请输入性别" />
            </el-form-item>
          </el-form>
          <div slot="footer" class="dialog-footer">
            <el-button type="primary" @click="submitForm">确 定</el-button>
            <el-button @click="cancel">取 消</el-button>
          </div>
        </el-dialog>
      </div>
    
  </div>
</template>

<script>
import { listUser, getUser, delUser, addUser, updateUser } from "@/utils/user";

export default {
  name: "User",
  components: {
  },
  props:{
    msg:String
  },
  data() {
    return {
      // 遮罩层
      loading: true,
      // 选中数组
      ids: [],
      // 非单个禁用
      single: true,
      // 非多个禁用
      multiple: true,
      // 总条数
      total: 0,
      // 分组表格数据
      UserList: [],
      // 弹出层标题
      title: "",
      // 是否显示弹出层
      open: false,
      // 创建时间时间范围
      daterangeCreateTime: [],
      // 查询参数
      queryParams: {
        PageNum: 1,
        PageSize: 10,
        LoginName: null,
        CreateTime: null,
      },
      // 表单参数
      form: {},
      // 表单校验
      rules: {
        LoginName: [
          { required: true, message: "登录名称不能为空", trigger: "blur" }
        ],
      }
    };
  },
  created() {
    this.getList();
  },
  methods: {
    /** 查询分组列表 */
    getList() {
      this.loading = true;
      this.queryParams.params = {};
      if (null != this.daterangeCreateTime && '' != this.daterangeCreateTime) {
        this.queryParams.params["beginCreateTime"] = this.daterangeCreateTime[0];
        this.queryParams.params["endCreateTime"] = this.daterangeCreateTime[1];
      }
      listUser(this.queryParams).then(response => {
        this.UserList = response.data;
        this.total = response.total;
        this.loading = false;
        console.log(response.data);
      });
    },
    // 取消按钮
    cancel() {
      this.open = false;
      this.reset();
    },
    // 表单重置
    reset() {
      this.form = {
        id: null,
        loginName: null,
        password: null,
        gender: null,
        createTime: null,
      };
      if (this.$refs["form"]) {
        this.$refs["form"].resetFields();
      }
    },
    /** 搜索按钮操作 */
    handleQuery() {
      this.queryParams.pageNum = 1;
      this.getList();
    },
    /** 重置按钮操作 */
    resetQuery() {
      this.daterangeCreateTime = [];
      if (this.$refs["queryForm"]) {
        this.$refs["queryForm"].resetFields();
      }
      this.handleQuery();
    },
    // 多选框选中数据
    handleSelectionChange(selection) {
      this.ids = selection.map(item => item.id)
      this.single = selection.length!==1
      this.multiple = !selection.length
    },
    /** 新增按钮操作 */
    handleAdd() {
      this.reset();
      this.open = true;
      this.title = "添加分组";
    },
    /** 修改按钮操作 */ 
    handleUpdate(row) {
      this.reset();
      const id = row.id || this.ids
      console.log(id);
      getUser(id).then(response => {
        this.form = response.data;
        this.open = true;
        this.title = "修改分组";
      });
    },
    /** 提交按钮 */
    submitForm() {
      this.$refs["form"].validate(valid => {
        if (valid) {
          if (this.form.id != null) {
            updateUser(this.form).then(response => {
              console.log(response);
              this.$message({ showClose: true, message: "修改成功", type: "success" });
              this.open = false;
              this.getList();
            });
          } else {
            addUser(this.form).then(response => {
              console.log(response);
              this.$message({ showClose: true, message: "新增成功", type: "success" });
              this.open = false;
              this.getList();
            });
          }
        }
      });
    },
    /** 删除按钮操作 */
    handleDelete(row) {
      const ids = row.id || this.ids;
      this.$confirm('是否确认删除分组编号为"' + ids + '"的数据项?', "警告", {
          confirmButtonText: "确定",
          cancelButtonText: "取消",
          type: "warning"
        }).then(function() {
          return delUser(ids);
        }).then(() => {
          this.getList();
          // this.msgSuccess("删除成功");
          this.$message({ showClose: true, message: "删除成功", type: "success" });
        })
    }
  }
};
</script>

<style scoped>
  h3 {
    margin: 40px 0 0;
  }
  .container{
    width:80%;
    padding:20px;
    margin:20px auto;
    border:1px solid #ccc;
    text-align:left;
    margin-bottom:100px;
  }
</style>

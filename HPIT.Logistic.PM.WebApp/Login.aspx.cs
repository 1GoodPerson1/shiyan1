﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using HPIT.Logistic.PM.BLL;

namespace HPIT.Logistic.PM.WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //获取用户名和密码
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            //6.处理结果
            //如果没有找到用户，我提示一下
            UserBll bll = new UserBll();
            object result = bll.LoginIn(username,password);
            int num = Convert.ToInt32(result);
            if (result == null)
            {
                Label1.Text = "用户名密码错误，请重新输入！";
            }
            else {
                Session.Add("userID", num);
                Response.Redirect("Admin/Main.aspx");
            }
        }
    }
}
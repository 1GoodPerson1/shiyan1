using HPIT.Logistic.PM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.DAL
{
    public class UserDal
    {
        /// <summary>
        /// 登录验证的方法
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public object LoginIn(string userName, string passWord)
        {
            //与数据库操作的步骤
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserName=@username AND Password=@password ";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", userName);
            sqlParameters[1] = new SqlParameter("@password", passWord);
            //5.执行命令，返回结果
            object result = DBHelper.ExcuteScalar(sql, sqlParameters);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(string id)
        {
            UserModel model = new UserModel();
            //根据用户id 查询用户信息
            string sql = "select * from[LogisticsDB].[dbo].[User] where UserID=@ID ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", id);
            //5.执行命令，返回结果
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql, sqlParameters);
            //判断有没有读到数据，hasRows 有没有行数据
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                }
            }
            //返回结果
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetUserList()
        {
            string sql = "select * from[LogisticsDB].[dbo].[User]";
            SqlDataReader reader = DBHelper.ExcuteSqlDataReader(sql);
            //判断有没有读到数据，hasRows 有没有行数据
            List<UserModel> users = new List<UserModel>();
            if (reader.HasRows)
            {
                //读取第一条数据
                while (reader.Read())
                {
                    UserModel model = new UserModel();
                    model.UserName = reader["UserName"].ToString();
                    model.PassWord = reader["Password"].ToString();
                    model.Phone = reader["Phone"].ToString();
                    model.Account = reader["Account"].ToString();
                    model.UserID = int.Parse(reader["UserID"].ToString());
                    model.CheckInTime = Convert.ToDateTime(reader["CheckInTime"]);
                    users.Add(model);
                }
            }
            return users;
        }
    }
}

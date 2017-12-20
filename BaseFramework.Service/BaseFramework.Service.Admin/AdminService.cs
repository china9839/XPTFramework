using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseFramework.Common;
using BaseFramework.DataAccess;
using WeChatAPI.iUtil;

namespace BaseFramework.Service.Admin
{
    public class AdminService
    {
        private AdminService() { }
        public static readonly AdminService Instance;
        static AdminService()
        {
            Instance = new AdminService();
        }

        #region 用户数据维护
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<T_AdminUser> LoadData(int rows, int page,out int total)
        {
            using (var dbContext = new IPathDBEntities())
            {
                return dbContext.LoadByPage<T_AdminUser,DateTime>(page,rows,s=> s.CreateDate,out total,null,false);
            }
        }

        /// <summary>
        /// 根据ID获得用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_AdminUser GetUserByID(string id)
        {
            Guid _id = new Guid(id);
            using (var dbContext = new IPathDBEntities())
            {
                return dbContext.T_AdminUser.Single(t=> t.id.Equals(_id));
            }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="user"></param>
        public int SaveAccountInfo(T_AdminUser user,string newPwz) {
            if (user.id.Equals(Guid.Empty))
            {
                user.id = Guid.NewGuid();
                using (var dbContext = new IPathDBEntities())
                {
                    user.Pwz = AESHelper.Encrypt(user.Pwz);
                    dbContext.T_AdminUser.Add(user);
                    return dbContext.SaveChanges();
                }
            }
            else
            {
                using (var dbContext = new IPathDBEntities())
                {
                    dbContext.T_AdminUser.Attach(user);
                    dbContext.Entry(user).Property("UserName").IsModified = true;
                    dbContext.Entry(user).Property("PermissionInfo").IsModified = true;
                    if (!string.IsNullOrEmpty(newPwz))
                    {
                        user.Pwz = AESHelper.Encrypt(newPwz);
                        dbContext.Entry(user).Property("Pwz").IsModified = true;
                    }
                    dbContext.Configuration.ValidateOnSaveEnabled = false;
                    return dbContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// 根据id删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(string id)
        {
            Guid _id = new Guid(id);
            using (var dbContext = new IPathDBEntities())
            {
                var entity = new T_AdminUser()
                {
                    id = _id
                };
                dbContext.T_AdminUser.Attach(entity);
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                return dbContext.SaveChanges();
            }
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="usr"></param>
        /// <param name="pwz"></param>
        /// <returns></returns>
        public T_AdminUser Login(string usr)
        {
            using (var dbContext = new IPathDBEntities())
            {
                return dbContext.T_AdminUser.SingleOrDefault(t=> t.UserName.Equals(usr));
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="old_pwd"></param>
        /// <param name="new_pwd"></param>
        /// <returns></returns>
        public int ChangePwd(Guid adminid, string old_pwd, string new_pwd) {
            var sql = "UPDATE T_AdminUser SET Pwz=@Pwz WHERE id=@id AND Pwz=@OldPwz ";
            using (var dbContext = new IPathDBEntities())
            {
                return dbContext.Database.ExecuteSqlCommand(sql, new System.Data.SqlClient.SqlParameter[]
                {
                    new System.Data.SqlClient.SqlParameter("@Pwz", AESHelper.Encrypt(new_pwd)),
                    new System.Data.SqlClient.SqlParameter("@OldPwz", AESHelper.Encrypt(old_pwd)),
                    new System.Data.SqlClient.SqlParameter("@id", adminid)
                });
            }
        }
        #endregion
    }
}

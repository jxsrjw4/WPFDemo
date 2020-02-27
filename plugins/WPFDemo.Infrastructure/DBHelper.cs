using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPFDemo.Infrastructure
{

    public class DBHelper
    {
        private SqlSugarClient _instance = null;
        public SqlSugarClient Instance 
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new SqlSugarClient(
                            new ConnectionConfig()
                            {
                                ConnectionString = "server=.;uid=sa;pwd=@jhl85661501;database=SqlSugar4XTest",
                                DbType = DbType.SqlServer,//设置数据库类型
                                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
                            });
                }
                return _instance;
            }
        }
    }
}

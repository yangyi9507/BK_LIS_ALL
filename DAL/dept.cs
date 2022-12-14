using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:dept
	/// </summary>
	public partial class Dept
	{
		public Dept()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "dept"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.dept");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Dept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.dept(");
			strSql.Append("DeptID,DeptName,DeptNamePy,DeptMemo)");
			strSql.Append(" values (");
			strSql.Append("@DeptID,@DeptName,@DeptNamePy,@DeptMemo)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DeptID", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptNamePy", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptMemo", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.DeptID;
			parameters[1].Value = model.DeptName;
			parameters[2].Value = model.DeptNamePy;
			parameters[3].Value = model.DeptMemo;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Dept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.dept set ");
			strSql.Append("DeptID=@DeptID,");
			strSql.Append("DeptName=@DeptName,");
			strSql.Append("DeptNamePy=@DeptNamePy,");
			strSql.Append("DeptMemo=@DeptMemo");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DeptID", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptNamePy", MySqlDbType.VarChar,100),
					new MySqlParameter("@DeptMemo", MySqlDbType.VarChar,100),
					new MySqlParameter("@id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.DeptID;
			parameters[1].Value = model.DeptName;
			parameters[2].Value = model.DeptNamePy;
			parameters[3].Value = model.DeptMemo;
			parameters[4].Value = model.ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.dept ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.dept ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Dept GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,DeptID,DeptName,DeptNamePy,DeptMemo from lismain.dept ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;
            _ = new Maticsoft.Model.Dept();
            DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Dept DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Dept model =new Maticsoft.Model.Dept();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.ID=int.Parse(row["id"].ToString());
				}
				if(row["DeptID"]!=null)
				{
					model.DeptID=row["DeptID"].ToString();
				}
				if(row["DeptName"]!=null)
				{
					model.DeptName=row["DeptName"].ToString();
				}
				if(row["DeptNamePy"]!=null)
				{
					model.DeptNamePy=row["DeptNamePy"].ToString();
				}
				if(row["DeptMemo"]!=null)
				{
					model.DeptMemo=row["DeptMemo"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select id,DeptID,DeptName,DeptNamePy,DeptMemo ");
			strSql.Append(" FROM lismain.dept ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetDeptCode(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select DISTINCT DeptID,DeptName");
			strSql.Append(" FROM lismain.dept ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM lismain.dept ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from lismain.dept T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "dept";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


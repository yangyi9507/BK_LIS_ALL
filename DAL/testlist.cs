using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:testlist
	/// </summary>
	public partial class testlist
	{
		public testlist()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "testlist"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.testlist");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.testlist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.testlist(");
			strSql.Append("ItemClassCode,ItemClassName,ItemCode,ItemName)");
			strSql.Append(" values (");
			strSql.Append("@ItemClassCode,@ItemClassName,@ItemCode,@ItemName)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ItemClassCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemClassName", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemName", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.ItemClassCode;
			parameters[1].Value = model.ItemClassName;
			parameters[2].Value = model.ItemCode;
			parameters[3].Value = model.ItemName;

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
		public bool Update(Maticsoft.Model.testlist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.testlist set ");
			strSql.Append("ItemClassCode=@ItemClassCode,");
			strSql.Append("ItemClassName=@ItemClassName,");
			strSql.Append("ItemCode=@ItemCode,");
			strSql.Append("ItemName=@ItemName");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ItemClassCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemClassName", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemCode", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemName", MySqlDbType.VarChar,255),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ItemClassCode;
			parameters[1].Value = model.ItemClassName;
			parameters[2].Value = model.ItemCode;
			parameters[3].Value = model.ItemName;
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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.testlist ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.testlist ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.testlist GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ItemClassCode,ItemClassName,ItemCode,ItemName from lismain.testlist ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.testlist model=new Maticsoft.Model.testlist();
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
		public Maticsoft.Model.testlist DataRowToModel(DataRow row)
		{
			Maticsoft.Model.testlist model=new Maticsoft.Model.testlist();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ItemClassCode"]!=null)
				{
					model.ItemClassCode=row["ItemClassCode"].ToString();
				}
				if(row["ItemClassName"]!=null)
				{
					model.ItemClassName=row["ItemClassName"].ToString();
				}
				if(row["ItemCode"]!=null)
				{
					model.ItemCode=row["ItemCode"].ToString();
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetDataByDicCode(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID,ItemCode,ItemName ");
			strSql.Append(" FROM lismain.testlist ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetDicCode(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select DISTINCT ItemClassCode,ItemClassName");
			strSql.Append(" FROM lismain.testlist ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ItemClassCode,ItemClassName,ItemCode,ItemName ");
			strSql.Append(" FROM lismain.testlist ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM lismain.testlist ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from lismain.testlist T ");
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
			parameters[0].Value = "testlist";
			parameters[1].Value = "ID";
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


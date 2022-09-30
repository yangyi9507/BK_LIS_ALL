using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:classtype
	/// </summary>
	public partial class classtype
	{
		public classtype()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "classtype"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.classtype");
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
		public bool Add(Maticsoft.Model.classtype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into  lismain.classtype(");
			strSql.Append("DicCode,DicName,DicItemCode,DicItemName,DicItemNamePy)");
			strSql.Append(" values (");
			strSql.Append("@DicCode,@DicName,@DicItemCode,@DicItemName,@DicItemNamePy)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DicCode", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemCode", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemNamePy", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.DicCode;
			parameters[1].Value = model.DicName;
			parameters[2].Value = model.DicItemCode;
			parameters[3].Value = model.DicItemName;
			parameters[4].Value = model.DicItemNamePy;

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
		public bool Update(Maticsoft.Model.classtype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.classtype set ");
			strSql.Append("DicCode=@DicCode,");
			strSql.Append("DicName=@DicName,");
			strSql.Append("DicItemCode=@DicItemCode,");
			strSql.Append("DicItemName=@DicItemName,");
			strSql.Append("DicItemNamePy=@DicItemNamePy");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DicCode", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemCode", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemName", MySqlDbType.VarChar,100),
					new MySqlParameter("@DicItemNamePy", MySqlDbType.VarChar,100),
					new MySqlParameter("@ID", MySqlDbType.Int32,10)};
			parameters[0].Value = model.DicCode;
			parameters[1].Value = model.DicName;
			parameters[2].Value = model.DicItemCode;
			parameters[3].Value = model.DicItemName;
			parameters[4].Value = model.DicItemNamePy;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from lismain.classtype ");
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
			strSql.Append("delete from lismain.classtype ");
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
		public Maticsoft.Model.classtype GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,DicCode,DicName,DicItemCode,DicItemName,DicItemNamePy from lismain.classtype ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.classtype model=new Maticsoft.Model.classtype();
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
		public Maticsoft.Model.classtype DataRowToModel(DataRow row)
		{
			Maticsoft.Model.classtype model=new Maticsoft.Model.classtype();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["DicCode"]!=null)
				{
					model.DicCode=row["DicCode"].ToString();
				}
				if(row["DicName"]!=null)
				{
					model.DicName=row["DicName"].ToString();
				}
				if(row["DicItemCode"]!=null)
				{
					model.DicItemCode=row["DicItemCode"].ToString();
				}
				if(row["DicItemName"]!=null)
				{
					model.DicItemName=row["DicItemName"].ToString();
				}
				if(row["DicItemNamePy"]!=null)
				{
					model.DicItemNamePy=row["DicItemNamePy"].ToString();
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
			strSql.Append("select ID,DicCode,DicName,DicItemCode,DicItemName,DicItemNamePy ");
			strSql.Append(" FROM lismain.classtype ");
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
			strSql.Append("select DISTINCT DicCode,DicName");
			strSql.Append(" FROM lismain.classtype ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetDataByDicCode(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,DicItemCode,DicItemName,DicItemNamePy ");
			strSql.Append(" FROM lismain.classtype ");
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
			strSql.Append("select count(1) FROM lismain.classtype ");
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
			strSql.Append(")AS Row, T.*  from lismain.classtype T ");
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
			parameters[0].Value = "classtype";
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


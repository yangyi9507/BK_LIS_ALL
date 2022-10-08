using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:report_detail
	/// </summary>
	public partial class report_detail
	{
		public report_detail()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.report_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.report_detail(");
			strSql.Append("ReportID,ItemNo,ItemName,Result,Units,RefRange,Abnormal_Flg)");
			strSql.Append(" values (");
			strSql.Append("@ReportID,@ItemNo,@ItemName,@Result,@Units,@RefRange,@Abnormal_Flg)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemName", MySqlDbType.VarChar,255),
					new MySqlParameter("@Result", MySqlDbType.VarChar,255),
					new MySqlParameter("@Units", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefRange", MySqlDbType.VarChar,255),
					new MySqlParameter("@Abnormal_Flg", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.ItemNo;
			parameters[2].Value = model.ItemName;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Units;
			parameters[5].Value = model.RefRange;
			parameters[6].Value = model.Abnormal_Flg;

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
		public bool Update(Maticsoft.Model.report_detail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.report_detail set ");
			strSql.Append("ReportID=@ReportID,");
			strSql.Append("ItemNo=@ItemNo,");
			strSql.Append("ItemName=@ItemName,");
			strSql.Append("Result=@Result,");
			strSql.Append("Units=@Units,");
			strSql.Append("RefRange=@RefRange,");
			strSql.Append("Abnormal_Flg=@Abnormal_Flg");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@ItemName", MySqlDbType.VarChar,255),
					new MySqlParameter("@Result", MySqlDbType.VarChar,255),
					new MySqlParameter("@Units", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefRange", MySqlDbType.VarChar,255),
					new MySqlParameter("@Abnormal_Flg", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.ItemNo;
			parameters[2].Value = model.ItemName;
			parameters[3].Value = model.Result;
			parameters[4].Value = model.Units;
			parameters[5].Value = model.RefRange;
			parameters[6].Value = model.Abnormal_Flg;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.report_detail ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.report_detail GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportID,ItemNo,ItemName,Result,Units,RefRange,Abnormal_Flg from lismain.report_detail ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Maticsoft.Model.report_detail model=new Maticsoft.Model.report_detail();
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
		public Maticsoft.Model.report_detail DataRowToModel(DataRow row)
		{
			Maticsoft.Model.report_detail model=new Maticsoft.Model.report_detail();
			if (row != null)
			{
				if(row["ReportID"]!=null)
				{
					model.ReportID=row["ReportID"].ToString();
				}
				if(row["ItemNo"]!=null)
				{
					model.ItemNo=row["ItemNo"].ToString();
				}
				if(row["ItemName"]!=null)
				{
					model.ItemName=row["ItemName"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["Units"]!=null)
				{
					model.Units=row["Units"].ToString();
				}
				if(row["RefRange"]!=null)
				{
					model.RefRange=row["RefRange"].ToString();
				}
				if(row["Abnormal_Flg"]!=null)
				{
					model.Abnormal_Flg=row["Abnormal_Flg"].ToString();
				}
			}
			return model;
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetRightList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ItemNo,ItemName,Result,Units,RefRange,Abnormal_Flg ");
			strSql.Append(" FROM lismain.report_detail ");
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
			strSql.Append("select ReportID,ItemNo,ItemName,Result,Units,RefRange,Abnormal_Flg ");
			strSql.Append(" FROM lismain.report_detail ");
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
			strSql.Append("select count(1) FROM lismain.report_detail ");
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
			strSql.Append(")AS Row, T.*  from lismain.report_detail T ");
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
			parameters[0].Value = "report_detail";
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


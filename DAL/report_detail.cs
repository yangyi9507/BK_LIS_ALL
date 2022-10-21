﻿using System;
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
			strSql.Append("insert into report_detail(");
			strSql.Append("Rpt_DetailID,REPORT_ID,KeyNo_Group,ITEM_ID,ITEM_NAME,ITEM_ENAME,UNIT,RefRange,RANGE_HIGH,RANGE_LOW,RESULT,Abnormal_flg,RESLT_TIME,SNO,PrintNo,GNO,CHARGE_No)");
			strSql.Append(" values (");
			strSql.Append("@Rpt_DetailID,@REPORT_ID,@KeyNo_Group,@ITEM_ID,@ITEM_NAME,@ITEM_ENAME,@UNIT,@RefRange,@RANGE_HIGH,@RANGE_LOW,@RESULT,@Abnormal_flg,@RESLT_TIME,@SNO,@PrintNo,@GNO,@CHARGE_No)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Rpt_DetailID", MySqlDbType.Decimal,10),
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@KeyNo_Group", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_ENAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@UNIT", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefRange", MySqlDbType.VarChar,255),
					new MySqlParameter("@RANGE_HIGH", MySqlDbType.VarChar,255),
					new MySqlParameter("@RANGE_LOW", MySqlDbType.VarChar,255),
					new MySqlParameter("@RESULT", MySqlDbType.VarChar,255),
					new MySqlParameter("@Abnormal_flg", MySqlDbType.VarChar,255),
					new MySqlParameter("@RESLT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@SNO", MySqlDbType.Int32,4),
					new MySqlParameter("@PrintNo", MySqlDbType.Int32,4),
					new MySqlParameter("@GNO", MySqlDbType.Int32,4),
					new MySqlParameter("@CHARGE_No", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.Rpt_DetailID;
			parameters[1].Value = model.REPORT_ID;
			parameters[2].Value = model.KeyNo_Group;
			parameters[3].Value = model.ITEM_ID;
			parameters[4].Value = model.ITEM_NAME;
			parameters[5].Value = model.ITEM_ENAME;
			parameters[6].Value = model.UNIT;
			parameters[7].Value = model.RefRange;
			parameters[8].Value = model.RANGE_HIGH;
			parameters[9].Value = model.RANGE_LOW;
			parameters[10].Value = model.RESULT;
			parameters[11].Value = model.Abnormal_flg;
			parameters[12].Value = model.RESLT_TIME;
			parameters[13].Value = model.SNO;
			parameters[14].Value = model.PrintNo;
			parameters[15].Value = model.GNO;
			parameters[16].Value = model.CHARGE_No;

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
			strSql.Append("update report_detail set ");
			strSql.Append("Rpt_DetailID=@Rpt_DetailID,");
			strSql.Append("REPORT_ID=@REPORT_ID,");
			strSql.Append("KeyNo_Group=@KeyNo_Group,");
			strSql.Append("ITEM_ID=@ITEM_ID,");
			strSql.Append("ITEM_NAME=@ITEM_NAME,");
			strSql.Append("ITEM_ENAME=@ITEM_ENAME,");
			strSql.Append("UNIT=@UNIT,");
			strSql.Append("RefRange=@RefRange,");
			strSql.Append("RANGE_HIGH=@RANGE_HIGH,");
			strSql.Append("RANGE_LOW=@RANGE_LOW,");
			strSql.Append("RESULT=@RESULT,");
			strSql.Append("Abnormal_flg=@Abnormal_flg,");
			strSql.Append("RESLT_TIME=@RESLT_TIME,");
			strSql.Append("SNO=@SNO,");
			strSql.Append("PrintNo=@PrintNo,");
			strSql.Append("GNO=@GNO,");
			strSql.Append("CHARGE_No=@CHARGE_No");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Rpt_DetailID", MySqlDbType.Decimal,10),
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@KeyNo_Group", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@ITEM_ENAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@UNIT", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefRange", MySqlDbType.VarChar,255),
					new MySqlParameter("@RANGE_HIGH", MySqlDbType.VarChar,255),
					new MySqlParameter("@RANGE_LOW", MySqlDbType.VarChar,255),
					new MySqlParameter("@RESULT", MySqlDbType.VarChar,255),
					new MySqlParameter("@Abnormal_flg", MySqlDbType.VarChar,255),
					new MySqlParameter("@RESLT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@SNO", MySqlDbType.Int32,4),
					new MySqlParameter("@PrintNo", MySqlDbType.Int32,4),
					new MySqlParameter("@GNO", MySqlDbType.Int32,4),
					new MySqlParameter("@CHARGE_No", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.Rpt_DetailID;
			parameters[1].Value = model.REPORT_ID;
			parameters[2].Value = model.KeyNo_Group;
			parameters[3].Value = model.ITEM_ID;
			parameters[4].Value = model.ITEM_NAME;
			parameters[5].Value = model.ITEM_ENAME;
			parameters[6].Value = model.UNIT;
			parameters[7].Value = model.RefRange;
			parameters[8].Value = model.RANGE_HIGH;
			parameters[9].Value = model.RANGE_LOW;
			parameters[10].Value = model.RESULT;
			parameters[11].Value = model.Abnormal_flg;
			parameters[12].Value = model.RESLT_TIME;
			parameters[13].Value = model.SNO;
			parameters[14].Value = model.PrintNo;
			parameters[15].Value = model.GNO;
			parameters[16].Value = model.CHARGE_No;

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
			strSql.Append("delete from report_detail ");
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
			strSql.Append("select Rpt_DetailID,REPORT_ID,KeyNo_Group,ITEM_ID,ITEM_NAME,ITEM_ENAME,UNIT,RefRange,RANGE_HIGH,RANGE_LOW,RESULT,Abnormal_flg,RESLT_TIME,SNO,PrintNo,GNO,CHARGE_No from report_detail ");
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
				if(row["Rpt_DetailID"]!=null && row["Rpt_DetailID"].ToString()!="")
				{
					model.Rpt_DetailID=decimal.Parse(row["Rpt_DetailID"].ToString());
				}
				if(row["REPORT_ID"]!=null)
				{
					model.REPORT_ID=row["REPORT_ID"].ToString();
				}
				if(row["KeyNo_Group"]!=null)
				{
					model.KeyNo_Group=row["KeyNo_Group"].ToString();
				}
				if(row["ITEM_ID"]!=null)
				{
					model.ITEM_ID=row["ITEM_ID"].ToString();
				}
				if(row["ITEM_NAME"]!=null)
				{
					model.ITEM_NAME=row["ITEM_NAME"].ToString();
				}
				if(row["ITEM_ENAME"]!=null)
				{
					model.ITEM_ENAME=row["ITEM_ENAME"].ToString();
				}
				if(row["UNIT"]!=null)
				{
					model.UNIT=row["UNIT"].ToString();
				}
				if(row["RefRange"]!=null)
				{
					model.RefRange=row["RefRange"].ToString();
				}
				if(row["RANGE_HIGH"]!=null)
				{
					model.RANGE_HIGH=row["RANGE_HIGH"].ToString();
				}
				if(row["RANGE_LOW"]!=null)
				{
					model.RANGE_LOW=row["RANGE_LOW"].ToString();
				}
				if(row["RESULT"]!=null)
				{
					model.RESULT=row["RESULT"].ToString();
				}
				if(row["Abnormal_flg"]!=null)
				{
					model.Abnormal_flg=row["Abnormal_flg"].ToString();
				}
				if(row["RESLT_TIME"]!=null && row["RESLT_TIME"].ToString()!="")
				{
					model.RESLT_TIME=DateTime.Parse(row["RESLT_TIME"].ToString());
				}
				if(row["SNO"]!=null && row["SNO"].ToString()!="")
				{
					model.SNO=int.Parse(row["SNO"].ToString());
				}
				if(row["PrintNo"]!=null && row["PrintNo"].ToString()!="")
				{
					model.PrintNo=int.Parse(row["PrintNo"].ToString());
				}
				if(row["GNO"]!=null && row["GNO"].ToString()!="")
				{
					model.GNO=int.Parse(row["GNO"].ToString());
				}
				if(row["CHARGE_No"]!=null)
				{
					model.CHARGE_No=row["CHARGE_No"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Rpt_DetailID,REPORT_ID,KeyNo_Group,ITEM_ID,ITEM_NAME,ITEM_ENAME,UNIT,RefRange,RANGE_HIGH,RANGE_LOW,RESULT,Abnormal_flg,RESLT_TIME,SNO,PrintNo,GNO,CHARGE_No ");
			strSql.Append(" FROM report_detail ");
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
			strSql.Append("select count(1) FROM report_detail ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from report_detail T ");
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
			parameters[1].Value = "";
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


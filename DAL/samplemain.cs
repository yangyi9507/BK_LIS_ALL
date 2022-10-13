using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:samplemain
	/// </summary>
	public partial class samplemain
	{
		public samplemain()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BARCODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.samplemain");
			strSql.Append(" where BARCODE=@BARCODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255)			};
			parameters[0].Value = BARCODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.samplemain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.samplemain(");
			strSql.Append("BARCODE,REPORT_TYPE,REPORT_NAME,REG_TYPE,OUT_PAT_ID,PAT_ID,PAT_NAME,PAT_SEX,PAT_AGE,ROOM,BED,PAT_NO,CREAT_TIME,CREAT_USER_NAME,CREAT_DEPT_NAME,COLLECT_TIME,COLLECT_USER_NAME,COLLECT_DEPT_NAME,RECEIVE_TIME,RECEIVE_USER_NAME,RECEIVE_DEPT_NAME,EXAM_TIME,EXAM_OPERATOR_NAME,EXAM_EQUIPMENT_NAME)");
			strSql.Append(" values (");
			strSql.Append("@BARCODE,@REPORT_TYPE,@REPORT_NAME,@REG_TYPE,@OUT_PAT_ID,@PAT_ID,@PAT_NAME,@PAT_SEX,@PAT_AGE,@ROOM,@BED,@PAT_NO,@CREAT_TIME,@CREAT_USER_NAME,@CREAT_DEPT_NAME,@COLLECT_TIME,@COLLECT_USER_NAME,@COLLECT_DEPT_NAME,@RECEIVE_TIME,@RECEIVE_USER_NAME,@RECEIVE_DEPT_NAME,@EXAM_TIME,@EXAM_OPERATOR_NAME,@EXAM_EQUIPMENT_NAME)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255),
					new MySqlParameter("@REPORT_TYPE", MySqlDbType.VarChar,255),
					new MySqlParameter("@REPORT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@REG_TYPE", MySqlDbType.VarChar,255),
					new MySqlParameter("@OUT_PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_SEX", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGE", MySqlDbType.VarChar,255),
					new MySqlParameter("@ROOM", MySqlDbType.VarChar,255),
					new MySqlParameter("@BED", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@CREAT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@CREAT_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@CREAT_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@COLLECT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@COLLECT_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@COLLECT_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@RECEIVE_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@RECEIVE_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@RECEIVE_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@EXAM_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@EXAM_OPERATOR_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@EXAM_EQUIPMENT_NAME", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.BARCODE;
			parameters[1].Value = model.REPORT_TYPE;
			parameters[2].Value = model.REPORT_NAME;
			parameters[3].Value = model.REG_TYPE;
			parameters[4].Value = model.OUT_PAT_ID;
			parameters[5].Value = model.PAT_ID;
			parameters[6].Value = model.PAT_NAME;
			parameters[7].Value = model.PAT_SEX;
			parameters[8].Value = model.PAT_AGE;
			parameters[9].Value = model.ROOM;
			parameters[10].Value = model.BED;
			parameters[11].Value = model.PAT_NO;
			parameters[12].Value = model.CREAT_TIME;
			parameters[13].Value = model.CREAT_USER_NAME;
			parameters[14].Value = model.CREAT_DEPT_NAME;
			parameters[15].Value = model.COLLECT_TIME;
			parameters[16].Value = model.COLLECT_USER_NAME;
			parameters[17].Value = model.COLLECT_DEPT_NAME;
			parameters[18].Value = model.RECEIVE_TIME;
			parameters[19].Value = model.RECEIVE_USER_NAME;
			parameters[20].Value = model.RECEIVE_DEPT_NAME;
			parameters[21].Value = model.EXAM_TIME;
			parameters[22].Value = model.EXAM_OPERATOR_NAME;
			parameters[23].Value = model.EXAM_EQUIPMENT_NAME;

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
		public bool Update(Maticsoft.Model.samplemain model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.samplemain set ");
			strSql.Append("REPORT_TYPE=@REPORT_TYPE,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("REG_TYPE=@REG_TYPE,");
			strSql.Append("OUT_PAT_ID=@OUT_PAT_ID,");
			strSql.Append("PAT_ID=@PAT_ID,");
			strSql.Append("PAT_NAME=@PAT_NAME,");
			strSql.Append("PAT_SEX=@PAT_SEX,");
			strSql.Append("PAT_AGE=@PAT_AGE,");
			strSql.Append("ROOM=@ROOM,");
			strSql.Append("BED=@BED,");
			strSql.Append("PAT_NO=@PAT_NO,");
			strSql.Append("CREAT_TIME=@CREAT_TIME,");
			strSql.Append("CREAT_USER_NAME=@CREAT_USER_NAME,");
			strSql.Append("CREAT_DEPT_NAME=@CREAT_DEPT_NAME,");
			strSql.Append("COLLECT_TIME=@COLLECT_TIME,");
			strSql.Append("COLLECT_USER_NAME=@COLLECT_USER_NAME,");
			strSql.Append("COLLECT_DEPT_NAME=@COLLECT_DEPT_NAME,");
			strSql.Append("RECEIVE_TIME=@RECEIVE_TIME,");
			strSql.Append("RECEIVE_USER_NAME=@RECEIVE_USER_NAME,");
			strSql.Append("RECEIVE_DEPT_NAME=@RECEIVE_DEPT_NAME,");
			strSql.Append("EXAM_TIME=@EXAM_TIME,");
			strSql.Append("EXAM_OPERATOR_NAME=@EXAM_OPERATOR_NAME,");
			strSql.Append("EXAM_EQUIPMENT_NAME=@EXAM_EQUIPMENT_NAME");
			strSql.Append(" where BARCODE=@BARCODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_TYPE", MySqlDbType.VarChar,255),
					new MySqlParameter("@REPORT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@REG_TYPE", MySqlDbType.VarChar,255),
					new MySqlParameter("@OUT_PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_SEX", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGE", MySqlDbType.VarChar,255),
					new MySqlParameter("@ROOM", MySqlDbType.VarChar,255),
					new MySqlParameter("@BED", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@CREAT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@CREAT_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@CREAT_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@COLLECT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@COLLECT_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@COLLECT_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@RECEIVE_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@RECEIVE_USER_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@RECEIVE_DEPT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@EXAM_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@EXAM_OPERATOR_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@EXAM_EQUIPMENT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.REPORT_TYPE;
			parameters[1].Value = model.REPORT_NAME;
			parameters[2].Value = model.REG_TYPE;
			parameters[3].Value = model.OUT_PAT_ID;
			parameters[4].Value = model.PAT_ID;
			parameters[5].Value = model.PAT_NAME;
			parameters[6].Value = model.PAT_SEX;
			parameters[7].Value = model.PAT_AGE;
			parameters[8].Value = model.ROOM;
			parameters[9].Value = model.BED;
			parameters[10].Value = model.PAT_NO;
			parameters[11].Value = model.CREAT_TIME;
			parameters[12].Value = model.CREAT_USER_NAME;
			parameters[13].Value = model.CREAT_DEPT_NAME;
			parameters[14].Value = model.COLLECT_TIME;
			parameters[15].Value = model.COLLECT_USER_NAME;
			parameters[16].Value = model.COLLECT_DEPT_NAME;
			parameters[17].Value = model.RECEIVE_TIME;
			parameters[18].Value = model.RECEIVE_USER_NAME;
			parameters[19].Value = model.RECEIVE_DEPT_NAME;
			parameters[20].Value = model.EXAM_TIME;
			parameters[21].Value = model.EXAM_OPERATOR_NAME;
			parameters[22].Value = model.EXAM_EQUIPMENT_NAME;
			parameters[23].Value = model.BARCODE;

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
		public bool Delete(string BARCODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.samplemain ");
			strSql.Append(" where BARCODE=@BARCODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255)			};
			parameters[0].Value = BARCODE;

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
		public bool DeleteList(string BARCODElist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.samplemain ");
			strSql.Append(" where BARCODE in ("+BARCODElist + ")  ");
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
		public Maticsoft.Model.samplemain GetModel(string BARCODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BARCODE,REPORT_TYPE,REPORT_NAME,REG_TYPE,OUT_PAT_ID,PAT_ID,PAT_NAME,PAT_SEX,PAT_AGE,ROOM,BED,PAT_NO,CREAT_TIME,CREAT_USER_NAME,CREAT_DEPT_NAME,COLLECT_TIME,COLLECT_USER_NAME,COLLECT_DEPT_NAME,RECEIVE_TIME,RECEIVE_USER_NAME,RECEIVE_DEPT_NAME,EXAM_TIME,EXAM_OPERATOR_NAME,EXAM_EQUIPMENT_NAME from lismain.samplemain ");
			strSql.Append(" where BARCODE=@BARCODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255)			};
			parameters[0].Value = BARCODE;

			Maticsoft.Model.samplemain model=new Maticsoft.Model.samplemain();
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
		public Maticsoft.Model.samplemain DataRowToModel(DataRow row)
		{
			Maticsoft.Model.samplemain model=new Maticsoft.Model.samplemain();
			if (row != null)
			{
				if(row["BARCODE"]!=null)
				{
					model.BARCODE=row["BARCODE"].ToString();
				}
				if(row["REPORT_TYPE"]!=null)
				{
					model.REPORT_TYPE=row["REPORT_TYPE"].ToString();
				}
				if(row["REPORT_NAME"]!=null)
				{
					model.REPORT_NAME=row["REPORT_NAME"].ToString();
				}
				if(row["REG_TYPE"]!=null)
				{
					model.REG_TYPE=row["REG_TYPE"].ToString();
				}
				if(row["OUT_PAT_ID"]!=null)
				{
					model.OUT_PAT_ID=row["OUT_PAT_ID"].ToString();
				}
				if(row["PAT_ID"]!=null)
				{
					model.PAT_ID=row["PAT_ID"].ToString();
				}
				if(row["PAT_NAME"]!=null)
				{
					model.PAT_NAME=row["PAT_NAME"].ToString();
				}
				if(row["PAT_SEX"]!=null)
				{
					model.PAT_SEX=row["PAT_SEX"].ToString();
				}
				if(row["PAT_AGE"]!=null)
				{
					model.PAT_AGE=row["PAT_AGE"].ToString();
				}
				if(row["ROOM"]!=null)
				{
					model.ROOM=row["ROOM"].ToString();
				}
				if(row["BED"]!=null)
				{
					model.BED=row["BED"].ToString();
				}
				if(row["PAT_NO"]!=null)
				{
					model.PAT_NO=row["PAT_NO"].ToString();
				}
				if(row["CREAT_TIME"]!=null && row["CREAT_TIME"].ToString()!="")
				{
					model.CREAT_TIME=DateTime.Parse(row["CREAT_TIME"].ToString());
				}
				if(row["CREAT_USER_NAME"]!=null)
				{
					model.CREAT_USER_NAME=row["CREAT_USER_NAME"].ToString();
				}
				if(row["CREAT_DEPT_NAME"]!=null)
				{
					model.CREAT_DEPT_NAME=row["CREAT_DEPT_NAME"].ToString();
				}
				if(row["COLLECT_TIME"]!=null && row["COLLECT_TIME"].ToString()!="")
				{
					model.COLLECT_TIME=DateTime.Parse(row["COLLECT_TIME"].ToString());
				}
				if(row["COLLECT_USER_NAME"]!=null)
				{
					model.COLLECT_USER_NAME=row["COLLECT_USER_NAME"].ToString();
				}
				if(row["COLLECT_DEPT_NAME"]!=null)
				{
					model.COLLECT_DEPT_NAME=row["COLLECT_DEPT_NAME"].ToString();
				}
				if(row["RECEIVE_TIME"]!=null && row["RECEIVE_TIME"].ToString()!="")
				{
					model.RECEIVE_TIME=DateTime.Parse(row["RECEIVE_TIME"].ToString());
				}
				if(row["RECEIVE_USER_NAME"]!=null)
				{
					model.RECEIVE_USER_NAME=row["RECEIVE_USER_NAME"].ToString();
				}
				if(row["RECEIVE_DEPT_NAME"]!=null)
				{
					model.RECEIVE_DEPT_NAME=row["RECEIVE_DEPT_NAME"].ToString();
				}
				if(row["EXAM_TIME"]!=null && row["EXAM_TIME"].ToString()!="")
				{
					model.EXAM_TIME=DateTime.Parse(row["EXAM_TIME"].ToString());
				}
				if(row["EXAM_OPERATOR_NAME"]!=null)
				{
					model.EXAM_OPERATOR_NAME=row["EXAM_OPERATOR_NAME"].ToString();
				}
				if(row["EXAM_EQUIPMENT_NAME"]!=null)
				{
					model.EXAM_EQUIPMENT_NAME=row["EXAM_EQUIPMENT_NAME"].ToString();
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
			strSql.Append("select BARCODE,REPORT_TYPE,REPORT_NAME,REG_TYPE,OUT_PAT_ID,PAT_ID,PAT_NAME,PAT_SEX,PAT_AGE,ROOM,BED,PAT_NO,CREAT_TIME,CREAT_USER_NAME,CREAT_DEPT_NAME,COLLECT_TIME,COLLECT_USER_NAME,COLLECT_DEPT_NAME,RECEIVE_TIME,RECEIVE_USER_NAME,RECEIVE_DEPT_NAME,EXAM_TIME,EXAM_OPERATOR_NAME,EXAM_EQUIPMENT_NAME ");
			strSql.Append(" FROM lismain.samplemain ");
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
			strSql.Append("select count(1) FROM lismain.samplemain ");
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
				strSql.Append("order by T.BARCODE desc");
			}
			strSql.Append(")AS Row, T.*  from lismain.samplemain T ");
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
			parameters[0].Value = "samplemain";
			parameters[1].Value = "BARCODE";
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


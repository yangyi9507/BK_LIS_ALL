using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:report_main
	/// </summary>
	public partial class report_main
	{
		public report_main()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReportID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.report_main");
			strSql.Append(" where ReportID=@ReportID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = ReportID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}

		public bool ExistsBySampleNo(string SampleNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from lismain.report_main");
			strSql.Append(" where SampleNo=@SampleNo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SampleNo", MySqlDbType.VarChar,255)            };
			parameters[0].Value = SampleNo;

			return DbHelperMySQL.Exists(strSql.ToString(), parameters);
		}

		public DataTable QueryBySampleNo(string SampleNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select reportID from lismain.report_main");
			strSql.Append(" where SampleNo=@SampleNo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SampleNo", MySqlDbType.VarChar,255)            };
			parameters[0].Value = SampleNo;

			return DbHelperMySQL.Query(strSql.ToString(), parameters).Tables[0];
		}



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.report_main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.report_main(");
			strSql.Append("ReportID,Barcode,SampleNo,PatType,PatName,PatSex,PatAge,PatDept,BedNo,RoomNo,PatBirthday,SampleType,SendDocID,SendDocName,TestID,TestName,TestDocID,TestDocName,CheckDocID,CheckDocName,Diagnosis,Demo,Flag_Audit,Flag_Print)");
			strSql.Append(" values (");
			strSql.Append("@ReportID,@Barcode,@SampleNo,@PatType,@PatName,@PatSex,@PatAge,@PatDept,@BedNo,@RoomNo,@PatBirthday,@SampleType,@SendDocID,@SendDocName,@TestID,@TestName,@TestDocID,@TestDocName,@CheckDocID,@CheckDocName,@Diagnosis,@Demo,@Flag_Audit,@Flag_Print)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255),
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@SampleNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatType", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatName", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatSex", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatAge", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatDept", MySqlDbType.VarChar,255),
					new MySqlParameter("@BedNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@RoomNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatBirthday", MySqlDbType.VarChar,255),
					new MySqlParameter("@SampleType", MySqlDbType.VarChar,255),
					new MySqlParameter("@SendDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@SendDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestName", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@CheckDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@CheckDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@Diagnosis", MySqlDbType.VarChar,255),
					new MySqlParameter("@Demo", MySqlDbType.VarChar,255),
					new MySqlParameter("@Flag_Audit", MySqlDbType.Int32,11),
					new MySqlParameter("@Flag_Print", MySqlDbType.Int32,11)};
			parameters[0].Value = model.ReportID;
			parameters[1].Value = model.Barcode;
			parameters[2].Value = model.SampleNo;
			parameters[3].Value = model.PatType;
			parameters[4].Value = model.PatName;
			parameters[5].Value = model.PatSex;
			parameters[6].Value = model.PatAge;
			parameters[7].Value = model.PatDept;
			parameters[8].Value = model.BedNo;
			parameters[9].Value = model.RoomNo;
			parameters[10].Value = model.PatBirthday;
			parameters[11].Value = model.SampleType;
			parameters[12].Value = model.SendDocID;
			parameters[13].Value = model.SendDocName;
			parameters[14].Value = model.TestID;
			parameters[15].Value = model.TestName;
			parameters[16].Value = model.TestDocID;
			parameters[17].Value = model.TestDocName;
			parameters[18].Value = model.CheckDocID;
			parameters[19].Value = model.CheckDocName;
			parameters[20].Value = model.Diagnosis;
			parameters[21].Value = model.Demo;
			parameters[22].Value = model.Flag_Audit;
			parameters[23].Value = model.Flag_Print;

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
		public bool Update(Maticsoft.Model.report_main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.report_main set ");
			strSql.Append("Barcode=@Barcode,");
			strSql.Append("SampleNo=@SampleNo,");
			strSql.Append("PatType=@PatType,");
			strSql.Append("PatName=@PatName,");
			strSql.Append("PatSex=@PatSex,");
			strSql.Append("PatAge=@PatAge,");
			strSql.Append("PatDept=@PatDept,");
			strSql.Append("BedNo=@BedNo,");
			strSql.Append("RoomNo=@RoomNo,");
			strSql.Append("PatBirthday=@PatBirthday,");
			strSql.Append("SampleType=@SampleType,");
			strSql.Append("SendDocID=@SendDocID,");
			strSql.Append("SendDocName=@SendDocName,");
			strSql.Append("TestID=@TestID,");
			strSql.Append("TestName=@TestName,");
			strSql.Append("TestDocID=@TestDocID,");
			strSql.Append("TestDocName=@TestDocName,");
			strSql.Append("CheckDocID=@CheckDocID,");
			strSql.Append("CheckDocName=@CheckDocName,");
			strSql.Append("Diagnosis=@Diagnosis,");
			strSql.Append("Demo=@Demo,");
			strSql.Append("Flag_Audit=@Flag_Audit,");
			strSql.Append("Flag_Print=@Flag_Print");
			strSql.Append(" where ReportID=@ReportID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@SampleNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatType", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatName", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatSex", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatAge", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatDept", MySqlDbType.VarChar,255),
					new MySqlParameter("@BedNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@RoomNo", MySqlDbType.VarChar,255),
					new MySqlParameter("@PatBirthday", MySqlDbType.VarChar,255),
					new MySqlParameter("@SampleType", MySqlDbType.VarChar,255),
					new MySqlParameter("@SendDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@SendDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestName", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@CheckDocID", MySqlDbType.VarChar,255),
					new MySqlParameter("@CheckDocName", MySqlDbType.VarChar,255),
					new MySqlParameter("@Diagnosis", MySqlDbType.VarChar,255),
					new MySqlParameter("@Demo", MySqlDbType.VarChar,255),
					new MySqlParameter("@Flag_Audit", MySqlDbType.Int32,11),
					new MySqlParameter("@Flag_Print", MySqlDbType.Int32,11),
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.Barcode;
			parameters[1].Value = model.SampleNo;
			parameters[2].Value = model.PatType;
			parameters[3].Value = model.PatName;
			parameters[4].Value = model.PatSex;
			parameters[5].Value = model.PatAge;
			parameters[6].Value = model.PatDept;
			parameters[7].Value = model.BedNo;
			parameters[8].Value = model.RoomNo;
			parameters[9].Value = model.PatBirthday;
			parameters[10].Value = model.SampleType;
			parameters[11].Value = model.SendDocID;
			parameters[12].Value = model.SendDocName;
			parameters[13].Value = model.TestID;
			parameters[14].Value = model.TestName;
			parameters[15].Value = model.TestDocID;
			parameters[16].Value = model.TestDocName;
			parameters[17].Value = model.CheckDocID;
			parameters[18].Value = model.CheckDocName;
			parameters[19].Value = model.Diagnosis;
			parameters[20].Value = model.Demo;
			parameters[21].Value = model.Flag_Audit;
			parameters[22].Value = model.Flag_Print;
			parameters[23].Value = model.ReportID;

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
		public bool Delete(string ReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.report_main ");
			strSql.Append(" where ReportID=@ReportID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = ReportID;

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
		public bool DeleteList(string ReportIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.report_main ");
			strSql.Append(" where ReportID in ("+ReportIDlist + ")  ");
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
		public Maticsoft.Model.report_main GetModel(string ReportID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportID,Barcode,SampleNo,PatType,PatName,PatSex,PatAge,PatDept,BedNo,RoomNo,PatBirthday,SampleType,SendDocID,SendDocName,TestID,TestName,TestDocID,TestDocName,CheckDocID,CheckDocName,Diagnosis,Demo,Flag_Audit,Flag_Print from lismain.report_main ");
			strSql.Append(" where ReportID=@ReportID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ReportID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = ReportID;

			Maticsoft.Model.report_main model=new Maticsoft.Model.report_main();
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
		public Maticsoft.Model.report_main DataRowToModel(DataRow row)
		{
			Maticsoft.Model.report_main model=new Maticsoft.Model.report_main();
			if (row != null)
			{
				if(row["ReportID"]!=null)
				{
					model.ReportID=row["ReportID"].ToString();
				}
				if(row["Barcode"]!=null)
				{
					model.Barcode=row["Barcode"].ToString();
				}
				if(row["SampleNo"]!=null)
				{
					model.SampleNo=row["SampleNo"].ToString();
				}
				if(row["PatType"]!=null)
				{
					model.PatType=row["PatType"].ToString();
				}
				if(row["PatName"]!=null)
				{
					model.PatName=row["PatName"].ToString();
				}
				if(row["PatSex"]!=null)
				{
					model.PatSex=row["PatSex"].ToString();
				}
				if(row["PatAge"]!=null)
				{
					model.PatAge=row["PatAge"].ToString();
				}
				if(row["PatDept"]!=null)
				{
					model.PatDept=row["PatDept"].ToString();
				}
				if(row["BedNo"]!=null)
				{
					model.BedNo=row["BedNo"].ToString();
				}
				if(row["RoomNo"]!=null)
				{
					model.RoomNo=row["RoomNo"].ToString();
				}
				if(row["PatBirthday"]!=null)
				{
					model.PatBirthday=row["PatBirthday"].ToString();
				}
				if(row["SampleType"]!=null)
				{
					model.SampleType=row["SampleType"].ToString();
				}
				if(row["SendDocID"]!=null)
				{
					model.SendDocID=row["SendDocID"].ToString();
				}
				if(row["SendDocName"]!=null)
				{
					model.SendDocName=row["SendDocName"].ToString();
				}
				if(row["TestID"]!=null)
				{
					model.TestID=row["TestID"].ToString();
				}
				if(row["TestName"]!=null)
				{
					model.TestName=row["TestName"].ToString();
				}
				if(row["TestDocID"]!=null)
				{
					model.TestDocID=row["TestDocID"].ToString();
				}
				if(row["TestDocName"]!=null)
				{
					model.TestDocName=row["TestDocName"].ToString();
				}
				if(row["CheckDocID"]!=null)
				{
					model.CheckDocID=row["CheckDocID"].ToString();
				}
				if(row["CheckDocName"]!=null)
				{
					model.CheckDocName=row["CheckDocName"].ToString();
				}
				if(row["Diagnosis"]!=null)
				{
					model.Diagnosis=row["Diagnosis"].ToString();
				}
				if(row["Demo"]!=null)
				{
					model.Demo=row["Demo"].ToString();
				}
				if(row["Flag_Audit"]!=null && row["Flag_Audit"].ToString()!="")
				{
					model.Flag_Audit=int.Parse(row["Flag_Audit"].ToString());
				}
				if(row["Flag_Print"]!=null && row["Flag_Print"].ToString()!="")
				{
					model.Flag_Print=int.Parse(row["Flag_Print"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetLeftList()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ReportID,SampleNo,PatName,PatSex,PatAge ");
			strSql.Append(" FROM lismain.report_main ");
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ReportID,Barcode,SampleNo,PatType,PatName,PatSex,PatAge,PatDept,BedNo,RoomNo,PatBirthday,SampleType,SendDocID,SendDocName,TestID,TestName,TestDocID,TestDocName,CheckDocID,CheckDocName,Diagnosis,Demo,Flag_Audit,Flag_Print ");
			strSql.Append(" FROM lismain.report_main ");
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
			strSql.Append("select count(1) FROM lismain.report_main ");
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
				strSql.Append("order by T.ReportID desc");
			}
			strSql.Append(")AS Row, T.*  from lismain.report_main T ");
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
			parameters[0].Value = "report_main";
			parameters[1].Value = "ReportID";
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


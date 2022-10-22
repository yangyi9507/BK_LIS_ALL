using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:report_main_unaudit
	/// </summary>
	public partial class report_main_unaudit
	{
		public report_main_unaudit()
		{}
		#region  BasicMethod
		public bool ExistsByBarcode(string Barcode)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from lismain.report_main_unaudit");
			strSql.Append(" where Barcode=@Barcode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,255)            };
			parameters[0].Value = Barcode;

			return DbHelperMySQL.Exists(strSql.ToString(), parameters);
		}

		public DataTable QueryByBarcode(string Barcode)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select REPORT_ID from lismain.report_main_unaudit");
			strSql.Append(" where Barcode=@Barcode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Barcode", MySqlDbType.VarChar,255)            };
			parameters[0].Value = Barcode;

			return DbHelperMySQL.Query(strSql.ToString(), parameters).Tables[0];
		}

		public DataTable QueryBySampleNo(string SampleNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select REPORT_ID from lismain.report_main_unaudit");
			strSql.Append(" where SampleNo=@SampleNo ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SampleNo", MySqlDbType.VarChar,255)            };
			parameters[0].Value = SampleNo;

			return DbHelperMySQL.Query(strSql.ToString(), parameters).Tables[0];
		}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool ExistsBySampleNo(string sampleNo)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from lismain.report_main_unaudit");
			strSql.Append(" where SAMPLENO=@SAMPLENO ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SAMPLENO", MySqlDbType.VarChar,255)           };
			parameters[0].Value = sampleNo;

			return DbHelperMySQL.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string REPORT_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from lismain.report_main_unaudit");
			strSql.Append(" where REPORT_ID=@REPORT_ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = REPORT_ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.report_main_unaudit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into lismain.report_main_unaudit(");
			strSql.Append("REPORT_ID,RptTypeID,REPORT_NAME,BARCODE,REG_TYPE,CREATE_DATE,BarcodeTime,RegTime,KeyNo_Group,OUT_PAT_ID,PAT_ID,PAT_NO,PAT_IN_HOS_ID,PAT_NAME,PAT_SEX,PAT_AGE,PAT_AGEUnit,PAT_Birthday,PAT_Type,PAT_DEPTID,PAT_DEPTName,ROOM,BED,TestMemo,REQ_NO,REQ_DOC,DoctorID,DoctorName,INSTRUMENT,TEST_DATE,SAMPLENO,SAMPLEType,TestList,TEST_UserID,TEST_User,CHECK_UserID,CHECK_User,REPORT_TIME,HOSPITAL_ID,FALG_Emergency,FLAG_PRINT_LAB,DocMemo,CardNO,PAT_IDCARD,Send_UserID,Send_User,Diagnosis,Address,Telephone,BloodType,RefGroupID)");
			strSql.Append(" values (");
			strSql.Append("@REPORT_ID,@RptTypeID,@REPORT_NAME,@BARCODE,@REG_TYPE,@CREATE_DATE,@BarcodeTime,@RegTime,@KeyNo_Group,@OUT_PAT_ID,@PAT_ID,@PAT_NO,@PAT_IN_HOS_ID,@PAT_NAME,@PAT_SEX,@PAT_AGE,@PAT_AGEUnit,@PAT_Birthday,@PAT_Type,@PAT_DEPTID,@PAT_DEPTName,@ROOM,@BED,@TestMemo,@REQ_NO,@REQ_DOC,@DoctorID,@DoctorName,@INSTRUMENT,@TEST_DATE,@SAMPLENO,@SAMPLEType,@TestList,@TEST_UserID,@TEST_User,@CHECK_UserID,@CHECK_User,@REPORT_TIME,@HOSPITAL_ID,@FALG_Emergency,@FLAG_PRINT_LAB,@DocMemo,@CardNO,@PAT_IDCARD,@Send_UserID,@Send_User,@Diagnosis,@Address,@Telephone,@BloodType,@RefGroupID)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@RptTypeID", MySqlDbType.Int32,4),
					new MySqlParameter("@REPORT_NAME", MySqlDbType.VarChar,50),
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255),
					new MySqlParameter("@REG_TYPE", MySqlDbType.Int32,4),
					new MySqlParameter("@CREATE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BarcodeTime", MySqlDbType.DateTime),
					new MySqlParameter("@RegTime", MySqlDbType.DateTime),
					new MySqlParameter("@KeyNo_Group", MySqlDbType.VarChar,255),
					new MySqlParameter("@OUT_PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_IN_HOS_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_SEX", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGE", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGEUnit", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_Birthday", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_Type", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_DEPTID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_DEPTName", MySqlDbType.VarChar,255),
					new MySqlParameter("@ROOM", MySqlDbType.VarChar,255),
					new MySqlParameter("@BED", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestMemo", MySqlDbType.VarChar,255),
					new MySqlParameter("@REQ_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@REQ_DOC", MySqlDbType.VarChar,255),
					new MySqlParameter("@DoctorID", MySqlDbType.VarChar,255),
					new MySqlParameter("@DoctorName", MySqlDbType.VarChar,255),
					new MySqlParameter("@INSTRUMENT", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@SAMPLENO", MySqlDbType.VarChar,255),
					new MySqlParameter("@SAMPLEType", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestList", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHECK_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHECK_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@REPORT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@HOSPITAL_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@FALG_Emergency", MySqlDbType.Int32,11),
					new MySqlParameter("@FLAG_PRINT_LAB", MySqlDbType.Int32,4),
					new MySqlParameter("@DocMemo", MySqlDbType.VarChar,255),
					new MySqlParameter("@CardNO", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_IDCARD", MySqlDbType.VarChar,255),
					new MySqlParameter("@Send_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@Send_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@Diagnosis", MySqlDbType.VarChar,255),
					new MySqlParameter("@Address", MySqlDbType.VarChar,255),
					new MySqlParameter("@Telephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@BloodType", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefGroupID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = model.REPORT_ID;
			parameters[1].Value = model.RptTypeID;
			parameters[2].Value = model.REPORT_NAME;
			parameters[3].Value = model.BARCODE;
			parameters[4].Value = model.REG_TYPE;
			parameters[5].Value = model.CREATE_DATE;
			parameters[6].Value = model.BarcodeTime;
			parameters[7].Value = model.RegTime;
			parameters[8].Value = model.KeyNo_Group;
			parameters[9].Value = model.OUT_PAT_ID;
			parameters[10].Value = model.PAT_ID;
			parameters[11].Value = model.PAT_NO;
			parameters[12].Value = model.PAT_IN_HOS_ID;
			parameters[13].Value = model.PAT_NAME;
			parameters[14].Value = model.PAT_SEX;
			parameters[15].Value = model.PAT_AGE;
			parameters[16].Value = model.PAT_AGEUnit;
			parameters[17].Value = model.PAT_Birthday;
			parameters[18].Value = model.PAT_Type;
			parameters[19].Value = model.PAT_DEPTID;
			parameters[20].Value = model.PAT_DEPTName;
			parameters[21].Value = model.ROOM;
			parameters[22].Value = model.BED;
			parameters[23].Value = model.TestMemo;
			parameters[24].Value = model.REQ_NO;
			parameters[25].Value = model.REQ_DOC;
			parameters[26].Value = model.DoctorID;
			parameters[27].Value = model.DoctorName;
			parameters[28].Value = model.INSTRUMENT;
			parameters[29].Value = model.TEST_DATE;
			parameters[30].Value = model.SAMPLENO;
			parameters[31].Value = model.SAMPLEType;
			parameters[32].Value = model.TestList;
			parameters[33].Value = model.TEST_UserID;
			parameters[34].Value = model.TEST_User;
			parameters[35].Value = model.CHECK_UserID;
			parameters[36].Value = model.CHECK_User;
			parameters[37].Value = model.REPORT_TIME;
			parameters[38].Value = model.HOSPITAL_ID;
			parameters[39].Value = model.FALG_Emergency;
			parameters[40].Value = model.FLAG_PRINT_LAB;
			parameters[41].Value = model.DocMemo;
			parameters[42].Value = model.CardNO;
			parameters[43].Value = model.PAT_IDCARD;

			parameters[44].Value = model.Send_UserID;
			parameters[45].Value = model.Send_User;
			parameters[46].Value = model.Diagnosis;

			parameters[47].Value = model.Address;
			parameters[48].Value = model.Telephone;
			parameters[49].Value = model.BloodType;
			parameters[50].Value = model.RefGroupID;

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
		public bool Update(Maticsoft.Model.report_main_unaudit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update lismain.report_main_unaudit set ");
			strSql.Append("RptTypeID=@RptTypeID,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("BARCODE=@BARCODE,");
			strSql.Append("REG_TYPE=@REG_TYPE,");
			strSql.Append("CREATE_DATE=@CREATE_DATE,");
			strSql.Append("BarcodeTime=@BarcodeTime,");
			strSql.Append("RegTime=@RegTime,");
			strSql.Append("KeyNo_Group=@KeyNo_Group,");
			strSql.Append("OUT_PAT_ID=@OUT_PAT_ID,");
			strSql.Append("PAT_ID=@PAT_ID,");
			strSql.Append("PAT_NO=@PAT_NO,");
			strSql.Append("PAT_IN_HOS_ID=@PAT_IN_HOS_ID,");
			strSql.Append("PAT_NAME=@PAT_NAME,");
			strSql.Append("PAT_SEX=@PAT_SEX,");
			strSql.Append("PAT_AGE=@PAT_AGE,");
			strSql.Append("PAT_AGEUnit=@PAT_AGEUnit,");
			strSql.Append("PAT_Birthday=@PAT_Birthday,");
			strSql.Append("PAT_Type=@PAT_Type,");
			strSql.Append("PAT_DEPTID=@PAT_DEPTID,");
			strSql.Append("PAT_DEPTName=@PAT_DEPTName,");
			strSql.Append("ROOM=@ROOM,");
			strSql.Append("BED=@BED,");
			strSql.Append("TestMemo=@TestMemo,");
			strSql.Append("REQ_NO=@REQ_NO,");
			strSql.Append("REQ_DOC=@REQ_DOC,");
			strSql.Append("DoctorID=@DoctorID,");
			strSql.Append("DoctorName=@DoctorName,");
			strSql.Append("INSTRUMENT=@INSTRUMENT,");
			strSql.Append("TEST_DATE=@TEST_DATE,");
			strSql.Append("SAMPLENO=@SAMPLENO,");
			strSql.Append("SAMPLEType=@SAMPLEType,");
			strSql.Append("TestList=@TestList,");
			strSql.Append("TEST_UserID=@TEST_UserID,");
			strSql.Append("TEST_User=@TEST_User,");
			strSql.Append("CHECK_UserID=@CHECK_UserID,");
			strSql.Append("CHECK_User=@CHECK_User,");
			strSql.Append("REPORT_TIME=@REPORT_TIME,");
			strSql.Append("HOSPITAL_ID=@HOSPITAL_ID,");
			strSql.Append("FALG_Emergency=@FALG_Emergency,");
			strSql.Append("FLAG_PRINT_LAB=@FLAG_PRINT_LAB,");
			strSql.Append("DocMemo=@DocMemo,");
			strSql.Append("CardNO=@CardNO,");
			strSql.Append("PAT_IDCARD=@PAT_IDCARD,");
			strSql.Append("Send_UserID=@Send_UserID,");
			strSql.Append("Send_User=@Send_User,");
			strSql.Append("Diagnosis=@Diagnosis,");
			strSql.Append("Address=@Address,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("BloodType=@BloodType,");
			strSql.Append("RefGroupID=@RefGroupID");
			strSql.Append(" where REPORT_ID=@REPORT_ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RptTypeID", MySqlDbType.Int32,4),
					new MySqlParameter("@REPORT_NAME", MySqlDbType.VarChar,50),
					new MySqlParameter("@BARCODE", MySqlDbType.VarChar,255),
					new MySqlParameter("@REG_TYPE", MySqlDbType.Int32,4),
					new MySqlParameter("@CREATE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BarcodeTime", MySqlDbType.DateTime),
					new MySqlParameter("@RegTime", MySqlDbType.DateTime),
					new MySqlParameter("@KeyNo_Group", MySqlDbType.VarChar,255),
					new MySqlParameter("@OUT_PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_IN_HOS_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_NAME", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_SEX", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGE", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_AGEUnit", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_Birthday", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_Type", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_DEPTID", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_DEPTName", MySqlDbType.VarChar,255),
					new MySqlParameter("@ROOM", MySqlDbType.VarChar,255),
					new MySqlParameter("@BED", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestMemo", MySqlDbType.VarChar,255),
					new MySqlParameter("@REQ_NO", MySqlDbType.VarChar,255),
					new MySqlParameter("@REQ_DOC", MySqlDbType.VarChar,255),
					new MySqlParameter("@DoctorID", MySqlDbType.VarChar,255),
					new MySqlParameter("@DoctorName", MySqlDbType.VarChar,255),
					new MySqlParameter("@INSTRUMENT", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@SAMPLENO", MySqlDbType.VarChar,255),
					new MySqlParameter("@SAMPLEType", MySqlDbType.VarChar,255),
					new MySqlParameter("@TestList", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@TEST_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHECK_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@CHECK_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@REPORT_TIME", MySqlDbType.DateTime),
					new MySqlParameter("@HOSPITAL_ID", MySqlDbType.VarChar,255),
					new MySqlParameter("@FALG_Emergency", MySqlDbType.Int32,11),
					new MySqlParameter("@FLAG_PRINT_LAB", MySqlDbType.Int32,4),
					new MySqlParameter("@DocMemo", MySqlDbType.VarChar,255),
					new MySqlParameter("@CardNO", MySqlDbType.VarChar,255),
					new MySqlParameter("@PAT_IDCARD", MySqlDbType.VarChar,255),
					new MySqlParameter("@Send_UserID", MySqlDbType.VarChar,255),
					new MySqlParameter("@Send_User", MySqlDbType.VarChar,255),
					new MySqlParameter("@Diagnosis", MySqlDbType.VarChar,255),
					new MySqlParameter("@Address", MySqlDbType.VarChar,255),
					new MySqlParameter("@Telephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@BloodType", MySqlDbType.VarChar,255),
					new MySqlParameter("@RefGroupID",MySqlDbType.Int32,4),
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.RptTypeID;
			parameters[1].Value = model.REPORT_NAME;
			parameters[2].Value = model.BARCODE;
			parameters[3].Value = model.REG_TYPE;
			parameters[4].Value = model.CREATE_DATE;
			parameters[5].Value = model.BarcodeTime;
			parameters[6].Value = model.RegTime;
			parameters[7].Value = model.KeyNo_Group;
			parameters[8].Value = model.OUT_PAT_ID;
			parameters[9].Value = model.PAT_ID;
			parameters[10].Value = model.PAT_NO;
			parameters[11].Value = model.PAT_IN_HOS_ID;
			parameters[12].Value = model.PAT_NAME;
			parameters[13].Value = model.PAT_SEX;
			parameters[14].Value = model.PAT_AGE;
			parameters[15].Value = model.PAT_AGEUnit;
			parameters[16].Value = model.PAT_Birthday;
			parameters[17].Value = model.PAT_Type;
			parameters[18].Value = model.PAT_DEPTID;
			parameters[19].Value = model.PAT_DEPTName;
			parameters[20].Value = model.ROOM;
			parameters[21].Value = model.BED;
			parameters[22].Value = model.TestMemo;
			parameters[23].Value = model.REQ_NO;
			parameters[24].Value = model.REQ_DOC;
			parameters[25].Value = model.DoctorID;
			parameters[26].Value = model.DoctorName;
			parameters[27].Value = model.INSTRUMENT;
			parameters[28].Value = model.TEST_DATE;
			parameters[29].Value = model.SAMPLENO;
			parameters[30].Value = model.SAMPLEType;
			parameters[31].Value = model.TestList;
			parameters[32].Value = model.TEST_UserID;
			parameters[33].Value = model.TEST_User;
			parameters[34].Value = model.CHECK_UserID;
			parameters[35].Value = model.CHECK_User;
			parameters[36].Value = model.REPORT_TIME;
			parameters[37].Value = model.HOSPITAL_ID;
			parameters[38].Value = model.FALG_Emergency;
			parameters[39].Value = model.FLAG_PRINT_LAB;
			parameters[40].Value = model.DocMemo;
			parameters[41].Value = model.CardNO;
			parameters[42].Value = model.PAT_IDCARD;
			parameters[43].Value = model.Send_UserID;
			parameters[44].Value = model.Send_User;
			parameters[45].Value = model.Diagnosis;
			parameters[46].Value = model.Address;
			parameters[47].Value = model.Telephone;
			parameters[48].Value = model.BloodType;
			parameters[49].Value = model.RefGroupID;
			parameters[50].Value = model.REPORT_ID;

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
		public bool Delete(string REPORT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from lismain.report_main_unaudit ");
			strSql.Append(" where REPORT_ID=@REPORT_ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = REPORT_ID;

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
		public bool DeleteList(string REPORT_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from report_main_unaudit ");
			strSql.Append(" where REPORT_ID in ("+REPORT_IDlist + ")  ");
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
		public Maticsoft.Model.report_main GetAuditModel(string REPORT_ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select REPORT_ID,RptTypeID,REPORT_NAME,BARCODE,REG_TYPE,CREATE_DATE,BarcodeTime,RegTime,KeyNo_Group,OUT_PAT_ID,PAT_ID,PAT_NO,PAT_IN_HOS_ID,PAT_NAME,PAT_SEX,PAT_AGE,PAT_AGEUnit,PAT_Birthday,PAT_Type,PAT_DEPTID,PAT_DEPTName,ROOM,BED,TestMemo,REQ_NO,REQ_DOC,DoctorID,DoctorName,INSTRUMENT,TEST_DATE,SAMPLENO,SAMPLEType,TestList,TEST_UserID,TEST_User,CHECK_UserID,CHECK_User,REPORT_TIME,HOSPITAL_ID,FALG_Emergency,FLAG_PRINT_LAB,DocMemo,CardNO,PAT_IDCARD,Send_UserID,Send_User, Diagnosis,Address,Telephone,BloodType,RefGroupID ,B.DicItemName  from lismain.report_main_unaudit AS  A ");
			strSql.Append(" LEFT JOIN lismain.classtype AS B ON A.RefGroupID = B.DicItemCode AND DicCode = 4");
			strSql.Append(" where REPORT_ID=@REPORT_ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255)           };
			parameters[0].Value = REPORT_ID;

			Maticsoft.Model.report_main_unaudit model = new Maticsoft.Model.report_main_unaudit();
			DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
			if (ds.Tables[0].Rows.Count > 0)
			{
				return AuditDataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.report_main_unaudit GetModel(string REPORT_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select REPORT_ID,RptTypeID,REPORT_NAME,BARCODE,REG_TYPE,CREATE_DATE,BarcodeTime,RegTime,KeyNo_Group,OUT_PAT_ID,PAT_ID,PAT_NO,PAT_IN_HOS_ID,PAT_NAME,PAT_SEX,PAT_AGE,PAT_AGEUnit,PAT_Birthday,PAT_Type,PAT_DEPTID,PAT_DEPTName,ROOM,BED,TestMemo,REQ_NO,REQ_DOC,DoctorID,DoctorName,INSTRUMENT,TEST_DATE,SAMPLENO,SAMPLEType,TestList,TEST_UserID,TEST_User,CHECK_UserID,CHECK_User,REPORT_TIME,HOSPITAL_ID,FALG_Emergency,FLAG_PRINT_LAB,DocMemo,CardNO,PAT_IDCARD,Send_UserID,Send_User, Diagnosis,Address,Telephone,BloodType,RefGroupID ,B.DicItemName  from lismain.report_main_unaudit AS  A ");
			strSql.Append(" LEFT JOIN lismain.classtype AS B ON A.RefGroupID = B.DicItemCode AND DicCode = 4");
			strSql.Append(" where REPORT_ID=@REPORT_ID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@REPORT_ID", MySqlDbType.VarChar,255)			};
			parameters[0].Value = REPORT_ID;

			Maticsoft.Model.report_main_unaudit model=new Maticsoft.Model.report_main_unaudit();
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
		public Maticsoft.Model.report_main AuditDataRowToModel(DataRow row)
		{
			Maticsoft.Model.report_main model = new Maticsoft.Model.report_main();
			if (row != null)
			{
				if (row["REPORT_ID"] != null)
				{
					model.REPORT_ID = row["REPORT_ID"].ToString();
				}
				if (row["RptTypeID"] != null && row["RptTypeID"].ToString() != "")
				{
					model.RptTypeID = int.Parse(row["RptTypeID"].ToString());
				}
				if (row["REPORT_NAME"] != null)
				{
					model.REPORT_NAME = row["REPORT_NAME"].ToString();
				}
				if (row["BARCODE"] != null)
				{
					model.BARCODE = row["BARCODE"].ToString();
				}
				if (row["RefGroupID"] != null && row["RefGroupID"].ToString() != "")
				{
					model.RefGroupID = int.Parse(row["RefGroupID"].ToString());
				}
				if (row["REG_TYPE"] != null && row["REG_TYPE"].ToString() != "")
				{
					model.REG_TYPE = int.Parse(row["REG_TYPE"].ToString());
				}
				if (row["CREATE_DATE"] != null && row["CREATE_DATE"].ToString() != "")
				{
					model.CREATE_DATE = DateTime.Parse(row["CREATE_DATE"].ToString());
				}
				if (row["BarcodeTime"] != null && row["BarcodeTime"].ToString() != "")
				{
					model.BarcodeTime = DateTime.Parse(row["BarcodeTime"].ToString());
				}
				if (row["RegTime"] != null && row["RegTime"].ToString() != "")
				{
					model.RegTime = DateTime.Parse(row["RegTime"].ToString());
				}
				if (row["KeyNo_Group"] != null)
				{
					model.KeyNo_Group = row["KeyNo_Group"].ToString();
				}
				if (row["OUT_PAT_ID"] != null)
				{
					model.OUT_PAT_ID = row["OUT_PAT_ID"].ToString();
				}
				if (row["PAT_ID"] != null)
				{
					model.PAT_ID = row["PAT_ID"].ToString();
				}
				if (row["PAT_NO"] != null)
				{
					model.PAT_NO = row["PAT_NO"].ToString();
				}
				if (row["PAT_IN_HOS_ID"] != null)
				{
					model.PAT_IN_HOS_ID = row["PAT_IN_HOS_ID"].ToString();
				}
				if (row["PAT_NAME"] != null)
				{
					model.PAT_NAME = row["PAT_NAME"].ToString();
				}
				if (row["PAT_SEX"] != null)
				{
					model.PAT_SEX = row["PAT_SEX"].ToString();
				}
				if (row["PAT_AGE"] != null)
				{
					model.PAT_AGE = row["PAT_AGE"].ToString();
				}
				if (row["PAT_AGEUnit"] != null)
				{
					model.PAT_AGEUnit = row["PAT_AGEUnit"].ToString();
				}
				if (row["PAT_Birthday"] != null)
				{
					model.PAT_Birthday = row["PAT_Birthday"].ToString();
				}
				if (row["PAT_Type"] != null)
				{
					model.PAT_Type = row["PAT_Type"].ToString();
				}
				if (row["PAT_DEPTID"] != null)
				{
					model.PAT_DEPTID = row["PAT_DEPTID"].ToString();
				}
				if (row["PAT_DEPTName"] != null)
				{
					model.PAT_DEPTName = row["PAT_DEPTName"].ToString();
				}
				if (row["ROOM"] != null)
				{
					model.ROOM = row["ROOM"].ToString();
				}
				if (row["BED"] != null)
				{
					model.BED = row["BED"].ToString();
				}
				if (row["TestMemo"] != null)
				{
					model.TestMemo = row["TestMemo"].ToString();
				}
				if (row["REQ_NO"] != null)
				{
					model.REQ_NO = row["REQ_NO"].ToString();
				}
				if (row["REQ_DOC"] != null)
				{
					model.REQ_DOC = row["REQ_DOC"].ToString();
				}
				if (row["DoctorID"] != null)
				{
					model.DoctorID = row["DoctorID"].ToString();
				}
				if (row["DoctorName"] != null)
				{
					model.DoctorName = row["DoctorName"].ToString();
				}
				if (row["INSTRUMENT"] != null)
				{
					model.INSTRUMENT = row["INSTRUMENT"].ToString();
				}
				if (row["TEST_DATE"] != null && row["TEST_DATE"].ToString() != "")
				{
					model.TEST_DATE = DateTime.Parse(row["TEST_DATE"].ToString());
				}
				if (row["SAMPLENO"] != null)
				{
					model.SAMPLENO = row["SAMPLENO"].ToString();
				}
				if (row["SAMPLEType"] != null)
				{
					model.SAMPLEType = row["SAMPLEType"].ToString();
				}
				if (row["TestList"] != null)
				{
					model.TestList = row["TestList"].ToString();
				}
				if (row["TEST_UserID"] != null)
				{
					model.TEST_UserID = row["TEST_UserID"].ToString();
				}
				if (row["TEST_User"] != null)
				{
					model.TEST_User = row["TEST_User"].ToString();
				}
				if (row["CHECK_UserID"] != null)
				{
					model.CHECK_UserID = row["CHECK_UserID"].ToString();
				}
				if (row["CHECK_User"] != null)
				{
					model.CHECK_User = row["CHECK_User"].ToString();
				}
				if (row["Send_UserID"] != null)
				{
					model.Send_UserID = row["Send_UserID"].ToString();
				}
				if (row["Send_User"] != null)
				{
					model.Send_User = row["Send_User"].ToString();
				}
				if (row["REPORT_TIME"] != null && row["REPORT_TIME"].ToString() != "")
				{
					model.REPORT_TIME = DateTime.Parse(row["REPORT_TIME"].ToString());
				}
				if (row["HOSPITAL_ID"] != null)
				{
					model.HOSPITAL_ID = row["HOSPITAL_ID"].ToString();
				}
				if (row["FALG_Emergency"] != null && row["FALG_Emergency"].ToString() != "")
				{
					model.FALG_Emergency = int.Parse(row["FALG_Emergency"].ToString());
				}
				if (row["FLAG_PRINT_LAB"] != null && row["FLAG_PRINT_LAB"].ToString() != "")
				{
					model.FLAG_PRINT_LAB = int.Parse(row["FLAG_PRINT_LAB"].ToString());
				}
				if (row["DocMemo"] != null)
				{
					model.DocMemo = row["DocMemo"].ToString();
				}
				if (row["CardNO"] != null)
				{
					model.CardNO = row["CardNO"].ToString();
				}
				if (row["PAT_IDCARD"] != null)
				{
					model.PAT_IDCARD = row["PAT_IDCARD"].ToString();
				}
				if (row["Diagnosis"] != null)
				{
					model.Diagnosis = row["Diagnosis"].ToString();
				}
				if (row["Address"] != null)
				{
					model.Address = row["Address"].ToString();
				}
				if (row["Telephone"] != null)
				{
					model.Telephone = row["Telephone"].ToString();
				}
				if (row["BloodType"] != null)
				{
					model.BloodType = row["BloodType"].ToString();
				}
				if (row["DicItemName"] != null)
				{
					model.DicItemName = row["DicItemName"].ToString();
				}

			}
			return model;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.report_main_unaudit DataRowToModel(DataRow row)
		{
			Maticsoft.Model.report_main_unaudit model=new Maticsoft.Model.report_main_unaudit();
			if (row != null)
			{
				if(row["REPORT_ID"]!=null)
				{
					model.REPORT_ID=row["REPORT_ID"].ToString();
				}
				if(row["RptTypeID"]!=null && row["RptTypeID"].ToString()!="")
				{
					model.RptTypeID=int.Parse(row["RptTypeID"].ToString());
				}
				if(row["REPORT_NAME"]!=null)
				{
					model.REPORT_NAME=row["REPORT_NAME"].ToString();
				}
				if(row["BARCODE"]!=null)
				{
					model.BARCODE=row["BARCODE"].ToString();
				}
				if (row["RefGroupID"] != null && row["RefGroupID"].ToString() != "")
				{
					model.RefGroupID = int.Parse(row["RefGroupID"].ToString());
				}
				if (row["REG_TYPE"]!=null && row["REG_TYPE"].ToString()!="")
				{
					model.REG_TYPE=int.Parse(row["REG_TYPE"].ToString());
				}
				if(row["CREATE_DATE"]!=null && row["CREATE_DATE"].ToString()!="")
				{
					model.CREATE_DATE=DateTime.Parse(row["CREATE_DATE"].ToString());
				}
				if(row["BarcodeTime"]!=null && row["BarcodeTime"].ToString()!="")
				{
					model.BarcodeTime=DateTime.Parse(row["BarcodeTime"].ToString());
				}
				if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(row["RegTime"].ToString());
				}
				if(row["KeyNo_Group"]!=null)
				{
					model.KeyNo_Group=row["KeyNo_Group"].ToString();
				}
				if(row["OUT_PAT_ID"]!=null)
				{
					model.OUT_PAT_ID=row["OUT_PAT_ID"].ToString();
				}
				if(row["PAT_ID"]!=null)
				{
					model.PAT_ID=row["PAT_ID"].ToString();
				}
				if(row["PAT_NO"]!=null)
				{
					model.PAT_NO=row["PAT_NO"].ToString();
				}
				if(row["PAT_IN_HOS_ID"]!=null)
				{
					model.PAT_IN_HOS_ID=row["PAT_IN_HOS_ID"].ToString();
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
				if(row["PAT_AGEUnit"]!=null)
				{
					model.PAT_AGEUnit=row["PAT_AGEUnit"].ToString();
				}
				if(row["PAT_Birthday"]!=null)
				{
					model.PAT_Birthday=row["PAT_Birthday"].ToString();
				}
				if(row["PAT_Type"]!=null)
				{
					model.PAT_Type=row["PAT_Type"].ToString();
				}
				if(row["PAT_DEPTID"]!=null)
				{
					model.PAT_DEPTID=row["PAT_DEPTID"].ToString();
				}
				if(row["PAT_DEPTName"]!=null)
				{
					model.PAT_DEPTName=row["PAT_DEPTName"].ToString();
				}
				if(row["ROOM"]!=null)
				{
					model.ROOM=row["ROOM"].ToString();
				}
				if(row["BED"]!=null)
				{
					model.BED=row["BED"].ToString();
				}
				if(row["TestMemo"]!=null)
				{
					model.TestMemo=row["TestMemo"].ToString();
				}
				if(row["REQ_NO"]!=null)
				{
					model.REQ_NO=row["REQ_NO"].ToString();
				}
				if(row["REQ_DOC"]!=null)
				{
					model.REQ_DOC=row["REQ_DOC"].ToString();
				}
				if(row["DoctorID"]!=null)
				{
					model.DoctorID=row["DoctorID"].ToString();
				}
				if(row["DoctorName"]!=null)
				{
					model.DoctorName=row["DoctorName"].ToString();
				}
				if(row["INSTRUMENT"]!=null)
				{
					model.INSTRUMENT=row["INSTRUMENT"].ToString();
				}
				if(row["TEST_DATE"]!=null && row["TEST_DATE"].ToString()!="")
				{
					model.TEST_DATE=DateTime.Parse(row["TEST_DATE"].ToString());
				}
				if(row["SAMPLENO"]!=null)
				{
					model.SAMPLENO=row["SAMPLENO"].ToString();
				}
				if(row["SAMPLEType"]!=null)
				{
					model.SAMPLEType=row["SAMPLEType"].ToString();
				}
				if(row["TestList"]!=null)
				{
					model.TestList=row["TestList"].ToString();
				}
				if(row["TEST_UserID"]!=null)
				{
					model.TEST_UserID=row["TEST_UserID"].ToString();
				}
				if(row["TEST_User"]!=null)
				{
					model.TEST_User=row["TEST_User"].ToString();
				}
				if(row["CHECK_UserID"]!=null)
				{
					model.CHECK_UserID=row["CHECK_UserID"].ToString();
				}
				if(row["CHECK_User"]!=null)
				{
					model.CHECK_User=row["CHECK_User"].ToString();
				}
				if (row["Send_UserID"] != null)
				{
					model.Send_UserID = row["Send_UserID"].ToString();
				}
				if (row["Send_User"] != null)
				{
					model.Send_User = row["Send_User"].ToString();
				}
				if (row["REPORT_TIME"]!=null && row["REPORT_TIME"].ToString()!="")
				{
					model.REPORT_TIME=DateTime.Parse(row["REPORT_TIME"].ToString());
				}
				if(row["HOSPITAL_ID"]!=null)
				{
					model.HOSPITAL_ID=row["HOSPITAL_ID"].ToString();
				}
				if(row["FALG_Emergency"]!=null && row["FALG_Emergency"].ToString()!="")
				{
					model.FALG_Emergency=int.Parse(row["FALG_Emergency"].ToString());
				}
				if(row["FLAG_PRINT_LAB"]!=null && row["FLAG_PRINT_LAB"].ToString()!="")
				{
					model.FLAG_PRINT_LAB=int.Parse(row["FLAG_PRINT_LAB"].ToString());
				}
				if(row["DocMemo"]!=null)
				{
					model.DocMemo=row["DocMemo"].ToString();
				}
				if(row["CardNO"]!=null)
				{
					model.CardNO=row["CardNO"].ToString();
				}
				if(row["PAT_IDCARD"]!=null)
				{
					model.PAT_IDCARD=row["PAT_IDCARD"].ToString();
				}
				if (row["Diagnosis"] != null)
				{
					model.Diagnosis = row["Diagnosis"].ToString();
				}
				if (row["Address"] != null)
				{
					model.Address = row["Address"].ToString();
				}
				if (row["Telephone"] != null)
				{
					model.Telephone = row["Telephone"].ToString();
				}
				if (row["BloodType"] != null)
				{
					model.BloodType = row["BloodType"].ToString();
				}
				if (row["DicItemName"] != null)
				{
					model.DicItemName = row["DicItemName"].ToString();
				}
				
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetLeftList(string strWhere,string FlgAudit)
		{
			StringBuilder strSql = new StringBuilder();
			if (FlgAudit == "")
			{
				
				strSql.Append("select KeyNo_Group,SAMPLENO,PAT_NAME,PAT_SEX, CONCAT(PAT_AGE,PAT_AGEUnit) AS PatAgeNumber,1 AS AuditFlg ");
				strSql.Append(" ,CASE FLAG_PRINT_LAB WHEN '0' THEN '未打印' WHEN '1' THEN '打印' END");
				strSql.Append(" FROM lismain.report_main A");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
				strSql.Append(" UNION ALL ");
				strSql.Append("select KeyNo_Group,SAMPLENO,PAT_NAME,PAT_SEX, CONCAT(PAT_AGE,PAT_AGEUnit) AS PatAgeNumber,0 AS AuditFlg ");
				strSql.Append(" ,CASE FLAG_PRINT_LAB WHEN '0' THEN '未打印' WHEN '1' THEN '打印' END");
				strSql.Append(" FROM lismain.report_main_unaudit B");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
			}
			else if (FlgAudit == "0")
			{
				
				strSql.Append("select KeyNo_Group,SAMPLENO,PAT_NAME,PAT_SEX, CONCAT(PAT_AGE,PAT_AGEUnit) AS PatAgeNumber,0 AS AuditFlg ");
				strSql.Append(" ,CASE FLAG_PRINT_LAB WHEN '0' THEN '未打印' WHEN '1' THEN '打印' END");
				strSql.Append(" FROM lismain.report_main_unaudit ");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
			}
			else if (FlgAudit == "1") 
			{				
				strSql.Append("select KeyNo_Group,SAMPLENO,PAT_NAME,PAT_SEX, CONCAT(PAT_AGE,PAT_AGEUnit) AS PatAgeNumber,1 AS AuditFlg ");
				strSql.Append(" ,CASE FLAG_PRINT_LAB WHEN '0' THEN '未打印' WHEN '1' THEN '打印' END");
				strSql.Append(" FROM lismain.report_main ");
				if (strWhere.Trim() != "")
				{
					strSql.Append(" where " + strWhere);
				}
			}

			return DbHelperMySQL.Query(strSql.ToString());
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select REPORT_ID,RptTypeID,REPORT_NAME,BARCODE,REG_TYPE,CREATE_DATE,BarcodeTime,RegTime,KeyNo_Group,OUT_PAT_ID,PAT_ID,PAT_NO,PAT_IN_HOS_ID,PAT_NAME,PAT_SEX,PAT_AGE,PAT_AGEUnit,PAT_Birthday,PAT_Type,PAT_DEPTID,PAT_DEPTName,ROOM,BED,TestMemo,REQ_NO,REQ_DOC,DoctorID,DoctorName,INSTRUMENT,TEST_DATE,SAMPLENO,SAMPLEType,TestList,TEST_UserID,TEST_User,CHECK_UserID,CHECK_User,REPORT_TIME,HOSPITAL_ID,FALG_Emergency,FLAG_PRINT_LAB,DocMemo,CardNO,PAT_IDCARD,Send_UserID,Send_User ,Diagnosis,Address,Telephone,BloodType,RefGroupID");
			strSql.Append(" FROM lismain.report_main_unaudit ");
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
			strSql.Append("select count(1) FROM lismain.report_main_unaudit ");
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
				strSql.Append("order by T.REPORT_ID desc");
			}
			strSql.Append(")AS Row, T.*  from lismain.report_main_unaudit T ");
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
			parameters[0].Value = "report_main_unaudit";
			parameters[1].Value = "REPORT_ID";
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


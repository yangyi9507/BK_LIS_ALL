using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// report_main_unaudit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class report_main_unaudit
	{
		public report_main_unaudit()
		{}
		#region Model
		private string _report_id;
		private int? _rpttypeid;
		private string _report_name;
		private string _barcode;
		private int? _reg_type;
		private DateTime? _create_date;
		private DateTime? _barcodetime;
		private DateTime? _regtime;
		private string _keyno_group;
		private string _out_pat_id;
		private string _pat_id;
		private string _pat_no;
		private string _pat_in_hos_id;
		private string _pat_name;
		private string _pat_sex;
		private string _pat_age;
		private string _pat_ageunit;
		private string _pat_birthday;
		private string _pat_type;
		private string _pat_deptid;
		private string _pat_deptname;
		private string _room;
		private string _bed;
		private string _testmemo;
		private string _req_no;
		private string _req_doc;
		private string _doctorid;
		private string _doctorname;
		private string _instrument;
		private DateTime? _test_date;
		private string _sampleno;
		private string _sampletype;
		private string _testlist;
		private string _test_userid;
		private string _test_user;
		private string _check_userid;
		private string _check_user;
		private string _send_userid;
		private string _send_user;
		private DateTime? _report_time;
		private string _hospital_id;
		private int? _falg_emergency;
		private int? _flag_print_lab;
		private string _docmemo;
		private string _cardno;
		private string _pat_idcard;
		private string _diagnosis;
        private string _address;
        private string _bloodType;
        private string _telephone;

        /// <summary>
        /// 
        /// </summary>
        public string REPORT_ID
		{
			set{ _report_id=value;}
			get{return _report_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RptTypeID
		{
			set{ _rpttypeid=value;}
			get{return _rpttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_NAME
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BARCODE
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? REG_TYPE
		{
			set{ _reg_type=value;}
			get{return _reg_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_DATE
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BarcodeTime
		{
			set{ _barcodetime=value;}
			get{return _barcodetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyNo_Group
		{
			set{ _keyno_group=value;}
			get{return _keyno_group;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OUT_PAT_ID
		{
			set{ _out_pat_id=value;}
			get{return _out_pat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_ID
		{
			set{ _pat_id=value;}
			get{return _pat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_NO
		{
			set{ _pat_no=value;}
			get{return _pat_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_IN_HOS_ID
		{
			set{ _pat_in_hos_id=value;}
			get{return _pat_in_hos_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_NAME
		{
			set{ _pat_name=value;}
			get{return _pat_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_SEX
		{
			set{ _pat_sex=value;}
			get{return _pat_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_AGE
		{
			set{ _pat_age=value;}
			get{return _pat_age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_AGEUnit
		{
			set{ _pat_ageunit=value;}
			get{return _pat_ageunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_Birthday
		{
			set{ _pat_birthday=value;}
			get{return _pat_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_Type
		{
			set{ _pat_type=value;}
			get{return _pat_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_DEPTID
		{
			set{ _pat_deptid=value;}
			get{return _pat_deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_DEPTName
		{
			set{ _pat_deptname=value;}
			get{return _pat_deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ROOM
		{
			set{ _room=value;}
			get{return _room;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BED
		{
			set{ _bed=value;}
			get{return _bed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestMemo
		{
			set{ _testmemo=value;}
			get{return _testmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REQ_NO
		{
			set{ _req_no=value;}
			get{return _req_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REQ_DOC
		{
			set{ _req_doc=value;}
			get{return _req_doc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoctorID
		{
			set{ _doctorid=value;}
			get{return _doctorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DoctorName
		{
			set{ _doctorname=value;}
			get{return _doctorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string INSTRUMENT
		{
			set{ _instrument=value;}
			get{return _instrument;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? TEST_DATE
		{
			set{ _test_date=value;}
			get{return _test_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SAMPLENO
		{
			set{ _sampleno=value;}
			get{return _sampleno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SAMPLEType
		{
			set{ _sampletype=value;}
			get{return _sampletype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestList
		{
			set{ _testlist=value;}
			get{return _testlist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEST_UserID
		{
			set{ _test_userid=value;}
			get{return _test_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TEST_User
		{
			set{ _test_user=value;}
			get{return _test_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHECK_UserID
		{
			set{ _check_userid=value;}
			get{return _check_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHECK_User
		{
			set{ _check_user=value;}
			get{return _check_user;}
		}


		/// <summary>
		/// 
		/// </summary>
		public string Send_UserID
		{
			set { _send_userid = value; }
			get { return _send_userid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Send_User
		{
			set { _send_user = value; }
			get { return _send_user; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? REPORT_TIME
		{
			set{ _report_time=value;}
			get{return _report_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HOSPITAL_ID
		{
			set{ _hospital_id=value;}
			get{return _hospital_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FALG_Emergency
		{
			set{ _falg_emergency=value;}
			get{return _falg_emergency;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FLAG_PRINT_LAB
		{
			set{ _flag_print_lab=value;}
			get{return _flag_print_lab;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DocMemo
		{
			set{ _docmemo=value;}
			get{return _docmemo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardNO
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAT_IDCARD
		{
			set{ _pat_idcard=value;}
			get{return _pat_idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Diagnosis
		{
			set { _diagnosis = value; }
			get { return _diagnosis; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set { _address = value; }
			get { return _address; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set { _telephone = value; }
			get { return _telephone; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string BloodType
		{
			set { _bloodType = value; }
			get { return _bloodType; }
		}
		#endregion Model

	}
}


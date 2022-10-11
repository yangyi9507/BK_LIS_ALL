using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// report_main:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class report_main
	{
		public report_main()
		{}
		#region Model
		private string _reportid;
		private string _barcode;
		private string _sampleno;
		private string _pattype;
		private string _patname;
		private string _patsex;
		private string _patage;
		private string _patdept;
		private string _bedno;
		private string _roomno;
		private string _patbirthday;
		private string _sampletype;
		private string _senddocid;
		private string _senddocname;
		private string _testid;
		private string _testname;
		private string _testdocid;
		private string _testdocname;
		private string _checkdocid;
		private string _checkdocname;
		private string _diagnosis;
		private string _demo;
		private string _address;
		private string _telephone;
		private string _patid;
		private string _testtime;
		private string _sendtime;
		private string _recievetime;
		private int? _flag_audit;
		private int? _flag_print;
		/// <summary>
		/// 
		/// </summary>
		public string ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Barcode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleNo
		{
			set{ _sampleno=value;}
			get{return _sampleno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatType
		{
			set{ _pattype=value;}
			get{return _pattype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatName
		{
			set{ _patname=value;}
			get{return _patname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatSex
		{
			set{ _patsex=value;}
			get{return _patsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatAge
		{
			set{ _patage=value;}
			get{return _patage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatDept
		{
			set{ _patdept=value;}
			get{return _patdept;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BedNo
		{
			set{ _bedno=value;}
			get{return _bedno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoomNo
		{
			set{ _roomno=value;}
			get{return _roomno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PatBirthday
		{
			set{ _patbirthday=value;}
			get{return _patbirthday;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string TestTime
		{
			set { _testtime = value; }
			get { return _testtime; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string SendTime
		{
			set { _sendtime = value; }
			get { return _sendtime; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string RecieveTime
		{
			set { _recievetime = value; }
			get { return _recievetime; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string SampleType
		{
			set{ _sampletype=value;}
			get{return _sampletype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendDocID
		{
			set{ _senddocid=value;}
			get{return _senddocid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendDocName
		{
			set{ _senddocname=value;}
			get{return _senddocname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestID
		{
			set{ _testid=value;}
			get{return _testid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestName
		{
			set{ _testname=value;}
			get{return _testname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestDocID
		{
			set{ _testdocid=value;}
			get{return _testdocid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestDocName
		{
			set{ _testdocname=value;}
			get{return _testdocname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckDocID
		{
			set{ _checkdocid=value;}
			get{return _checkdocid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckDocName
		{
			set{ _checkdocname=value;}
			get{return _checkdocname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Diagnosis
		{
			set{ _diagnosis=value;}
			get{return _diagnosis;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string TelePhone
		{
			set { _telephone = value; }
			get { return _telephone; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string PatId
		{
			set { _patid = value; }
			get { return _patid; }
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
		public string Demo
		{
			set{ _demo=value;}
			get{return _demo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Flag_Audit
		{
			set{ _flag_audit=value;}
			get{return _flag_audit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Flag_Print
		{
			set{ _flag_print=value;}
			get{return _flag_print;}
		}
		#endregion Model

	}
}


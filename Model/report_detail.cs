using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// report_detail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class report_detail
	{
		public report_detail()
		{}
		#region Model
		private string _reportid;
		private string _itemno;
		private string _itemname;
		private string _result;
		private string _units;
		private string _RefRange;
		private string _abnormal_flg;
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
		public string ItemNo
		{
			set{ _itemno=value;}
			get{return _itemno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Units
		{
			set{ _units=value;}
			get{return _units;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RefRange
		{
			set{ _RefRange = value;}
			get{return _RefRange; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Abnormal_Flg
		{
			set{ _abnormal_flg=value;}
			get{return _abnormal_flg;}
		}
		#endregion Model

	}
}


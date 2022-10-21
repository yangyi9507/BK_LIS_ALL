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
		private decimal? _rpt_detailid;
		private string _report_id;
		private string _keyno_group;
		private string _item_id;
		private string _item_name;
		private string _item_ename;
		private string _unit;
		private string _refrange;
		private string _range_high;
		private string _range_low;
		private string _result;
		private string _abnormal_flg;
		private DateTime? _reslt_time;
		private int? _sno;
		private int? _printno;
		private int? _gno;
		private string _charge_no;
		/// <summary>
		/// 
		/// </summary>
		public decimal? Rpt_DetailID
		{
			set{ _rpt_detailid=value;}
			get{return _rpt_detailid;}
		}
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
		public string KeyNo_Group
		{
			set{ _keyno_group=value;}
			get{return _keyno_group;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_ID
		{
			set{ _item_id=value;}
			get{return _item_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_NAME
		{
			set{ _item_name=value;}
			get{return _item_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ITEM_ENAME
		{
			set{ _item_ename=value;}
			get{return _item_ename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UNIT
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RefRange
		{
			set{ _refrange=value;}
			get{return _refrange;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RANGE_HIGH
		{
			set{ _range_high=value;}
			get{return _range_high;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RANGE_LOW
		{
			set{ _range_low=value;}
			get{return _range_low;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RESULT
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Abnormal_flg
		{
			set{ _abnormal_flg=value;}
			get{return _abnormal_flg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RESLT_TIME
		{
			set{ _reslt_time=value;}
			get{return _reslt_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SNO
		{
			set{ _sno=value;}
			get{return _sno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PrintNo
		{
			set{ _printno=value;}
			get{return _printno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GNO
		{
			set{ _gno=value;}
			get{return _gno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CHARGE_No
		{
			set{ _charge_no=value;}
			get{return _charge_no;}
		}
		#endregion Model

	}
}


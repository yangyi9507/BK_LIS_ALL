using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// dept:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dept
	{
		public Dept()
		{}
		#region Model
		private int _id;
		private string _deptid;
		private string _deptname;
		private string _deptnamepy;
		private string _deptmemo;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptNamePy
		{
			set{ _deptnamepy=value;}
			get{return _deptnamepy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptMemo
		{
			set{ _deptmemo=value;}
			get{return _deptmemo;}
		}
		#endregion Model

	}
}


using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// doctor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class doctor
	{
		public doctor()
		{}
		#region Model
		private int _id;
		private string _docid;
		private string _docname;
		private string _deptid;
		private string _deptname;
		private string _docnamepy;
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
		public string DocID
		{
			set{ _docid=value;}
			get{return _docid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DocName
		{
			set{ _docname=value;}
			get{return _docname;}
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
		public string DocNamePy
		{
			set{ _docnamepy=value;}
			get{return _docnamepy;}
		}
		#endregion Model

	}
}


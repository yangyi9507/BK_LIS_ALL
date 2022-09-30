using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// classtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class classtype
	{
		public classtype()
		{}
		#region Model
		private int _id;
		private string _diccode;
		private string _dicname;
		private string _dicitemcode;
		private string _dicitemname;
		private string _dicitemnamepy;
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
		public string DicCode
		{
			set{ _diccode=value;}
			get{return _diccode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DicName
		{
			set{ _dicname=value;}
			get{return _dicname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DicItemCode
		{
			set{ _dicitemcode=value;}
			get{return _dicitemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DicItemName
		{
			set{ _dicitemname=value;}
			get{return _dicitemname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DicItemNamePy
		{
			set{ _dicitemnamepy=value;}
			get{return _dicitemnamepy;}
		}
		#endregion Model

	}
}


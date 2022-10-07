using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// testlist:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class testlist
	{
		public testlist()
		{}
		#region Model
		private int _id;
		private string _itemclasscode;
		private string _itemclassname;
		private string _itemcode;
		private string _itemname;
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
		public string ItemClassCode
		{
			set{ _itemclasscode=value;}
			get{return _itemclasscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemClassName
		{
			set{ _itemclassname=value;}
			get{return _itemclassname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemCode
		{
			set{ _itemcode=value;}
			get{return _itemcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		#endregion Model

	}
}


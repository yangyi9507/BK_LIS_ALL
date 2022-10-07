using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// item:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class item
	{
		public item()
		{}
		#region Model
		private int _id;
		private string _itemno;
		private string _itemname;
		private int _cno;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		public int CNo
		{
			set{ _cno=value;}
			get{return _cno;}
		}
		#endregion Model

	}
}


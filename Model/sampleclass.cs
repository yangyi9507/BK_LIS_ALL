using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// sampleclass:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sampleclass
	{
		public sampleclass()
		{}
		#region Model
		private int _id;
		private string _classcode;
		private string _classname;
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
		public string ClassCode
		{
			set{ _classcode=value;}
			get{return _classcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Classname
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		#endregion Model

	}
}


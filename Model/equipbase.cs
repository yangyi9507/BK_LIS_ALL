using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// equipbase:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class equipbase
	{
		public equipbase()
		{}
		#region Model
		private int _id;
		private string _equipcode;
		private string _equipname;
		private string _equiptype;
		private string _ip;
		private string _port;
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
		public string EquipCode
		{
			set{ _equipcode=value;}
			get{return _equipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EquipName
		{
			set{ _equipname=value;}
			get{return _equipname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EquipType
		{
			set{ _equiptype=value;}
			get{return _equiptype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Port
		{
			set{ _port=value;}
			get{return _port;}
		}
		#endregion Model

	}
}


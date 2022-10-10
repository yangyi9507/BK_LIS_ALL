using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// report_graph:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class report_graph
	{
		public report_graph()
		{}
		#region Model
		private string _reportid;
		private string _graph;
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
		public string Graph
		{
			set{ _graph=value;}
			get{return _graph;}
		}
		#endregion Model

	}
}


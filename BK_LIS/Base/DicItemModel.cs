using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_LIS.Base
{
    public partial class DicItemModel : UIPage
    {
        public DicItemModel()
        {
            InitializeComponent();

            GetLeftData();

            GetRightData();

        }

        #region 初始化加载项目大类数据
        public void GetLeftData()
        {
            Maticsoft.BLL.sampleclass sampleclassDal = new Maticsoft.BLL.sampleclass();  //声明对象          
            uiDataGridView1.DataSource = sampleclassDal.GetAllList().Tables[0];//赋值

            //设置列的列标题
            uiDataGridView1.Columns[0].HeaderText = "ID";
            uiDataGridView1.Columns[1].HeaderText = "项目编码";
            uiDataGridView1.Columns[2].HeaderText = "项目名称";
        }
        #endregion


        #region 初始化加载检验项目数据
        public void GetRightData()
        {
            Maticsoft.BLL.item itemDal = new Maticsoft.BLL.item();  //声明对象          
            uiDataGridView2.DataSource = itemDal.GetAllList().Tables[0];//赋值

            //设置列的列标题
            uiDataGridView2.Columns[0].HeaderText = "ID";
            uiDataGridView2.Columns[1].HeaderText = "项目编码";
            uiDataGridView2.Columns[2].HeaderText = "项目名称";
            uiDataGridView2.Columns[2].HeaderText = "序号";
        }

        #endregion

        #region 检验项目查询
        private void uiButton4_Click(object sender, EventArgs e)
        {
            Maticsoft.BLL.item itemDal = new Maticsoft.BLL.item();  //声明对象
            
            string strWhere = "";
            strWhere = " ItemNo Like '%" + uitextBox1.Text + "%' OR ItemName Like '%" + uitextBox1.Text + "%'";

            uiDataGridView2.ClearAll();                    
            uiDataGridView2.DataSource = itemDal.GetList(strWhere).Tables[0];//赋值

            //设置列的列标题
            uiDataGridView2.Columns[0].HeaderText = "ID";
            uiDataGridView2.Columns[1].HeaderText = "项目编码";
            uiDataGridView2.Columns[2].HeaderText = "项目名称";
            uiDataGridView2.Columns[2].HeaderText = "序号";
        }
        #endregion
    }
}

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

namespace BK_LIS
{
    public partial class ReportMain : UIPage
    {
        public ReportMain()
        {
            InitializeComponent();

            GetItemClassName();//初始化获取项目大类
        }

        #region 获取项目大类
        public void GetItemClassName() 
        {
            Maticsoft.BLL.testlist testlist = new Maticsoft.BLL.testlist();  //声明对象                      
            uiComboBox1.DataSource = testlist.GetDicCode().Tables[0];//赋值

            uiComboBox1.DisplayMember = "ItemClassName";
            uiComboBox1.ValueMember = "ItemClassCode";

            //uiComboBox1.SelectedValue = dataGridView1.Rows[0].Cells[3].Value.ToString();
        }
        #endregion
    }
}

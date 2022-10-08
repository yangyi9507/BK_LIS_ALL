using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using comm;
using Maticsoft.Model;
using Maticsoft.BLL;

namespace BK_LIS.Pages
{
    public partial class SFLReportMain : UIPage
    {
        string strReportID = "";
        public SFLReportMain()
        {
            InitializeComponent();

            GetLeftData();//加载网格数据
        }


        #region 初始化加载数据
        public void GetLeftData()
        {
            Maticsoft.BLL.report_main report_mainDal = new Maticsoft.BLL.report_main();  //声明对象          
            uiDataGridView1.DataSource = report_mainDal.GetLeftList().Tables[0];//赋值

            //设置列的列标题
            uiDataGridView1.Columns[0].HeaderText = "报告单号";
            uiDataGridView1.Columns[1].HeaderText = "样本号";
            uiDataGridView1.Columns[2].HeaderText = "姓名";
            uiDataGridView1.Columns[3].HeaderText = "性别";
            uiDataGridView1.Columns[4].HeaderText = "年龄";
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                strReportID = uiDataGridView1.Rows[index].Cells[0].Value.ToString();//用于查询对应数据内容


                Maticsoft.BLL.report_main report_mainDal = new Maticsoft.BLL.report_main();  //声明对象          
                Maticsoft.Model.report_main main =  report_mainDal.GetModel(strReportID);//赋值

                #region 页面上方控件赋值
                uiSampleNotext.Text = main.SampleNo;
                uiTextBox2.Text = main.SampleType;//样本类型
                uiTextBox3.Text = main.Barcode;//病历号
                uiTextBox5.Text = main.TestDocName;//检验医师
                uiTextBox25.Text = main.PatName;//姓名
                uiTextBox1.Text = main.PatSex;//性别
                uiTextBox23.Text = main.PatBirthday;//生日
                uiTextBox22.Text = main.PatAge;//年龄
                uiTextBox19.Text = main.CheckDocName;//审核医生
                uiTextBox6.Text = main.PatDept;//科室
                uiTextBox7.Text = main.RoomNo;//房间号
                uiTextBox21.Text = main.BedNo;//床号
                uiTextBox4.Text = main.SendDocName;//送检人员
                uiTextBox10.Text = main.Demo;//备注
                #endregion

                #region 根据报告单获取明细
                Maticsoft.BLL.report_detail report_detailDal = new Maticsoft.BLL.report_detail();  //声明对象
                string strWhere = "ReportId = '"+ strReportID + "'";
                uiDataGridView2.DataSource = report_detailDal.GetRightList(strWhere).Tables[0];//赋值
                //设置列的列标题
                uiDataGridView2.Columns[0].HeaderText = "项目编号";
                uiDataGridView2.Columns[1].HeaderText = "项目名称";
                uiDataGridView2.Columns[2].HeaderText = "结果";
                uiDataGridView2.Columns[3].HeaderText = "单位";
                uiDataGridView2.Columns[4].HeaderText = "参考范围";
                uiDataGridView2.Columns[5].HeaderText = "报警表示";

                #endregion

            };
        }
        #endregion
    }
}

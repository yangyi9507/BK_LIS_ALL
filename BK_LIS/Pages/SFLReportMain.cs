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
using System.IO;

namespace BK_LIS.Pages
{
    public partial class SFLReportMain : UIPage
    {
        string strReportID = "";
        string INSTRUMENT = "SFL";
        public SFLReportMain()
        {
            InitializeComponent();

            GetLeftData();//加载网格数据
        }


        #region 初始化加载数据
        public void GetLeftData()
        {
            Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象

            string strWhere = "INSTRUMENT = '" + INSTRUMENT + "'";
            uiDataGridView1.DataSource = report_main_unauditDal.GetLeftList(strWhere).Tables[0];//赋值

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


                Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象          
                Maticsoft.Model.report_main_unaudit main = report_main_unauditDal.GetModel(strReportID);//赋值

                #region 页面上方控件赋值
                uiSampleNotext.Text = main.SAMPLENO;
                uiTextBox2.Text = main.SAMPLEType;//样本类型
                uiTextBox3.Text = main.PAT_NO;//病历号
                uiTextBox5.Text = main.TEST_User;//检验医师
                uiTextBox25.Text = main.PAT_NAME;//姓名
                uiTextBox1.Text = main.PAT_SEX;//性别
                uiTextBox23.Text = main.PAT_Birthday;//生日
                uiTextBox22.Text = main.PAT_AGE;//年龄
                uiTextBox8.Text = main.PAT_AGEUnit;//年龄单位
                uiTextBox19.Text = main.CHECK_User;//审核医生
                uiTextBox6.Text = main.PAT_DEPTName;//科室
                uiTextBox7.Text = main.ROOM;//病室
                uiTextBox21.Text = main.BED;//床号
                uiTextBox4.Text = main.Send_User;//送检人员
                uiTextBox10.Text = main.DocMemo;//备注
                #endregion

                #region 根据报告单获取明细
                Maticsoft.BLL.report_detail_undudit report_detail_unduditDal = new Maticsoft.BLL.report_detail_undudit();  //声明对象
                string strWhere = "KeyNo_Group = '" + strReportID + "'";
                uiDataGridView2.DataSource = report_detail_unduditDal.GetRightList(strWhere).Tables[0];//赋值
                //设置列的列标题
                uiDataGridView2.Columns[0].HeaderText = "项目编号";
                uiDataGridView2.Columns[1].HeaderText = "项目名称";
                uiDataGridView2.Columns[2].HeaderText = "结果";
                uiDataGridView2.Columns[3].HeaderText = "单位";
                uiDataGridView2.Columns[4].HeaderText = "参考范围";
                uiDataGridView2.Columns[5].HeaderText = "报警表示";

                #endregion

                #region 读取数据库 base64编码的图片
                byte[] bytefile;
                Maticsoft.BLL.report_graph report_graph = new Maticsoft.BLL.report_graph();  //声明对象               
                strWhere = "ReportId = '" + strReportID + "'";
                DataTable dt = report_graph.GetList(strWhere).Tables[0];//赋值
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bytefile = Convert.FromBase64String(dt.Rows[i]["Graph"].ToString());//编码转图片
                        MemoryStream ms = new MemoryStream(bytefile);
                        Image img = Image.FromStream(ms);
                        if (i == 0) { this.pictureBox1.Image = img; }
                        else if (i == 1) { this.pictureBox2.Image = img; }
                        else if (i == 2) { this.pictureBox3.Image = img; }
                    }

                }
                else { this.pictureBox1.Image = null; this.pictureBox2.Image = null; this.pictureBox3.Image = null; }

                #endregion

            };
        }
        #endregion

        private void uiButton1_Click(object sender, EventArgs e)
        {
            GetLeftData();//加载网格数据
        }
    }
}

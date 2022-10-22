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
using FastReport;
using FastReport.Data;
using System.Configuration;

namespace BK_LIS.Pages
{
    public partial class SFLReportMain : UIPage
    {         
        string strReportID = "";
        string AuditFLg = "";//0:未审核；1：审核
        public SFLReportMain()
        {
            InitializeComponent();

            GetLeftData();//加载网格数据
        }


        #region 初始化加载数据
        public void GetLeftData()
        {
            Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象

            string strWhere = "";
            string strAuditFlg = "";//是否查看审核报告的标志
            switch (uiComboBox3.SelectedIndex)
            {
                case 0: break;
                case 1: strWhere += "INSTRUMENT = 'SFL'"; break;
                case 2: strWhere += "INSTRUMENT = 'TDDB'"; break;                
            }
            switch (uiComboBox1.SelectedIndex)
            {
                case 0: break;
                case 1: strAuditFlg = "0"; AuditFLg = "0"; break;
                case 2: strAuditFlg = "1"; AuditFLg = "1"; break;
            }
            uiDataGridView1.DataSource = report_main_unauditDal.GetLeftList(strWhere, strAuditFlg).Tables[0];//赋值

            //设置列的列标题
            uiDataGridView1.Columns[0].HeaderText = "报告单号";
            uiDataGridView1.Columns[1].HeaderText = "样本号";
            uiDataGridView1.Columns[2].HeaderText = "姓名";
            uiDataGridView1.Columns[3].HeaderText = "性别";
            uiDataGridView1.Columns[4].HeaderText = "年龄";
            uiDataGridView1.Columns[5].HeaderText = "是否审核";
            uiDataGridView1.Columns[5].Visible = false;
            uiDataGridView1.Columns[6].HeaderText = "是否打印";    
            
            for (int i = 0; i < uiDataGridView1.RowCount; i++)
            {
                if (uiDataGridView1.Rows[i].Cells[5].Value.ToString() == "1") 
                {
                    uiDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;
                }                
            }
            
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                strReportID = uiDataGridView1.Rows[index].Cells[0].Value.ToString();//用于查询对应数据内容

                if (uiDataGridView1.Rows[index].Cells[5].Value.ToString() == "0")
                {
                    AuditFLg = "0";
                    Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象          
                    Maticsoft.Model.report_main_unaudit main = report_main_unauditDal.GetModel(strReportID);//赋值
                    if (main == null) { return; }
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
                }
                else if (uiDataGridView1.Rows[index].Cells[5].Value.ToString() == "1") 
                {
                    AuditFLg = "1";
                    Maticsoft.BLL.report_main report_main_unauditDal = new Maticsoft.BLL.report_main();  //声明对象          
                    Maticsoft.Model.report_main main = report_main_unauditDal.GetModel(strReportID);//赋值
                    if (main == null) { return; }
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
                }



            };
        }
        #endregion

        private void uiButton1_Click(object sender, EventArgs e)
        {
            GetLeftData();//加载网格数据
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Report fastReport = new Report();
            fastReport.Load(Application.StartupPath + "\\A4.frx");
            if (AuditFLg == "1")
            {
                Maticsoft.BLL.report_main report_mainDal = new Maticsoft.BLL.report_main();  //声明对象          
                Maticsoft.Model.report_main main = report_mainDal.GetModel(strReportID);//赋值

                if (main != null)
                {
                    main.FLAG_PRINT_LAB = 1;
                    report_mainDal.Update(main);

                    fastReport.SetParameterValue("SampleNo", main.SAMPLENO);
                    fastReport.SetParameterValue("hosno", main.PAT_NO);
                    fastReport.SetParameterValue("Bedno", main.BED);
                    fastReport.SetParameterValue("PatientName", main.PAT_NAME);
                    fastReport.SetParameterValue("Sex", main.PAT_SEX);
                    fastReport.SetParameterValue("Age", main.PAT_AGE + main.PAT_AGEUnit);
                    fastReport.SetParameterValue("SampleType", main.SAMPLEType);
                    fastReport.SetParameterValue("value", main.DicItemName);
                    fastReport.SetParameterValue("InspectionDepartment", main.PAT_DEPTName);
                    fastReport.SetParameterValue("senderdoctor", main.Send_User);
                    fastReport.SetParameterValue("checkDoctor", main.TEST_User);
                    fastReport.SetParameterValue("checked", main.CHECK_User);
                    fastReport.SetParameterValue("Test Date", main.TEST_DATE);
                    fastReport.SetParameterValue("Report Date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                    Maticsoft.BLL.report_detail_undudit report_detailDal = new Maticsoft.BLL.report_detail_undudit();  //声明对象
                    string strWhere = "Report_Id = '" + strReportID + "'";

                    DataTable dt = report_detailDal.GetReportList(strWhere).Tables[0];

                    DataSet ds = new DataSet();
                    DataTable fr_dt = new DataTable();
                    fr_dt.TableName = "tdResult";
                    fr_dt.Columns.Add("ITEM_EName", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("RESULT", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("UNIT", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("REFRANGE", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("Abnormal_flg", typeof(String));//*****列名设置需要与标签模板一致*****

                    int Detailcount = int.Parse(ConfigurationManager.AppSettings["SFLCount"].ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Add里面参数的数据顺序要和dt中的列的顺序对应 
                        fastReport.SetParameterValue("SampleType" + i, dt.Rows[i]["ITEM_EName"].ToString());
                        fastReport.SetParameterValue("Result" + i, dt.Rows[i]["RESULT"].ToString());
                        fastReport.SetParameterValue("Unit" + i, dt.Rows[i]["UNIT"].ToString());
                        fastReport.SetParameterValue("Reference" + i, dt.Rows[i]["REFRANGE"].ToString());
                        fastReport.SetParameterValue("prompt" + i, dt.Rows[i]["Abnormal_flg"].ToString());
                    }
                    if (Detailcount - dt.Rows.Count > 0)
                    {
                        for (int i = dt.Rows.Count; i <= Detailcount; i++)
                        {
                            fastReport.SetParameterValue("SampleType" + i, "");
                            fastReport.SetParameterValue("Result" + i, "");
                            fastReport.SetParameterValue("Unit" + i, "");
                            fastReport.SetParameterValue("Reference" + i, "");
                            fastReport.SetParameterValue("prompt" + i, "");
                        }

                    }
                    ds.Tables.Add(fr_dt);
                    fastReport.RegisterData(ds);
                    fastReport.Prepare();
                    fastReport.ShowPrepared();



                }
            }
            else {
                Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象          
                Maticsoft.Model.report_main_unaudit main = report_main_unauditDal.GetModel(strReportID);//赋值

                if (main != null)
                {
                    main.FLAG_PRINT_LAB = 1;
                    report_main_unauditDal.Update(main);

                    fastReport.SetParameterValue("SampleNo", main.SAMPLENO);
                    fastReport.SetParameterValue("hosno", main.PAT_NO);
                    fastReport.SetParameterValue("Bedno", main.BED);
                    fastReport.SetParameterValue("PatientName", main.PAT_NAME);
                    fastReport.SetParameterValue("Sex", main.PAT_SEX);
                    fastReport.SetParameterValue("Age", main.PAT_AGE + main.PAT_AGEUnit);
                    fastReport.SetParameterValue("SampleType", main.SAMPLEType);
                    fastReport.SetParameterValue("value", main.DicItemName);
                    fastReport.SetParameterValue("InspectionDepartment", main.PAT_DEPTName);
                    fastReport.SetParameterValue("senderdoctor", main.Send_User);
                    fastReport.SetParameterValue("checkDoctor", main.TEST_User);
                    fastReport.SetParameterValue("checked", main.CHECK_User);
                    fastReport.SetParameterValue("Test Date", main.TEST_DATE);
                    fastReport.SetParameterValue("Report Date", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                    Maticsoft.BLL.report_detail_undudit report_detailDal = new Maticsoft.BLL.report_detail_undudit();  //声明对象
                    string strWhere = "Report_Id = '" + strReportID + "'";

                    DataTable dt = report_detailDal.GetReportList(strWhere).Tables[0];

                    DataSet ds = new DataSet();
                    DataTable fr_dt = new DataTable();
                    fr_dt.TableName = "tdResult";
                    fr_dt.Columns.Add("ITEM_EName", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("RESULT", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("UNIT", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("REFRANGE", typeof(String));//*****列名设置需要与标签模板一致*****
                    fr_dt.Columns.Add("Abnormal_flg", typeof(String));//*****列名设置需要与标签模板一致*****

                    int Detailcount = int.Parse(ConfigurationManager.AppSettings["SFLCount"].ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Add里面参数的数据顺序要和dt中的列的顺序对应 
                        fastReport.SetParameterValue("SampleType" + i, dt.Rows[i]["ITEM_EName"].ToString());
                        fastReport.SetParameterValue("Result" + i, dt.Rows[i]["RESULT"].ToString());
                        fastReport.SetParameterValue("Unit" + i, dt.Rows[i]["UNIT"].ToString());
                        fastReport.SetParameterValue("Reference" + i, dt.Rows[i]["REFRANGE"].ToString());
                        fastReport.SetParameterValue("prompt" + i, dt.Rows[i]["Abnormal_flg"].ToString());
                    }
                    if (Detailcount - dt.Rows.Count > 0)
                    {
                        for (int i = dt.Rows.Count; i <= Detailcount; i++)
                        {
                            fastReport.SetParameterValue("SampleType" + i, "");
                            fastReport.SetParameterValue("Result" + i, "");
                            fastReport.SetParameterValue("Unit" + i, "");
                            fastReport.SetParameterValue("Reference" + i, "");
                            fastReport.SetParameterValue("prompt" + i, "");
                        }

                    }
                    ds.Tables.Add(fr_dt);
                    fastReport.RegisterData(ds);
                    fastReport.Prepare();
                    fastReport.ShowPrepared();
                }
            }


        }
        #region 审核报告
        private void uiButton3_Click(object sender, EventArgs e)
        {
            try
            {
                #region 主要报告内容   
                Maticsoft.BLL.report_main_unaudit report_main_unauditDal = new Maticsoft.BLL.report_main_unaudit();  //声明对象  
                Maticsoft.Model.report_main main = report_main_unauditDal.GetAuditModel(strReportID);//赋值
                Maticsoft.BLL.report_main report_Mainbll = new Maticsoft.BLL.report_main();  //声明对象              
                report_Mainbll.Add(main);//将数据插入已审核报告
                report_main_unauditDal.Delete(strReportID);//将未审核报告删除
                #endregion                
                GetLeftData();//加载网格数据

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}

using comm;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_LIS
{
    public partial class DataHandle : UIPage
    {
        public int ID = 0;// 初始化仪器ID


        // ------普通报告------
        string CaseNo = "";  //病例号码
        string patName = "";  //姓名
        DateTime patBirthday;  //出生年月
        string patSex = "";  //性别

        string patType = ""; //病人类型
        string deptName = ""; //科室
        string roomNo = ""; //房间
        string bedNo = ""; //床号
        string fbType = ""; //费用类型

        string strKey = "";//报告单号
        string sampleNo = "";//样本编号
        DateTime CollectTime;  //采样时间
        DateTime TestTime;  //检验时间
        string Collect_User = ""; //采集者
        string Diagion = ""; //临床诊断信息

        DateTime RecieveTime;//送检时间
        string SampleSource = "";//样本来源  BLDV”-静脉血“BLDC”-末稍血
        DateTime AuditTime;//审核时间
        string Diagnostic = "";//诊断ID 取值为“HM”，意思为 Hematology，即血液学
        string AuditUser = "";//样本审核者

        string strItemNo = "";//项目ID
        string strResult = "";//项目结果
        string strUnits = "";//单位
        string strRange = "";//参考范围
        string strResultflg = "";


        private static Socket tcpClient = null;
        public byte[] buffer = new byte[1024 * 1024 * 3];

        public DataHandle()
        {
            InitializeComponent();

            GetData();//加载网格数据
        }


        #region 初始化加载数据
        public void GetData()
        {
            Maticsoft.BLL.equipbase equipbaseDal = new Maticsoft.BLL.equipbase();  //声明对象          
            uiDataGridView1.DataSource = equipbaseDal.GetAllList().Tables[0];//赋值

            //设置列的列标题
            uiDataGridView1.Columns[0].HeaderText = "ID";
            uiDataGridView1.Columns[1].HeaderText = "仪器编码";
            uiDataGridView1.Columns[2].HeaderText = "仪器名称";
            uiDataGridView1.Columns[3].HeaderText = "仪器类别";
            uiDataGridView1.Columns[4].HeaderText = "IP";
            uiDataGridView1.Columns[5].HeaderText = "端口号";
        }
        #endregion


        #region 选中行展示数据
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.uiDataGridView1.SelectionMode != DataGridViewSelectionMode.FullColumnSelect && uiDataGridView1.CurrentRow != null)
            {
                int index = uiDataGridView1.CurrentRow.Index; //获取选中行的行号
                uiTextBox1.Text = uiDataGridView1.Rows[index].Cells[1].Value.ToString();
                uiTextBox2.Text = uiDataGridView1.Rows[index].Cells[2].Value.ToString();
                uiTextBox3.Text = uiDataGridView1.Rows[index].Cells[3].Value.ToString();
                uiTextBox4.Text = uiDataGridView1.Rows[index].Cells[5].Value.ToString();
                uiIPTextBox.Text = uiDataGridView1.Rows[index].Cells[4].Value.ToString();

                ID = int.Parse(uiDataGridView1.Rows[index].Cells[0].Value.ToString());//接收科室ID用于后续的更新
            };
        }
        #endregion


        #region 新增
        private void uiButton1_Click_1(object sender, EventArgs e)
        {
            Maticsoft.DAL.equipbase equipbaseDal = new Maticsoft.DAL.equipbase();  //声明对象


            #region 判断IP端口号是否正确 
            if (!TcpSockect.CheckIp(uiIPTextBox.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!TcpSockect.IsPositiveIntNoZero(uiTextBox4.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }
            #endregion

            #region 循环判断ID是否存在
            if (string.IsNullOrEmpty(uiTextBox1.Text)) { UIMessageTip.Show(AppCode.EMPTIY_ERROR); return; }
            for (int i = 0; i < uiDataGridView1.Rows.Count; i++)
            {
                if (uiTextBox1.Text == uiDataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    UIMessageTip.Show(AppCode.EXIT_ERROR);
                    return;
                }
            }
            #endregion

            Maticsoft.Model.equipbase equipbase = new Maticsoft.Model.equipbase
            {
                EquipCode = uiTextBox1.Text,
                EquipName = uiTextBox2.Text,
                EquipType = uiTextBox3.Text,
                Port = uiTextBox4.Text,
                IP = uiIPTextBox.Text
            };

            bool flg = equipbaseDal.Add(equipbase);
            if (flg)
            {
                UIMessageTip.Show(AppCode.INSERT_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.INSERT_ERROR);
            }

        }
        #endregion


        #region 数据刷新
        public void DataReSet()
        {
            Maticsoft.DAL.equipbase equipbaseDal = new Maticsoft.DAL.equipbase();  //声明对象
            uiDataGridView1.ClearAll();
            uiDataGridView1.DataSource = equipbaseDal.GetList("").Tables[0];//赋值            
                                                                            
            //设置列的列标题
            uiDataGridView1.Columns[0].HeaderText = "ID";
            uiDataGridView1.Columns[1].HeaderText = "仪器编码";
            uiDataGridView1.Columns[2].HeaderText = "仪器名称";
            uiDataGridView1.Columns[3].HeaderText = "仪器类别";
            uiDataGridView1.Columns[4].HeaderText = "IP";
            uiDataGridView1.Columns[5].HeaderText = "端口号";

            if (uiDataGridView1.Rows.Count == 0) 
            {
                foreach (Control control in panel3.Controls)
                {
                    if (control is UIIPTextBox || control is UITextBox)
                    {
                        control.Text = "";
                    }
                }
            }
        }
        #endregion

        #region 更新
        private void uiButton3_Click(object sender, EventArgs e)
        {
            #region 判断IP端口号是否正确 
            if (!TcpSockect.CheckIp(uiIPTextBox.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!TcpSockect.IsPositiveIntNoZero(uiTextBox4.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }
            #endregion

            Maticsoft.DAL.equipbase equipbaseDal = new Maticsoft.DAL.equipbase();  //声明对象
            Maticsoft.Model.equipbase equipbase = new Maticsoft.Model.equipbase
            {
                ID = ID,
                EquipCode = uiTextBox1.Text,
                EquipName = uiTextBox2.Text,
                EquipType = uiTextBox3.Text,
                Port = uiTextBox4.Text,
                IP = uiIPTextBox.Text,
            };

            bool flg = equipbaseDal.Update(equipbase);//更新操作
            if (flg)
            {
                UIMessageTip.Show(AppCode.UPDATE_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.UPDATE_ERROR);
            }
        }
        #endregion
        #region 删除
        private void uiButton2_Click(object sender, EventArgs e)
        {
            Maticsoft.DAL.equipbase equipbaseDal = new Maticsoft.DAL.equipbase();  //声明对象

            bool flg = equipbaseDal.Delete(ID);
            if (flg)
            {
                UIMessageTip.Show(AppCode.DELETE_SUCCESSS);
                DataReSet();
            }
            else
            {
                UIMessageTip.Show(AppCode.DELETE_ERROR);
            }
        }
        #endregion
        #region 启动链接
        private void uiButton4_Click(object sender, EventArgs e)
        {
            #region 判断IP端口号是否正确 
            if (!TcpSockect.CheckIp(uiIPTextBox.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!TcpSockect.IsPositiveIntNoZero(uiTextBox4.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }
            #endregion


            tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(uiIPTextBox.Text);
            EndPoint point = new IPEndPoint(ipaddress, int.Parse(uiTextBox4.Text));

            tcpClient.SendTimeout = 1000;
            tcpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);
            tcpClient.BeginConnect(point, new AsyncCallback(ConnectCallBack), tcpClient);            
        }
        #endregion


        #region 连接回调
        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);

                client.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);
                Console.WriteLine("Socket connect to {0}", client.RemoteEndPoint.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        #endregion

        #region   接收数据
        /// <summary>
        /// 接收数据部分
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                if (tcpClient.Connected)
                {
                    int bytesRead = tcpClient.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        byte[] haveDate = ByteToByte(buffer, bytesRead, 0);//取出有效的字节数据,得到实际的数据haveDate
                        Array.Clear(buffer, 0, buffer.Length);//情况缓冲数组

                        string strAll = TextEncoder.bytesToText(haveDate);

                        ChuLiOneHL7(strAll);//处理数据
                        strAll = "";
                        tcpClient.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//接收剩余的数据或者继续接收数据
                    }
                    else //如果接收到数据字符为0，代表接收完了
                    {
                        tcpClient.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//继续接收数据
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        #endregion

        #region 对截取到的合格拼接串进行HL7协议处理
        /// <summary>
        /// 对截取到的合格拼接串进行HL7协议处理
        /// </summary>
        /// <param name="ib_data">截取到的合格拼接串</param>
        private void ChuLiOneHL7(string ib_data)
        {
            strKey = DateTime.Now.ToString("yyyyMMddhhmmss");//报告单号

            Maticsoft.Model.report_main report_main = new Maticsoft.Model.report_main();
            Maticsoft.DAL.report_main report_mainDal = new Maticsoft.DAL.report_main();
            report_main.ReportID = strKey;

            #region 对合格串进行解析
            string[] arrayData = ib_data.Split('\n');
            for (int i = 0; i < arrayData.Length - 1; i++)
            {
                string[] arrayLine = arrayData[i].Split('|');
                switch (arrayLine[0])
                {
                    #region 消息段包含病人的基本信息
                    case "PID":
                        //PID|1||05012006^^^^MR||^张三||19991001000000|男
                        CaseNo = arrayLine[3].Split('^')[0];//病例号码
                        patName = arrayLine[5].Split('^')[1];//姓名
                        patBirthday = IsNullCheck(arrayLine[7].ToString());//出生年月
                        patSex = arrayLine[8].ToString();//性别


                        report_main.Barcode = CaseNo;
                        report_main.PatName = patName;
                        //report_main. = patBirthday;
                        report_main.PatSex = patSex;


                        break;
                    #endregion

                    #region 包含病人的看病信息。
                    case "PV1":
                        //PV1|1|住院|外科^1^2|||||||||||||||||自费  “科室^房间^床号”
                        patType = arrayLine[2].ToString();//病人类型
                        try
                        {
                            deptName = arrayLine[3].Split('^')[0];//科室
                            roomNo = arrayLine[3].Split('^')[1];//房间
                            bedNo = arrayLine[3].Split('^')[2];//床号
                            
                        }
                        catch (Exception)
                        {
                        }

                        fbType = arrayLine[20].ToString();//费别

                        report_main.PatType = patType;
                        report_main.PatDept = deptName;
                        report_main.RoomNo = roomNo;
                        report_main.BedNo = bedNo;
                        report_main.TestName = fbType;

                        break;
                    #endregion

                    #region 仪器信息
                    case "MSH":
                        break;
                    #endregion

                    #region 主要包含检验报告单信息
                    case "OBR":

                        //OBR|1||5|00001^Automated Count^99MRC||20140918091000|20140918105930||||王医生|||20140918103000||||||||||HM||||||||develop

                        sampleNo = arrayLine[3].ToString();//样本编号

                        CollectTime = IsNullCheck(arrayLine[6].ToString());//采样时间

                        TestTime = IsNullCheck(arrayLine[7].ToString());//检验时间
                        Collect_User = arrayLine[10].ToString();//采集人
                        Diagion = arrayLine[13].ToString();//临床诊断
                        RecieveTime = IsNullCheck(arrayLine[14].ToString());//接收时间
                        SampleSource = arrayLine[15].ToString();//样本来源
                        AuditTime = IsNullCheck(arrayLine[22].ToString());//审核时间
                        Diagnostic = arrayLine[24].ToString();//诊断ID
                        AuditUser = arrayLine[28].ToString();//审核者




                        report_main.ReportID = sampleNo;
                        //report_main = CollectTime.ToString();
                        //report_main. = TestTime.ToString();
                        //report_main.co = Collect_User;
                        report_main.Diagnosis = Diagion;
                        //report_main.Barcode = RecieveTime.ToString();
                        //report_main.Barcode = SampleSource;
                        //report_main.Barcode = AuditTime.ToString();
                        //report_main.Diagnosis = Diagnostic;
                        //report_main.Barcode = AuditUser;

                        report_mainDal.Add(report_main);
                        break;
                    #endregion

                    #region 主要包含各个检验结果参数信息
                    case "OBX":
                        //OBX|7|NM|6690-2^WBC^LN||5.51|10*9/L|4.00-10.00||||F                                               
                        strItemNo = arrayLine[3].Split('^')[1];

                        Maticsoft.Model.report_detail report_detail1 = new Maticsoft.Model.report_detail();
                        Maticsoft.DAL.report_detail report_detailDal = new Maticsoft.DAL.report_detail();
                        //当第三位为【NM】时，代表普通结果
                        if (arrayLine[2] == "NM")
                        {
                            strResult = arrayLine[5];
                            strUnits = arrayLine[6];
                            strRange = arrayLine[7];
                            strResultflg = arrayLine[8];


                            report_detail1.ReportID = strKey;
                            report_detail1.Result = strResult;
                            report_detail1.Units = strUnits;
                            report_detail1.RefRange = strRange;
                            report_detail1.Abnormal_Flg = strResultflg;
                            report_detail1.ItemNo = strItemNo;
                            report_detail1.ItemName = "";

                            report_detailDal.Add(report_detail1);
                        }
                        //当第三位为【ED】，代表图片数据为直方图
                        else if (arrayLine[2] == "ED")
                        {
                            //获取图片数据串
                            string strImage = arrayLine[5].Split('^')[4];
                            if (arrayLine[3].IndexOf("Binary") >= 0)
                            {
                                //wf_graph(strImage, arrayLine[3].Split('^')[1]);
                            }
                            else if (arrayLine[3].IndexOf("BMP") >= 0)
                            {
                                //GetImgjpg(strImage, arrayLine[3].Split('^')[1]);
                            }
                        }

                        break;
                    #endregion
                    default: break;
                }

            }
            #endregion
        }
        #endregion

        #region 把一个数组取出指定的长度
        /// <summary>
        /// 把一个数组取出指定的长度
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static byte[] ByteToByte(byte[] a, int b, int index)
        {
            byte[] haveDate = new byte[b];
            Array.Copy(a, index, haveDate, 0, b);
            return haveDate;
        }
        #endregion

        #region 时间非空判断
        public DateTime IsNullCheck(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return Convert.ToDateTime(str);
            }
            else
            {
                return DateTime.Now;
            }
        }

        #endregion

        private void uiButton5_Click(object sender, EventArgs e)
        {

        }
    }
}

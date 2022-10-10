using comm;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private static Socket tcpServer = null;
        private static Socket clientSocket = null;
        public byte[] buffer = new byte[1024 * 1024 * 3];
        public static List<TcpClient> clientList = new List<TcpClient>();

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

            //Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建socket对象
            //tcpServer.Bind(new IPEndPoint(IPAddress.Parse("10.0.0.20"), 5000));//绑定IP和申请端口

            //tcpServer.Listen(100);//设置客户端最大连接数
            //Console.WriteLine("服务器已启动，等待连接.........");
            //while (true)//循环等待新客户端的连接
            //{
            //    Socket clientSocket = tcpServer.Accept();
            //    Console.WriteLine((clientSocket.RemoteEndPoint as IPEndPoint).Address + "已连接");                
            //}

            tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse("10.0.0.20");
            EndPoint point = new IPEndPoint(ipaddress, int.Parse("5000"));

            tcpServer.Bind(point);//绑定IP和申请端口
            tcpServer.Listen(100);//设置客户端最大连接数
            while (true)//循环等待新客户端的连接
            {
                clientSocket = tcpServer.Accept();
                
                Console.WriteLine((clientSocket.RemoteEndPoint as IPEndPoint).Address + "已连接");
                clientSocket.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);
            }


            //tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress ipaddress = IPAddress.Parse(uiIPTextBox.Text);
            //EndPoint point = new IPEndPoint(ipaddress, int.Parse(uiTextBox4.Text));

            //tcpClient.SendTimeout = 1000;
            //tcpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);
            //tcpClient.BeginConnect(point, new AsyncCallback(ConnectCallBack), tcpClient);            
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
                UIMessageTip.Show(AppCode.CONNECT_SUCCESS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                MessageBox.Show(AppCode.CONNECT_FALSE);
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
                if (clientSocket.Connected)
                {
                    int bytesRead = clientSocket.EndReceive(ar);
                    if (bytesRead > 0)
                    {
                        byte[] haveDate = ByteToByte(buffer, bytesRead, 0);//取出有效的字节数据,得到实际的数据haveDate
                        Array.Clear(buffer, 0, buffer.Length);//情况缓冲数组

                        string strAll = TextEncoder.bytesToText(haveDate);

                        ChuLiOneHL7(strAll);//处理数据
                        strAll = "";
                        clientSocket.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//接收剩余的数据或者继续接收数据
                    }
                    else //如果接收到数据字符为0，代表接收完了
                    {
                        tcpServer.BeginReceive(buffer, 0, buffer.Length, 0, new AsyncCallback(ReceiveCallBack), this);//继续接收数据
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
            bool IsUpdate = false;
            strKey = DateTime.Now.ToString("yyyyMMddhhmmss");//报告单号

            Maticsoft.Model.report_main report_main = new Maticsoft.Model.report_main();
            Maticsoft.DAL.report_main report_mainDal = new Maticsoft.DAL.report_main();
            Maticsoft.Model.report_detail report_detail1 = new Maticsoft.Model.report_detail();
            Maticsoft.DAL.report_detail report_detailDal = new Maticsoft.DAL.report_detail();
            report_main.ReportID = strKey;

            #region 对合格串进行解析
            string[] arrayData = ib_data.Split('\r');
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

                        report_main.PatAge = GetAge(patBirthday, DateTime.Now);
                        report_main.Barcode = CaseNo;
                        report_main.PatName = patName;
                        report_main.PatBirthday = patBirthday.ToString("G");
                        if (patSex == "2") { report_main.PatSex = "女"; } else { report_main.PatSex = "男"; }

                        break;
                    #endregion

                    #region 包含病人的看病信息。
                    case "PV1":
                        //PV1|1|住院|外科^1^2|||||||||||||||||自费  “科室^房间^床号”
                        //patType = arrayLine[2].ToString();//病人类型 => 样本类型
                        report_main.SampleType = arrayLine[2].ToString();
                        try
                        {
                            //deptName = arrayLine[3].Split('^')[0];//科室
                            //roomNo = arrayLine[3].Split('^')[1];//房间
                            //bedNo = arrayLine[3].Split('^')[2];//床号
                            bedNo = arrayLine[3].Split('^')[0];//房间
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

                        //OBR|1||6-968|01001^99MRC|||2022-06-15 15:52:41|||李佩||||||||||||||HM||||||||produce\r
                        sampleNo = arrayLine[3].ToString();//样本编号
                        CollectTime = IsNullCheck(arrayLine[6].ToString());//采样时间
                        TestTime = IsNullCheck(arrayLine[7].ToString());//检验时间
                        report_main.SendDocName = arrayLine[10].ToString();//送检人员                        
                        Diagion = arrayLine[13].ToString();//临床诊断
                        RecieveTime = IsNullCheck(arrayLine[14].ToString());//接收时间
                        SampleSource = arrayLine[15].ToString();//样本来源
                        AuditTime = IsNullCheck(arrayLine[22].ToString());//审核时间
                        Diagnostic = arrayLine[24].ToString();//诊断ID
                        AuditUser = arrayLine[28].ToString();//审核者
                        report_main.TestDocName = arrayLine[32].ToString();
                        report_main.SampleNo = sampleNo;
                        report_main.Diagnosis = Diagion;
                        if (report_mainDal.ExistsBySampleNo(sampleNo))
                        {
                            strKey = report_mainDal.QueryBySampleNo(sampleNo).Rows[0]["reportID"].ToString();
                            report_main.ReportID = strKey;
                            report_mainDal.Update(report_main);
                            IsUpdate = true;
                        }
                        else { report_mainDal.Add(report_main); }

                        break;
                    #endregion

                    #region 主要包含各个检验结果参数信息
                    case "OBX":
                        //OBX|7|NM|6690-2^WBC^LN||5.51|10*9/L|4.00-10.00||||F
                        //
                        if (arrayLine[2] == "IS") {
                            if (arrayLine[3].IndexOf("Remark") > 0) 
                            {
                                report_main.Demo = arrayLine[5].ToString();
                                report_mainDal.Update(report_main);
                            }
                         }
                        if (arrayLine[3].IndexOf("Histogram") > 0)// 如果循环到这行有Histogram就退出
                        {                        //当第三位为【ED】，代表图片数据为直方图
                            if (arrayLine[2] == "ED")
                            {
                                //获取图片数据串
                                string strImage = arrayLine[5].Split('^')[4];
                                if (arrayLine[3].IndexOf("Binary") >= 0)
                                {
                                    //wf_graph(strImage, arrayLine[3].Split('^')[1]);
                                }
                                else if (arrayLine[3].IndexOf("BMP") >= 0)
                                {
                                    Maticsoft.Model.report_graph report_graph = new Maticsoft.Model.report_graph();
                                    Maticsoft.DAL.report_graph report_graphDal = new Maticsoft.DAL.report_graph();

                                    strImage = ImgToBase64String(GetImgjpg(strImage));
                                    report_graph.ReportID = strKey;
                                    report_graph.Graph = strImage;

                                    if (!IsUpdate) { report_graphDal.Add(report_graph); }
                                    
                                }
                            }
                            else { break; }

                        }
                        strItemNo = arrayLine[3].Split('^')[1];

                        //当第三位为【NM】时，代表普通结果
                        if (arrayLine[2] == "NM")
                        {
                            strResult = arrayLine[5];
                            strUnits = arrayLine[6];
                            strRange = arrayLine[7];
                            strResultflg = arrayLine[8];


                            #region 参考范围
                            if (strRange.IndexOf("-") >= 0)
                            {
                                string[] strRangeList = strRange.Split('-');
                                if (float.Parse(strRangeList[0]) < float.Parse(strResult))
                                {
                                    strResultflg = "↓";//↓↑
                                }
                                else if (float.Parse(strRangeList[0]) < float.Parse(strResult))
                                {
                                    strResultflg = "↑";//↓↑
                                }
                            } else if (strRange.IndexOf(">") >= 0) 
                            {
                                if (float.Parse(strRange) < float.Parse(strResult))
                                {
                                    strResultflg = "↓";//↓↑
                                }
                            }
                            else if (strRange.IndexOf("<") >= 0)
                            {
                                if (float.Parse(strRange) > float.Parse(strResult))
                                {
                                    strResultflg = "↑";//↓↑
                                }
                            }
                            #endregion
                            report_detail1.ReportID = strKey;
                            report_detail1.Result = strResult;
                            report_detail1.Units = strUnits;
                            report_detail1.RefRange = strRange;
                            report_detail1.Abnormal_Flg = strResultflg;
                            report_detail1.ItemNo = strItemNo;
                            report_detail1.ItemName = "";

                            if (!IsUpdate) { report_detailDal.Add(report_detail1); }                            
                        }
                        break;
                    #endregion
                    default: break;
                }

            }
            #endregion
        }
        #endregion
        #region 将图片进行反色处理
        /// <summary>
        /// 将图片进行反色处理
        /// </summary>
        /// <param name="mybm">原始图片</param>
        /// <param name="width">原始图片的长度</param>
        /// <param name="height">原始图片的高度</param>
        /// <returns>被反色后的图片</returns>
        /// 
        public Bitmap RePic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录处理后的图片的对象
            int x, y, resultR, resultG, resultB;
            Color pixel;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值
                    resultR = 255 - pixel.R;//反红
                    resultG = 255 - pixel.G;//反绿
                    resultB = 255 - pixel.B;//反蓝
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图
                }
            }

            return bm;//返回经过反色处理后的图片
        }
        #endregion

        #region 输入字符串获取图像
        /// <summary>
        /// 输入字符串获取图像
        /// </summary>
        /// <param name="base64string"></param>
        public Bitmap GetImgjpg(string base64string)
        {
            byte[] bt = Convert.FromBase64String(base64string);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(bt);
            Bitmap bitmap = new Bitmap(stream);

            bitmap = RePic(bitmap, bitmap.Width, bitmap.Height);
            return bitmap;
        }
        #endregion

        public string ImgToBase64String(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

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
                DateTime dt;
                try
                {
                    dt = Convert.ToDateTime(str);
                }
                catch (Exception)
                {

                    dt = Convert.ToDateTime(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6, 2) + " " + str.Substring(8, 2) + ":" + str.Substring(10, 2) + ":" + str.Substring(12, 2));
                }

                return dt;
            }
            else
            {
                return DateTime.Now;
            }
        }

        #endregion

        #region 获取年龄
        public string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty; // 年龄的字符串表示
            int intYear = 0; // 岁
            int intMonth = 0; // 月
            int intDay = 0; // 天

            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;

            // 格式化年龄输出
            if (intYear >= 1) // 年份输出
            {
                strAge = intYear.ToString() + "岁";
            }

            if (intMonth > 0 && intYear <= 5) // 五岁以下可以输出月数
            {
                strAge += intMonth.ToString() + "月";
            }

            if (intDay >= 0 && intYear < 1) // 一岁以下可以输出天数
            {
                if (strAge.Length == 0 || intDay > 0)
                {
                    strAge += intDay.ToString() + "日";
                }
            }

            return strAge;
        }
        #endregion

        private void uiButton5_Click(object sender, EventArgs e)
        {
            string str = "MSH|^~|EH8600|Excbio|||20000101021746||ORU^R01|d4a8874d-1f0c-4269|P|2.3.1||||||UNICODE\r";
            str += "PID|1||11002^^^^MR||^杨桑||20221004000000|2\r";
            str += "PV1|1|末梢血|2#|||||||||||||||||\r";
            str += "OBR|1||6-968|01001^99MRC|||2022-06-15 15:52:41|||李佩||||||||||||||HM||||||||produce\r";
            str += "OBX |1|IS|08001^Take Mode^99MRC||O||||||F\r";
            str += "OBX|2|IS|08002^Blood Mode^99MRC||W||||||F\r";
            str += "OBX|3|IS|08003^Test Mode^99MRC||CBC+DIFF||||||F\r";
            str += "OBX|4|NM|30525-0^Age^LN||12|1|||||F\r";
            str += "OBX|5|IS|01001^Remark^99MRC||额嗯嗯嗯嗯||||||F\r";
            str += "OBX|6|IS|01002^Ref Group^99MRC||3||||||F\r";
            str += "OBX|7|NM|6690-2^WBC^LN||5.86|10^9/L|0-0||||F\r";
            str += "OBX|8|NM|770-8^LYM%^LN||62.4|%|0-0||||F\r";
            str += "OBX|9|NM|736-9^MID%^LN||30.4|%|0-0||||F\r";
            str += "OBX|10|NM|5905-5^GRA%^LN||7.2|%|0-0||||F\r";
            str += "OBX|13|NM|751-8^LYM#^LN||3.66|10^9/L|0-0||||F\r";
            str += "OBX|14|NM|731-0^MID#^LN||1.78|10^9/L|0-0||||F\r";
            str += "OBX|15|NM|742-7^GRA#^LN||0.42|10^9/L|0-0||||F\r";
            str += "OBX|22|NM|789-8^RBC^LN||4.35|10^12/L|0-0||||F\r";
            str += "OBX|23|NM|718-7^HGB^LN||129|g/L|0-0||||F\r";
            str += "OBX|24|NM|4544-3^HCT^LN||49.6|%|0-0||||F\r";
            str += "OBX|25|NM|787-2^MCV^LN||114|fL|0-0||||F\r";
            str += "OBX|26|NM|785-6^MCH^LN||29.7|pg|0-0||||F\r";
            str += "OBX|27|NM|786-4^MCHC^LN||260|g/L|0-0||||F\r";
            str += "OBX|28|NM|788-0^RDW-CV^LN||14|%|0-0||||F\r";
            str += "OBX|29|NM|21000-5^RDW-SD^LN||71.8|fL|0-0||||F\r";
            str += "OBX|30|NM|777-3^PLT^LN||275|10^9/L|0-0||||F\r";
            str += "OBX|31|NM|32623-1^MPV^LN||9.9|fL|0-0||||F\r";
            str += "OBX|32|NM|32207-3^PDW^LN||16.5|%|0-0||||F\r";
            str += "OBX|33|NM|11003^PCT^99MRC||0.272|%|0-0||||F\r";
            str += "OBX|34|NM|34167-7^P-LCC^LN||80|10^9/L|0-0||||F\r";
            str += "OBX|35|NM|48386-7^P-LCR^LN||29|%|0-0||||F\r";
            str += "OBX|40|IS|17790-7^WBC Left Shift?^LN||?||||||F\r";
            str += "OBX|41|NM|15001^WBC Histogram. Left Line^99MRC||?||||||F\r";
            str += "OBX|42|NM|15003^WBC Histogram. Middle Line^99MRC||?||||||F\r";
            str += "OBX|43|ED|15008^WBC Histogram. BMP^99MRC||^Image^BMP^Base64^iVBORw0KGgoAAAANSUhEUgAAAM8AAABuCAIAAAAPo9BDAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAAA1hAAANYQE8JGIuAAAFPUlEQVR4nO3ZUUgbdxwH8J9bHi4shT8sDxeIxQMHnjgwocIitdC8eeBDAw5qYSDpHiSs0Cbtw9K9DPFhiA9FOxipAyEWHDroyAodjQ+F+CBcBhl3BcE8KLtAHy4wR8IauD0kde1SjXV3f5Ps+3kzZ+77j3z53/9niAAAAAAAAAAAAAAAAAAAAAAAAAAA4EiZbCZwIUBExgtD9IvkIk3XAp8ETNNU86paUOVhmYiUCUXTNW1Hm5qeOuslQ/t67/jL+m+6LMtinyi4hNGRUalf0nd0Iso+ywYDwaWFpfiNOBPZ4r3F8Hg4GAjqeZ3LsqEjvX/85V5/b6/U63a5a7XauQ/PVQ+q7g/cuq5fGru09nBNmVDKf5bP+8/v/77/6IdHtb9qpVKJz7qhE7XY29SCOjgwGAwEVx+uhi6E5AFZK2hEFB4LqwX17pd3NzY2RJ9o7BlcVgudrfWTVJIkeUjObmbdbrf0kaTrr56kHweDI8H09+myUfb1+risFjpbi7ZVD6qCSyAiqlGxWBwNjerP/zmZVatV5mXrP61PTU6JflEQBGVCcXS50NFatI2IintFo2QQkbqtMg+rHlTp1ZM08ziTuJEo7ZcSdxLZzaymaz4/NjkAAAAAAAAAAICjWJZ1whc55HJ47/8Zh79b6//uAtgFbQN+0DZoGzgDgY2wtwE/p2kbZtKuhJkUugraBvygbdA2cAYCG2FvA34wk0IDZlLoKmgb8IO2QdvAGQhshL0N+MFMCg2YSaGroG3AD9oGbQNnILAR9jbgBzMpNGAmha6CtgE/aBu0DZyBwEbY24AfzKTQgJkUugraBvygbdA2cAYCG2FvA34wk0IDZlLoKmgb8IO2QdvAGQhshL0N+MFMCg2YSaGroG3AD9oGbQNnILAR9jbgBzMpNGAmha6CtgE/aBu0DZyBwEbY24AfzKTQgJkUugraBvygbdA2cAYCG/Ucfxltg5Z6elq06KTOajbsxPeeYXSnjPA4twEAAAAAAAAAEEWno4ZhqHlVHpLtumf8dnx3bze1nDomxfZc5mXptbRpmrmtnNQvccslIiY2ojVdC18O84wmInlIrrysxG/GHcqN346bf5jz9+ctyxL7xNMvlInMNE2pX4rORHNbudPf6E2RyUjm58xh25pTnMhVxpX4zTjzsvRqOr2W5pZbv23kakTwCMmvk2pe5RlNRJknGW1Hq7fNidzdvV1lXCGB/mvbotONFYiiaFkW87LT3+tNs3Ozh21rTnEul4gik5Hcdo5/riiK8/fmUyspntHKuKLm1cXlxXrbbM9NraQsy6pUKuEr4ZZta/FdgugXtR2NiEqlUvmg7PP73mkpJ9Sc4mhucCRY32B45srDsmEYkSuRxK0Ev2gXzS/Mx27FBBLqL9iee/2z6+VyeXRsNPs42/KXW31zVTv2R7s0pziWK/VJsc9jSwtLnHP1X/Ued8+D7x6s/7jOLTo2E8sX8lubW0fe1smP3KxF24ql4qA8SESiX2QeZpQMJxbRnOJQLvOyzC+ZxJ2E/lznmdtQpaVvl8IXw4wxPtGRTyPKuGKa5rWr12bnZqemp3h/5HdyeISMzcSePntq231dNPvNbGolRa63pziRK3iE3HZu8f4iuYhnLhHFvohFZ6LMy5JfJY0XBs/outRy6l9Tgo25pmkGLgTqU4I8IAseQfAIp1xoYzwuqPKAPWO51C9ZrxGY8NYU23OTc0nLsiovK/VceVjmk0tE0oCUeZIxTVMtqKHLoaOCnIiuO2ybE7mvt+1Q6GLIttUDAAAAERH9DWmD+igVafNHAAAAAElFTkSuQmCC||||||F\r";
            str += "OBX|44|NM|15051^RBC Histogram. Left Line^99MRC||?||||||F\r";
            str += "OBX|45|NM|15052^RBC Histogram. Right Line^99MRC||?||||||F\r";
            str += "OBX|46|ED|15056^RBC Histogram. BMP^99MRC||^Image^BMP^Base64^iVBORw0KGgoAAAANSUhEUgAAAM8AAABuCAIAAAAPo9BDAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAAA1hAAANYQE8JGIuAAAEnElEQVR4nO3ZMWgbVxzH8efi4Qoe3qDhDC5Y4MEXWrBEA1aIBx90iIIHX/AQDwWjdDCiQyuni+hSTIZgOpQ4haKkYJCHFFFoUQst9hKQh8ApYDgVXKSCAydo4QQt2NDCdbBRDHYsI1lPT/L3sx0S0k+8H3/eHwkBAAAAAAAAAAAAAAAAAACAN4pNx4IgcHddb8+zP7CPH8uuu+taU5YQIjmX9Cqet+ctLi32Oiz6XGw6VvihIISwZ+2t7a3mY2oplXuak6as1qrmuGmMGLGpWK/DQnfDF3yfOW7W/6q/fhwza69qd+bvbH63Wf+jLoQovyx3JSAGSOu22TO2t+cJIW7P3ZZS2jO2u+taE1Y8EXccx9/3ux8SA+Ktlu/Yfr5tz9rGsFH7vXb0GH8vHr8ez3+bb/iN0XdGux8SA6J124QQ9Vf1nZ2dxbuv94DDw0MZkYUfC4sLi+aYaRhGci7ZtZC4GpprQWI64ZbdkyuqM+8IIZwFx9vzqrVqajnV67AAAAAAAACA5sIwbPtV9Iq253Kh/xKAS0HboA5tgza0vQGgHzHboE5HbWPy6Unbc2G2QR3aBnVoG7Sh7Q0A/YjZBnXYSQeQtufCbIM6tA3q0DZoQ9sbAPoRsw3qsJMOIG3PhdkGdWgb1KFt0Ia2NwD0I2Yb1GEnHUDanguzDerQNqhD26ANbW8A6EfMNqjDTjqAtD0XZhvUoW1Qh7ZBG9reANCPmG1Qh510AGl7Lsw2qEPboA5tgza0vQGgHzHboA476QDS9lyYbVCHtkEd2gZtaHsDQD9itkEddtIBpO25MNugDm2DOrQN2tD2BoB+xGyDOuykA0jbc2G2QR3aBnVoG7Sh7Q0A/Wjo/JdpG1oaGmrRoovqRtv65TO79LFXOSr3NgAAAAAAACFSSynf992ya71r9SpD5n6mul/NPc2dk0qHnDIi88/yQRCUdkrRiajWUc3jqF7Fs2ftTqJm7meCv4O1x2thGJrjZkeZgiCITkRTy6nSTqn9D+qMs+AUfyo223Y6lSY5k7eSmU8yMiLzm/n8s7zOUaUpnbuOMWJkv8i6ZbeTqNX9avJWUhii07allo6/xjTNMAxlRLb/WZ1ZfbDabNvpVPrkPOIsOKUXJf2jmqa59tVabiPXdtTcRi4Mw4ODA3vebtm2Fv8lmGOmt+cJIer1euOfxujYaNs/7BKdTqVbzvj1+NHA0DmqNWX5vu/MOyufrrQd9d6H9xqNxo2ZG9s/b7f8xlb/XP137mOvnE6lU87oeDT9UXr9y/UzkugUtfKyMvT20JNvnhS+L5yRpAtRW7StVq9ds64JIcwxU45Iv+53+oWX4XQqfXLKiCz+Wlz5bKXyW0XzqEIIcSjWv163b9pSyt5Hbd4T08vpredb3f2ycwyL1YeruY2cGD47lSY5jRGj9KL06PEjMSw0j5r+OJ1aTsmIzH6e9f/0O4kaBEHs/djRlmBNWsaIYYwYbcY63oF3XWuyN+t6dCIanmBI48xUPc8phMg+yIZhePDvwVFUa8rSNmp0Mlr8pRgEgbvrJmYTbwp2kagn29aUuJlQ8TMAALhK/gcTeAhvfRu6CgAAAABJRU5ErkJggg==||||||F\r";
            str += "OBX|47|NM|15111^PLT Histogram. Left Line^99MRC||?||||||F\r";
            str += "OBX|48|NM|15112^PLT Histogram. Right Line^99MRC||?||||||F\r";
            str += "OBX|49|ED|15116^PLT Histogram. BMP^99MRC||^Image^BMP^Base64^iVBORw0KGgoAAAANSUhEUgAAAM8AAABuCAIAAAAPo9BDAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAAA1hAAANYQE8JGIuAAAEEklEQVR4nO3ZP2gbZxjH8VfFwxU03KDhDB584EEKHaLQQhySIYIO1lCIQoYuhXDp4IoOrZwuoksRGYLpUOIUyiWDQRkMplBQCy3xYrgMgXPBIBUM0pDhBB1O0IIKKVwHGeFCGimW9Oit3u9n0x/Ej5cfj55XUgoAAAAAAAAAAAAAAAAAAAD/KX85H8dxs9UMj0I36+Yv5/d/2B+85O/6zZNm/2W/edKs3a/NNycWwbBe3qZX36ufbZtSSlkqiqK5hcP/zVtjvi84DJxlZ6ZRsPDGbVtxo9g6bs00Chbe0sh3FK4VwqOw0+l4n3juqiuQCYtqdNsODg9ufnDz9MHqTMNgwY37TTpUfL/Y7rTbnbabZc4BAAAAAAAAbyRJkjGfxIRMONU3/nUXODfaBjm0DdowYZmAGGYb5JynbQy8WTDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQw2yDHO6kujDhVJltkEPbIIe2QRsmLBMQk3r9y7QNI6VSI1o0rum2jU8z/NPY2wAAAAAAAJTybntRFIVHYe6d3LyzqMrdSvtF23/sD5/RJJ6dset79TiOg2eBu+bqlc05zdZsNQvXC1PPVrlbif+Itx9uJ0nirDoTBY3j2F1zvU0veBZMGGtypVulxo+NYdv0iVfcKFY+q9gZu/6kXt+ra5XNduzShyUrbVW/qoZH4dSztV+0ixtFZalJ2+bdPk3jOE6SJHbGnjDZ5Gr3asO2aRivdKsUPA+Uftkcx9n+Ztvf9aebzd/1kyTp9/uFG4WRbRvxX4Kz4jRPmkqpbrfb+7O3vLJ87lizoGG8S+9dGswPrbLlLuaiKCrdKG19vjXdbHc+utPr9a5cu3Lw08HIN4/65+rv1z6cO83iuatu+ePyztc7rwgz12ytX1upt1OPvnu0//3+K8JIZRvRtk63cyF3QSnlrDh22o66kUiqcWkVz87YjV8aW19stX5r6ZZNKaX+Ujvf7hSuFmzb1i7bwHCdLG+Wnx4+nXccpZZU7X7N3/XVklI6xbPSVvA8ePDwgVpSumUrf1r2Nj07Y1e/rEa/R1PPFsdx/t384JaQy+astGWlrXN+1ulV+TjMZef8C4i75iZnWLalT7zqvWqSJP2X/UG23MWcPtncrNv4uRHHcXgcrl9fHzw5xWxn2za0fnV94uAAAOBf/gEunzZSiZ8LcwAAAABJRU5ErkJggg==||||||F\r";

            ChuLiOneHL7(str);
        }
    }
}

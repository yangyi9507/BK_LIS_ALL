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

namespace BK_LIS
{
    public partial class ReportMain : UIPage
    {
        #region 定义

        const short STX = 2;    //(start of text)       正文开始 
        const short ETX = 3;    //(end of text)         正文结束
        const short EOT = 4;    //(end of transmission) 传输结束
        const short ENQ = 5;    //(enquiry)             请求 
        const short ACK = 6;    //(acknowledge)         收到通知
        const short NAK = 21;   //(negative acknowledge)拒绝接收
        const short ETB = 23;   //(end of trans. block) 传输块结束
        const short LF = 10;
        const short CR = 13;
        const short VT = 11;  // 开始字符
        const short FS = 28;  // 结束字符
        const short SUB = 26; // substitute  替补

        // ------普通报告------
        string strSampleNo = "";  //样本号
        string strKey = "";  //报告单号
        string strItemNo = "";  //通道号
        string strResult = "";  //结果
        int isEmergency = 0; //急诊标识

        // ------质控------
        string QC_BATCH = "";  //质控批号
        Boolean boolFlagQC = false;  //标记是否为质控
        string userSysIdQC = "";  //质控者userSysId
        string userNameQC = "";  //质控者

        // ------双工------
        string strOrder = ""; //双工回写串

        // ------其他变量------
        DateTime now;  //当前时间
        string strRec = "";  //用于单个接收数据
        Boolean boolIsUpdateOk = false; //标记是否上传成功
        bool isOffLine = false;//是否离线模式

        // ------传输参数------
        int lngSrLen = 0;                   //-- 没有数据的字符串最大长度 --
        int lngSampnoSt = 0;                //-- 样本号起始位（索引位置） --
        int lngSampnoLen = 0;                //-- 样本号长度 --
        int lngItmSt = 0;                    //-- 通道号起始位（索引位置） --
        int lngItmLen = 0;                   //-- 通道号长度 --
        int lngAlert = 0;                    //-- 报警标志长度 --
        int lngRulSt = 0;                    //-- 结果起始位（索引位置） --
        int lngRulLen = 0;                   //-- 结果长度 --
        int lngRackNoLen = 0;                //-- 架子号长度 --
        int lngCupPosLen = 0;                //-- 杯子号长度 --
        int lngSampleType = 0;               //-- 样本类型长度 --
        int timeInterval = 3;                //-- Time执行频率（/秒）--




        //------前台可配变量------接口工具配置内容
        const short shortByteStart = 0; // 开始字节
        const short shortByteEnd = 0; //  结束字节
        char dataSplit = (char)' '; //  合格拼接串分隔符
        char lineSplit = (char)' '; //  合格拼接串分隔符

        int resultPos = 0; // 结果在数组中的下标


        string replaceSampleNo = ""; // 样本号中此字符串时替换为空
        char splitSampleNo = (char)' '; // 样本号中行数组内部分隔符
        int sampleNoPosLine = 0; // 样本号在行数组中的位置
        int sampleNoPos = 0; // 样本号在数组中的下标


        string replaceItem = ""; // 通道号中此字符串时替换为空
        char splitItem = (char)' '; // 通道号中行数组内部分隔符
        int itemNoPosLine = 0; // 通道号在行数组中的位置
        int itemNoPos = 0; // 通道号在数组中的下标
        #endregion


        private static Socket tcpClient = null;
        public byte[] buffer = new byte[1024 * 1024 * 3];


        public ReportMain()
        {
            InitializeComponent();

            GetItemClassName();//初始化获取项目大类

            GetPatType();//初始化获取病人类型

            GetDept();//初始化获取科室

            GetPatSex();//初始化获取性别
        }

        #region 获取项目大类
        public void GetItemClassName() 
        {
            Maticsoft.BLL.sampleclass sampleclass = new Maticsoft.BLL.sampleclass();  //声明对象                      
            uiComboBox1.DataSource = sampleclass.GetAllList().Tables[0];//赋值

            uiComboBox1.DisplayMember = "ClassName";
            uiComboBox1.ValueMember = "ClassCode";            
        }
        #endregion

        #region 获取患者类型
        public void GetPatType()
        {
            Maticsoft.BLL.classtype classtype = new Maticsoft.BLL.classtype();  //声明对象
            string str = " DicCode = '1'";
            uiComboBox2.DataSource = classtype.GetDataByDicCode(str).Tables[0];//赋值                      
            uiComboBox2.DisplayMember = "DicItemName";
            uiComboBox2.ValueMember = "DicItemCode";
        }
        #endregion
        #region 获取科室
        public void GetDept()
        {
            Maticsoft.BLL.Dept Dept = new Maticsoft.BLL.Dept();  //声明对象       
            uiComboBox3.DataSource = Dept.GetDeptCode("").Tables[0];//赋值 
            uiComboBox3.DisplayMember = "DeptID";
            uiComboBox3.ValueMember = "DeptName";
        }
        #endregion


        #region 获取患者性别
        public void GetPatSex()
        {
            Maticsoft.BLL.classtype classtype = new Maticsoft.BLL.classtype();  //声明对象
            string str = " DicCode = '2'";
            uiComboBox2.DataSource = classtype.GetDataByDicCode(str).Tables[0];//赋值                      
            uiComboBox2.DisplayMember = "DicItemName";
            uiComboBox2.ValueMember = "DicItemCode";
        }
        #endregion

        private void uiButton5_Click(object sender, EventArgs e)
        {

        }

        #region 检验IP地址是否正常
        private bool CheckIp(string a)
        {
            return Regex.IsMatch(a, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        #endregion

        #region 检验端口号是否正常
        public static bool IsPositiveIntNoZero(string value)
        {
            return Regex.IsMatch(value, @"^[1-9]\d*$");
        }
        #endregion
        #region IP连接
        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiIPTextBox.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!IsPositiveIntNoZero(uiTextBox1.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(uiIPTextBox.Text);
            EndPoint point = new IPEndPoint(ipaddress, int.Parse(uiTextBox1.Text));
            
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

            #region 对合格串进行解析
            string[] arrayData = ib_data.Split('\n');
            for (int i = 0; i < arrayData.Length - 1; i++)
            {
                string[] arrayLine = arrayData[i].Split('|');
                switch (arrayLine[0])
                {
                    case "PID":
                        //消息段包含病人的基本信息
                        //PID|1||05012006^^^^MR||^张三||19991001000000|男

                        break;
                    case "PV1":
                        //包含病人的看病信息。
                        //PV1|1|住院|外科^1^2|||||||||||||||||自费
                        break;
                    case "MSH":
                        //仪器信息
                        break;
                    case "OBR":
                        //项目样本信息
                        strSampleNo = arrayLine[3];
                        if (isOffLine)
                        {
                            strKey = System.DateTime.Now.ToString("yyyyMMdd");
                        }

                        break;
                    case "OBX":
                        strItemNo = arrayLine[3].Split('^')[1];
                        //当第三位为【NM】时，代表普通结果
                        if (arrayLine[2] == "NM")
                        {
                            strResult = arrayLine[5];
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
    }
}

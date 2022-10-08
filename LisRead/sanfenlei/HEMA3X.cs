using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LisRead.sanfenlei
{
    class HEMA3X
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


        
        public byte[] buffer = new byte[1024 * 1024 * 3];
    }
}

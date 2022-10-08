using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace comm
{
    public class TcpSockect
    {
        private static Socket tcpClient = null;
        public byte[] buffer = new byte[1024 * 1024 * 3];

        #region 检验IP地址是否正常
        public static bool CheckIp(string a)
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


        #region 连接Socket
        public void SocketConnect(string ip,string port) 
        {
            tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(ip);
            EndPoint point = new IPEndPoint(ipaddress, int.Parse(port));

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

                        //ChuLiOneHL7(strAll);//处理数据
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

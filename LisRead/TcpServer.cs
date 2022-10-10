using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LisRead
{
    public static List<Client> clientList = new List<Client>();

    public class TcpServer
    {

             Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建socket对象
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.145"), 8090));//绑定IP和申请端口

            tcpServer.Listen(100);//设置客户端最大连接数
            Console.WriteLine("服务器已启动，等待连接.........");
            while (true)//循环等待新客户端的连接
            {
                Socket clientSocket = tcpServer.Accept();
                Console.WriteLine((clientSocket.RemoteEndPoint as IPEndPoint).Address+"已连接");
                Client client = new Client(clientSocket);
                 clientList.Add(client);
            }
    }
}

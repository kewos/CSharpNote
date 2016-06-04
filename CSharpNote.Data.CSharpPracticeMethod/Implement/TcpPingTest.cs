using System;
using System.Net.Sockets;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TcpPingTest : AbstractExecuteModule
    {
        /// <summary>
        ///     透過TcpClient傳入IpAddress Port建立連線
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            try
            {
                var port = 0;
                var ipAddress = "127.0.0.1";
                var client = new TcpClient(ipAddress, port);
                var data = Encoding.ASCII.GetBytes("test");

                var stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", "test");

                data = new byte[256];

                var responseData = string.Empty;

                var bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
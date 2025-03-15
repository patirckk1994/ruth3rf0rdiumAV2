/* Client Program */
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using ruth3rf0rdium;

public class clnt
{
    public clnt(ClientThreadManager mgr)
    {
        this.mgr = mgr;
    }
    ClientThreadManager mgr;
    public void Main()
    {
        
        try
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            tcpclnt.Connect("127.0.0.1", 8001); // use the ipaddress as in the server program
            Console.WriteLine("Connected");
            Console.Write("Enter the string to be transmitted : ");
            String str = "lol";
            Stream stm = tcpclnt.GetStream();
            var socket = tcpclnt.Client;
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");
            stm.Write(ba, 0, ba.Length);
            byte[] bb = new byte[3];
            int k = socket.Receive(bb);
            string packet = "";
            for (int i = 0; i < k; i++)
                packet += (Convert.ToChar(bb[i]));

            MessageBox.Show(packet); 
            tcpclnt.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }
}
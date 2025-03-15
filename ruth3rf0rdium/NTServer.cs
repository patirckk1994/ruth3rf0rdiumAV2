/* Server Program */
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using ruth3rf0rdium; 

public class serv
{
    public serv(ListenerThreadManager mgr)
    {
        this.mgr = mgr;
    }
    ListenerThreadManager mgr;
    public void Main()
    {
        try
        {
            IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
            /* Initializes the Listener */
            TcpListener myList = new TcpListener(ipAd, 8001);
            /* Start Listeneting at the specified port */
            myList.Start();
            Console.WriteLine("The server is running at port 8001...");
            Console.WriteLine("The local End point is :" + myList.LocalEndpoint);
            Console.WriteLine("Waiting for a connection.....");
            Socket s = myList.AcceptSocket();
            Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
            byte[] b = new byte[3];
            int k = s.Receive(b);
            Console.WriteLine("Recieved...");
            string packet = "";
            for (int i = 0; i < k; i++)
                packet += (Convert.ToChar(b[i]));
            
            MessageBox.Show(packet);
            ASCIIEncoding asen = new ASCIIEncoding();
            s.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");
            /* clean up */
            s.Close();
            myList.Stop();
               
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
    }
}
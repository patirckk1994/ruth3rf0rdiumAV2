using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses
{
    public abstract class TCPConnection
    {
        public enum receivingstage
        {
            header,
            packet
        }
        public Thread receivethread;
       public Thread sendthread;
        public Mutex sendreceivemutex = new Mutex();
        public void sendpacket(rPacket packet)
        {
            lock (sendreceivemutex)
            {
                outgoingpackets.Enqueue(packet);
            }
        }
        public void startthreads()
        {
            receivethread = new Thread(new ThreadStart(receive));
            sendthread = new Thread(new ThreadStart(send));
            receivethread.Start();
            sendthread.Start();
        }
        public receivingstage currentstage = receivingstage.header;
        bool stopped = false;
         public Queue<rPacket> incomingpackets = new Queue<rPacket>();
        public Queue<rPacket> outgoingpackets = new Queue<rPacket>();
        
        public void init(TcpClient client)
        {
            this.client = client;
            startthreads();
        }
        public TcpClient client;
        public abstract void update();
        public void stop()
        {
            stopped = true;
        }
        public void receive()
        {
            while (!stopped)
            {
                byte[] headerbuffer = new byte[sizeof(int)];
                client.GetStream().Read(headerbuffer, 0, sizeof(int));
                int sizeheader = BitConverter.ToInt32(headerbuffer);
                byte[] receivedheader = new byte[sizeheader];
                client.GetStream().Read(receivedheader, 0, sizeheader);
                MemoryStream desezstream = new MemoryStream();
                desezstream.Write(receivedheader);
                desezstream.Seek(0, SeekOrigin.Begin);
                lock (sendreceivemutex)
                {
                   // MessageBox.Show(BitConverter.ToString(receivedheader));
                    incomingpackets.Enqueue(rPacket.deserialize(desezstream));
                }
            }
        }
        public void send()
        {
            while (!stopped)
            {
                rPacket outgoingpacket = null;
                lock (sendreceivemutex)
                {
                    if (outgoingpackets.Count != 0)
                    {
                        outgoingpacket = outgoingpackets.Dequeue();
                    }
                   
                }
                if (outgoingpacket != null)
                {
                    byte[] fulpacket;
                    byte[] ser = rPacket.serialize(outgoingpacket);
                
                    rPacket deseztest = (rPacket)rPacket.deserialize(new MemoryStream(ser));
                    fulpacket = new byte[sizeof(int) + ser.Length];
                    byte[] sizeheader = new byte[sizeof(int)];
                    sizeheader = BitConverter.GetBytes(ser.Length);
                    sizeheader.CopyTo(fulpacket,0);
                    for (int i = 0; i < ser.Length; i++)
                    {
                        fulpacket[sizeof(int) + i] = ser[i];
                    }
                    client.GetStream().Write(fulpacket,0,fulpacket.Length);
                }
               
            }
        }
    }
}

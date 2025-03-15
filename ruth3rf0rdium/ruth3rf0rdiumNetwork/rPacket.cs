using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.abstractclasses;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork
{
    [Serializable, XmlRoot("rPacket")]
    public class rPacket
    {
        
        public Dictionary<int,List<rPacket>> tmpPacketChainStorage =new Dictionary<int,List<rPacket>>();
        public void clearpacketchain()
        {
            tmpPacketChainStorage.Remove(AUTO_INCREMENT_PACKET_CHAIN_ID);
        }
        public void setuppacketchain()
        {
            AUTO_INCREMENT_PACKET_CHAIN_ID = DO_AUTO_INCREMENT_PACKET_CHAIN_ID();
            tmpPacketChainStorage[AUTO_INCREMENT_PACKET_CHAIN_ID] = new List<rPacket>();
            tmpPacketChainStorage[AUTO_INCREMENT_PACKET_CHAIN_ID].Add(this);
        }
        public void addtopacketchain(int id)
        {
            AUTO_INCREMENT_PACKET_CHAIN_ID = id;
            tmpPacketChainStorage[id].Add(this);
        }
        public List<string> headers = new List<string>();
        byte[] blob;
        int packetchainid = 0;
        static int AUTO_INCREMENT_PACKET_CHAIN_ID;
        public int DO_AUTO_INCREMENT_PACKET_CHAIN_ID()
        {
            return AUTO_INCREMENT_PACKET_CHAIN_ID++;
        }
        public void create_packet_XTOX_PROTO(string proto)
        {
            headers.Add(header_strings.header_XTOX_proto);
            headers.Add(proto);
        }
         public void create_packet_CTOA_responsive_REQ()
        {
            headers.Add(header_strings.header_CTOA_responsive_SYN);
        }
        public void create_packet_ATOC_responsive_RESP()
        {
            headers.Add(header_strings.header_ATOC_responsive_SYNACK);
            clearpacketchain();
        }
        public void create_packet_ATOC_NODE_ASSIGN(string nodeip, int nodeport)
        {
            headers.Add(header_strings.header_ATOC_NODE_ASSIGN);
            headers.Add(nodeip);
            headers.Add(Convert.ToString(nodeport));
        }
       public void create_packet_CTOA_SCAN_REQ_BLOB(string md5,byte[] blob)
        {
            headers.Add(header_strings.header_CTOA_SCAN_REQ_BLOB);
            this.blob = blob;
        }
        public void create_packet_CTOA_SCAN_REQ_MD5s(string md5)
        {
            headers.Add(header_strings.header_CTOA_SCAN_REQ_MD5);
            headers.Add(md5);
        }
        public void create_risk_assessment_packet(string MD5, bool safe, bool malware, bool risky)
        {
            
            headers.Add(Convert.ToString(safe));
            headers.Add(Convert.ToString(malware));
            headers.Add(Convert.ToString(risky));
            //headers.Add
        }
        public void create_packet_NTOC_DB_SYNC_MD5(string MD5, bool safe, bool malware, bool risky)
        {
            headers.Add(header_strings.header_NTOC_DB_SYNC_MD5);
            create_risk_assessment_packet(MD5, safe, malware, risky);
        }
        
        public void create_packet_ATON_DB_SYNC_MD5(string md5, bool safe, bool malware, bool risky)
        
            {
                headers.Add(header_strings.header_ATON_DB_SYNC_MD5);
                create_risk_assessment_packet(md5, safe, malware, risky);
            }
        public void create_packet_ATOC_SCAN_RESULT(string md5, bool safe, bool malware, bool risky)
        {
            
                headers.Add(header_strings.header_ATOC_SCAN_RESULT);
                create_risk_assessment_packet(md5, safe, malware, risky);
            }
        public void create_packet_ATON_SCAN_REQ_MD5(string md5)
        {
            headers.Add(header_strings.header_ATON_SCAN_REQ_md5);
        }
        public void create_packet_ATON_SCAN_REQ_blob(byte[] blob)
        {
            headers.Add(header_strings.header_ATON_SCAN_REQ_blob);
        }
        public void create_packet_ATON_LIST_SCANNERS()
        {
            headers.Add(header_strings.header_ATON_LIST_SCANNERS_REQ);
        }
        public void create_packet_NTOC_SCANNER_AVAILABLE_REQ()
        {
            headers.Add(header_strings.header_NTOC_SCANNER_AVAILABLE_REQ);
        }
        public void create_packet_CTON_SCANNER_AVAILABLE_RESULT(bool result)
        {
            headers.Add(header_strings.header_CTON_SCANNER_AVAILABLE_RESULT);
            headers.Add(Convert.ToString(result));
        }
        public void create_packet_NTOC_SCAN_REQ_BLOB(byte[] blob)
        {
            headers.Add(header_strings.header_NTOC_SCAN_REQ_BLOB);
            this.blob = blob;
        }
        public void create_packet_NTOC_SCAN_REQ_MD5(string md5)
        {
           
            headers.Add(header_strings.header_NTOC_SCAN_REQ_MD5);
            headers.Add(md5);
        }
        public void create_packet_CTON_SCAN_RESULT(string md5, bool safe, bool risky, bool malware)
        {
            headers.Add(header_strings.header_CTON_SCAN_RESULT);
            create_risk_assessment_packet(md5, safe, malware, risky);
            
        }
        public void create_packet_NTOA_SCAN_RESULT(string md5, bool safe, bool risky, bool malware)
        {
            headers.Add(header_strings.header_NTOA_SCAN_RESULT);
            create_risk_assessment_packet(md5, safe, malware, risky);
            
        }
        public void create_packet_ATON_ADD_FILE(byte[] blob)
        {
            headers.Add(header_strings.header_ATON_ADD_FILE);
            this.blob = blob;
        }
        public void create_packet_NTOC_ADD_FILE(byte[] blob)
        {
            headers.Add(header_strings.header_NTOC_ADD_FILE);
            this.blob = blob;
        }
        public string get_header_one() {
            return headers[0];
        }
        public void executepacket(TCPConnection sender)
        {
             
        }
        public static class proto_strings
        {
            public enum proto
            {
                NTOC,
                NTOA,
                CTON,
                CTOA,
                ATON,
                ATOC
            }
            public static string proto_NTOC = "NTOC";
            public static string proto_NTOA = "NTOA";
            public static string PROTO_CTON = "CTON";
            public static string PROTO_CTOA = "CTOA";
            public static string PROTO_ATON = "ATON";
            public static string PROTO_ATOC = "ATOC";
        }
        public static class header_strings
        {
            public static string header_XTOX_proto = "PROTO";

            
            public static string header_ATOC_responsive_SYNACK = "RESPONSIVE_SYNACK";
            public static string header_ATOC_NODE_ASSIGN = "NODE_ASSIGN";
            public static string header_ATOC_NODE_LIST = "NODE_LIST";
            public static string header_CTOA_responsive_SYN = "RESPONSIVE_SYN";
            public static string header_CTOA_SCAN_REQ_BLOB = "SCAN_REQ_BLOB";
            public static string header_CTOA_SCAN_REQ_MD5 = "SCAN_REQ_MD5";
            //string header_NTOC_DB_SYNC_FILE = "DB_SYNC_FILE";
            public static string header_NTOC_DB_SYNC_MD5 = "DB_SYNC_FILE";
            //string header_ATON_DB_SYNC_FILE = "DB_SYNC_FILE";
           

            public static string header_ATOC_SCAN_RESULT = "SCAN_RESULT";
            
            public static string header_ATON_DB_SYNC_MD5 = "DB_SYNC_FILE";
            public static string header_ATON_SCAN_REQ_md5 = "SCAN_REQ_MD5";
            public static string header_ATON_SCAN_REQ_blob = "SCAN_REQ_BLOB";
            public static string header_ATON_LIST_SCANNERS_REQ = "LIST_SCANNERS";
            public static string header_ATON_ADD_FILE = "ADD_FILE";

            public static string header_NTOA_LIST_SCANNERS_RESULT = "LIST_SCANNERS_RESULT";
            public static string header_NTOA_SCAN_RESULT = "SCAN_RESULT";

            public static string header_NTOC_SCANNER_AVAILABLE_REQ = "SCANNER_AVAILABLE_REQ";
            public static string header_NTOC_SCAN_REQ_MD5 = "SCAN_REQ";
            public static string header_NTOC_SCAN_REQ_BLOB = "SCAN_REQ";

            public static string header_CTON_SCANNER_AVAILABLE_RESULT = "SCANNER_AVAILABLE_RESULT";

            public static string header_CTON_SCAN_RESULT = "SCAN_RESULT";
           
           
            public static string header_NTOC_ADD_FILE = "ADD_FILE";
        }
       
        //make sure each node has the full db in its network including the auth server


        public void addheader( string headercontent)
        {
            headers.Add(headercontent);
        }


        public static byte[] serialize(rPacket s)
        {
            var serializer = new XmlSerializer(s.GetType());
            
            //MemoryStream finishedstream = new MemoryStream();
            MemoryStream memStream = new MemoryStream();
            XmlWriterSettings set = new XmlWriterSettings();
            set.Encoding = Encoding.UTF32;
            var wr = XmlWriter.Create(memStream,set);
            serializer.Serialize(wr, s);

            //finishedstream.Write(BitConverter.GetBytes((int)memStream.Length));
            //finishedstream.Write(memStream.GetBuffer());
            //MessageBox.Show(BitConverter.ToString(memStream.GetBuffer()));
            return memStream.GetBuffer();
        }
        public static rPacket deserialize(MemoryStream stream)
        {
           // XmlReaderSettings set = new XmlReaderSettings();
            
            XmlReader reader = XmlReader.Create(stream);
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(rPacket));
            
            return ((rPacket)xmlSerializer.Deserialize(reader));
            
        }
    }
}

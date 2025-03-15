using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruth3rf0rdium.ruth3rf0rdiumNetwork.protocol
{
    internal class transmission
    {
        public void AUTHSERVERSIDE_NET_ROUTINE_BROADCAST_CLIENT_DELTA(List<clientcontactdata> added, List<clientcontactdata> removed)
        {
        }
        public void AUTHSERVERSIDE_BROADCAST_FILE(byte[] file, string filename, string md5)
        {

        }
        public void CLIENTSIDE_BROADCAST_FILE(byte[] file, string filename, string md5)
        {

        }
        public bool AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE(string md5)
        {
            return false;
        }
        public void AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_REUEST(clientcontactdata client, string hash)
        {

        }
        public void AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_REQUEST_ONE_RECV(clientcontactdata client)
        {

        }
        public void AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_REQUEST_ONE_SEND(clientcontactdata client)
        {

        }
        public rPacket AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_RESPONSE_ONE_RECV(clientcontactdata client)
        {
            return null;
        }
        public rPacket AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_RESPONSE_ONE_SEND(clientcontactdata client)
        {
            return null;
        }
        public void AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_REUEST_TWO_SEND(clientcontactdata client)
        {
        }



        public void AUTHSERVERSIDE_NET_ROUTINE_FILE_EXISTS_ON_NODE_REUEST_TWO_RECV(clientcontactdata client)
        {

        }
        public void AUTHCLIENTSIDE_NET_ROUTINE_SET_SCANNER_AVAILABLE_REQUEST(nodeServercontactdata client)
        {

        }
        public rPacket AUTHCLIENTSIDE_NET_ROUTINE_SET_SCANNER_AVAILABLE_REQUEST_ONE_RECV(nodeServercontactdata client, bool value)
        {
            return null;
        }
        public void AUTHCLIENTSIDE_NET_ROUTINE_SET_SCANNER_AVAILABLE_REQUEST_ONE_SEND(nodeServercontactdata client, bool value)
        {

        }
        public void AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_REQUEST(clientcontactdata client, byte[] file)
        {

        }
        public void AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_REQUEST_ONE_SEND(clientcontactdata client, byte[] file)
        {

        }
        public void AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_REQUEST()
        {

        }
        public rPacket AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_REQUEST_ONE_RECV(clientcontactdata client, byte[] file)
        {
            return null;
        }



        public rPacket AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_RESPONSE_ONE_SEND(clientcontactdata client)
        {
            return null;
        }
        public rPacket AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_RESPONSE_ONE_RECV(clientcontactdata client)
        {
            return null;
        }
        public void AUTHSERVERSIDE_NET_ROUTINE_REQUEST_SCAN_RESPONSE_TWO_SEND(clientcontactdata client)
        {

        }
        public void NODESIDE_NET_ROUTINE_ADD_CLIENT_DELTA_REQUEST(authorityservercontactdata server, List<clientcontactdata> clientsremoved, List<clientcontactdata> clientsadded)
        {
        }
        public rPacket NODESIDE_NET_ROUTINE_ADD_CLIENT_DELTA_REQUEST_RECV(authorityservercontactdata server, List<clientcontactdata> clientsremoved, List<clientcontactdata> clientsadded)
        {
            return null;
        }
        public void NODESIDE_NET_ROUTINE_ADD_CLIENT_DELTA_REQUEST_SEND(authorityservercontactdata server, List<clientcontactdata> clientsremoved, List<clientcontactdata> clientsadded)
        {
        }
        public void NODESIDE_NET_ROUTINE_SEND_DATABASE_TO_CLIENT_ONE_SEND(clientcontactdata client, CROWDAVDB db)
        {

        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_NODE(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_CLIENT(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_NODE_SEND(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_CLIENT_SEND(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_NODE_RECV(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_DATABASE_TO_CLIENT_RECV(nodeServercontactdata node, CROWDAVDB db)
        {
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_NODESERVERLIST_TO_CLIENT(clientcontactdata client)
        {
            
        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_NODESERVERLIST_TO_CLIENT_SEND(clientcontactdata client)
        {


        }
        public void AUTHORITYSERVERSIDE_NET_ROUTINE_SEND_NODESERVERLIST_TO_CLIENT_RECV(clientcontactdata client)
        {

        }
    }
}

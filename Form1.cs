using System.Net;
using ruth3rf0rdium.ruth3rf0rdiumNetwork;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.AUTHORITYSERVER;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.CLIENT;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.NODESERVER;
using ruth3rf0rdium.ruth3rf0rdiumNetwork.SCANAPIDATAINTERPRETERServer;
namespace ruth3rf0rdium
{
    public partial class Form1 : Form
    {
        public AV avinstance = new AV();
        public static Form1 instance;
        public Form1()
        {
            Form1.instance= this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            NODE_LISTENER nl = new NODE_LISTENER();
            nl.listen(1337);
            CL_CONNECTIONTONODESERVER ctn = new CL_CONNECTIONTONODESERVER();
            ctn.connect("127.0.0.1", 1337);
            rPacket r = new rPacket();
            r.addheader("schmuso");
            ctn.sendpacket(r);
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var filex = openFileDialog1.OpenFile();
            long len = new FileInfo(openFileDialog1.FileName).Length;
            byte[] file = new byte[len];
            filex.Read(file, 0, (int)len);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            avinstance.update();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            avinstance.al = new AUTH_LISTENER();
            avinstance.al.listen(Convert.ToInt32(textBox9.Text));
            lblauth.Text = "Online";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            avinstance.nctas = new NODE_CONNECTIONTOAUTHORITYSERVER();
            avinstance.nctas.connect(textBox1.Text, Convert.ToInt32(textBox2.Text));
            if (avinstance.nctas.client.Connected)
            {
                lblNodeToAuth.Text = "Online";
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            avinstance.cctas = new CL_CONNECTIONTOAUTHORITYSERVER();
            avinstance.cctas.connect(textBox4.Text, Convert.ToInt32(textBox3.Text));
            if (avinstance.cctas.client.Connected)
                lblClientToAuth.Text = "Online";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            avinstance.cctns = new CL_CONNECTIONTONODESERVER();
            avinstance.cctns.connect(textBox6.Text, Convert.ToInt32(textBox5.Text));
            if (avinstance.cctns.client.Connected)
                lblClientToNode.Text = "Online";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            avinstance.nl = new NODE_LISTENER();
            avinstance.nl.listen(Convert.ToInt32(textBox7.Text));
            lblnode.Text = "Online";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            avinstance.sl = new SADI_LISTENER();
            avinstance.sl.listen(Convert.ToInt32(textBox11.Text));

            lblsadi.Text = "Online";
        }

        private void button15_Click(object sender, EventArgs e)
        {

            lblnode.Text = "Offline";
            avinstance.nl.stoplistening();
            avinstance.nl = null;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            lblsadi.Text = "Offline";
            avinstance.sl.stoplistening();
            avinstance.sl = null;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            lblauth.Text = "Offline";
            avinstance.al.stoplistening();
            avinstance.al = null;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            lblClientToNode.Text = "Offline";
            avinstance.cctns.stop();
            avinstance.cctns = null;
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            avinstance.cctas.stop();
            lblClientToAuth.Text = "Offline";
            avinstance.cctas.stop();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

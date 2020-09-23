using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SkieHacker_URL_Shortener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebClient oc = new WebClient();
        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter a Valid URL");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter a Valid URL Name, it will be use as.\n Example: (www.youtube.com/(NAME).html)");
                return;
            }
            string originlink = textBox1.Text;
            string originlinkz = oc.DownloadString("https://pastebin.com/raw/hdCWMr12");
            string originlinks = oc.DownloadString("https://pastebin.com/raw/4npTVfh5");
            string combine = originlinks + originlink + originlinkz;
            richTextBox1.Text = combine;
            File.WriteAllText(textBox3.Text + ".html", combine);

            WebClient client = new WebClient();
            try
            {
                client.Proxy = null;
                client.Credentials = new NetworkCredential("username", "password");
                client.UploadFile("FTP PATH" + textBox3.Text + ".html", textBox3.Text + ".html");
            }
            catch (Exception)
            {
                MessageBox.Show("An Error has been Occurred during Uploading of the URL to the Server");
                return;
            }
            string bc = "YOUR LINK PATH, EXAMPLE: https://pandatechnology.000webhostapp.com/OtherScript/" + textBox3.Text + ".html";
            textBox2.Text = bc;
            await Task.Delay(1000);
            if (File.Exists(textBox3.Text + ".html"))
            {
                File.Delete(textBox3.Text + ".html");
            }
            MessageBox.Show("Operation Complete...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();    //Clear if any old value is there in Clipboard        
            Clipboard.SetText(textBox2.Text);
        }
    }
}

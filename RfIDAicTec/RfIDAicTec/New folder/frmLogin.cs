using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Data.OleDb; 
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CBEDesktopApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SQLConn.getData();
                      
        }
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        public class tokens
        {

            public string token { get; set; }
            public string tokenType { get; set; }
            public int expireIn { get; set; }

        }
        public bool  CallServicePost(string url, object request)
        {
            bool accept = false;
            string messageResponse = "";
          
                try
                {
                    Uri myUri = new Uri(url, UriKind.Absolute);
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "Post";
                    httpWebRequest.Timeout = 30000;
                    //httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, token);
                    var results = "";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(JsonConvert.SerializeObject(request));
                    }
                    HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    Stream response = httpResponse.GetResponseStream();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        results = streamReader.ReadToEnd();
                    }

                tokens token = new tokens();
                token = JsonConvert.DeserializeObject<tokens>(results);
                //System.Reflection.PropertyInfo pi = messageResponsex.GetType().GetProperty("");
                //String name = (String)(pi.GetValue(messageResponsex, null));
                SQLConn.Token = token.token;
                //messageResponse = messageResponsex.ToString();
                    accept = true;
                }
                catch (Exception ex)
                {
                    var e = ex.ToString();
                    accept = false;

                    messageResponse = e;
                }
            

            return accept;


        }
        private void Login()
        {
            User user = new User();
            user.Username = txtusername.Text;
            user.Password = txtPassword.Text;
            var url = SQLConn.loginUrl;
          var accept =  CallServicePost(url, user);
            if (accept == true)
            {
                this.Hide();
                frmmain main = new frmmain();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong Password or User Name");
            }
                
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnOkay_Click_1(object sender, EventArgs e)
        {
            Login();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
               
            }
            if (e.KeyCode == Keys.F12)
            {
                frmDatabaseConfig asd = new frmDatabaseConfig();
                asd.Show();
            }
        }

        
    }
}

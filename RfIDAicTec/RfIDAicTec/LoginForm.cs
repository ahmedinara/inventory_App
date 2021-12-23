using Newtonsoft.Json;
using RfIDAicTec.Models;
using RfIDAicTec.Sheard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RfIDAicTec
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        public class User
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
        private void Login()
        {
            HttpClientService httpClientService = new HttpClientService();
                
            User user = new User();
            user.Email = txtusername.Text;
            user.Password = txtPassword.Text;
            var url = "http://40.88.5.47:8002/User/Login";
            var result = httpClientService.CallServicePost(url, user,"");
            if (result != "Filed")
            {
                TokenRespons tokenRespons = JsonConvert.DeserializeObject<TokenRespons>(result);
                UserData.UserToken = tokenRespons.Token;
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else
                MessageBox.Show("Wrong Password or User Name");
           


        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}

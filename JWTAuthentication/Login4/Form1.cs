using Login4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Login4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            var UserLogin = new UserLogin
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
            };

            var json = JsonConvert.SerializeObject(UserLogin);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7223/");
            var result = await client.PostAsync("api/Authenticate/login", content);
            string resultContent = await result.Content.ReadAsStringAsync();

           // var info = JsonConvert.DeserializeObject<UserLogin>(resultContent);

            string r = resultContent.Remove(0, 10);
            
            string res = r.Remove(r.Length -2);
           
            
            if (((int)result.StatusCode) == 200)
            {

                this.Hide();
                Book book = new Book();
                ProtectToken.DateProtection(res);

                book.ShowDialog();
                this.Close();


                //MessageBox.Show(res); 
            }

            else
            {
                MessageBox.Show("Password or username wrong");
            }
        }

        
    }
}

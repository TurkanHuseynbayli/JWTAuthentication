using Login4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login4
{
   
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        public class Response
        {
            public string Status { get; set; }
            public string Message { get; set; }
        }
        
        //private async void btnDetail_Click(object sender, EventArgs e)
        //{


        //    //switch (UserRoles.Admin)
        //    //{
        //    //    case "txtUsername.Text":

        //    //        btnUpdate.Enabled = true;
        //    //        btnDelete.Enabled = false;

        //    //        break;
        //    //    case "sky":

        //    //        btnDelete.Enabled = false;

        //    //        break;
        //    //}




        //    //var StudentForm = new StudentForm
        //    //{
        //    //     Name =txtName.Text,    
        //    //     Surname=txtSurname.Text,   
        //    //     Age=txtAge.Text,
        //    //     Address=txtAddress.Text,

        //    //};
        //    // var json = JsonConvert.SerializeObject(StudentForm);
        //    // var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpClient client = new HttpClient();
        //    var token = ProtectToken.Decrypt(ProtectToken.PrToken);
        //    client.BaseAddress = new Uri("https://localhost:7223/");
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //    client.BaseAddress = new Uri("https://localhost:7223/");
        //    var result = await client.GetAsync("api/Student");

        //    Get();

        //    //string resultContent = await result.Content.ReadAsStringAsync();

        //    //var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent);

        //    //dataGridView1.DataSource = info;




        //    //if (((int)result.StatusCode) == 200)
        //    //{
        //    // //   var info = JsonConvert.DeserializeObject<Student>(resultContent);
        //    //    // dataGridView1.DataSource = resultContent.ToList();

        //    //    //  response = JsonConvert.DeserializeObject<Response>(resultContent);
        //    //    //dataGridView1.Show();
        //    //    //View.List.ToString(resultContent);
        //    //    // Student obj = studentBindingSource1.Current as Student;
        //    //    //dataGridView1.DataSource = resultContent;   
        //    //    //  studentBindingSource1.DataSource = resultContent;
        //    //  //  MessageBox.Show(info.ToString());
        //    // //   MessageBox.Show(resultContent);
        //    //}

        //    //else
        //    //{
        //    //    MessageBox.Show("Password or username wrong");
        //    //}
        //}

        private async void Student_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Student");

            string resultContent = await result.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent);

            dataGridView1.DataSource = info;
            
            this.dataGridView1.AllowUserToAddRows = false;
        }
        
        private async void button3_Click(object sender, EventArgs e)
        {
            var StudentForm = new StudentForm
            {
               
                Name =txtName.Text,
                Surname=txtSurname.Text,
                Age= Convert.ToInt32(txtAge.Text),
                Address =txtAddress.Text,

            };
         
            var json = JsonConvert.SerializeObject(StudentForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7223/");
            var result = await client.PostAsync("api/Student", content);

            string resultContent = await result.Content.ReadAsStringAsync();
          
            if (((int)result.StatusCode) == 200)
            {

               // MessageBox.Show("Student created successfully!");
              
                var result2 = await client.GetAsync("api/Student");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent2);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = info;
            }

            else
            {
                MessageBox.Show("Error");
            }

        }

        //private async void btnUpdate_Click(object sender, EventArgs e)
        //{

        //    //var StudentForm = new StudentForm
        //    //{

        //    //    Name = txtName.Text,
        //    //    Surname = txtSurname.Text,
        //    //    Age = Convert.ToInt32(txtAge.Text),
        //    //    Address = txtAddress.Text,

        //    //};

        //    //var json = JsonConvert.SerializeObject(StudentForm);
        //    //var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    //HttpClient client = new HttpClient();

        //    //client.BaseAddress = new Uri("https://localhost:7223/");

        //    //var result = await client.PutAsync("api/Student", content);
        //    //string resultContent = await result.Content.ReadAsStringAsync();

        //    //MessageBox.Show(resultContent);
        //    //if (((int)result.StatusCode) == 200)
        //    //{

        //    //    MessageBox.Show(resultContent);
        //    //}

        //    //else
        //    //{
        //    //    MessageBox.Show("Error");
        //    //}

        //    //using (var client2 = new HttpClient())
        //    //{
        //    //    List<string> param = new List<string>();
        //    //    param.Add(txtName.Text);
        //    //    param.Add(txtSurname.Text);
        //    //    param.Add(txtAddress.Text);
        //    //    client2.DefaultRequestHeaders.Accept.Clear();
        //    //    client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    //    HttpResponseMessage rsp = client.PutAsync("https://localhost:7223" + "/api/Student/1" + param).Result;
        //    //}




        //    //using (var client = new HttpClient())
        //    //{
        //    //    //List<string> param = new List<string>();
        //    //    //param.Add(txtName.Text);
        //    //    //param.Add(txtSurname.Text);
        //    //    //param.Add(txtAddress.Text);

        //    //    var StudentForm = new StudentForm
        //    //    {
        //    //    Name = txtName.Text,
        //    //    Surname = txtSurname.Text,
        //    //    Age = Convert.ToInt32(txtAge.Text),
        //    //    Address = txtAddress.Text,

        //    //    };

        //    //string WebApiUrl = "https://localhost:7223";

        //    //string jsonString = JsonConvert.SerializeObject(StudentForm);
        //    //var requestUrl = new Uri(WebApiUrl + "/api/Student/");
        //    //using (HttpContent httpContent = new StringContent(jsonString))
        //    //{
        //    //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    //    HttpResponseMessage response = client.PutAsync(requestUrl, httpContent).Result;
        //    //    string resultContent = await response.Content.ReadAsStringAsync();
        //    //    MessageBox.Show(resultContent);
        //    //}
        //    //}

        //}

        //private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{


          

        //    // string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        //    //StudentForm obj = studentBindingSource.Current as StudentForm;

        //    //HttpClient client = new HttpClient();

        //    //client.BaseAddress = new Uri("https://localhost:7223/");
        //    //var result = await client.GetAsync("api/Student");



        //    //string resultContent = await result.Content.ReadAsStringAsync();

        //    //var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent);

        //    //dataGridView1.DataSource = info;

        //}

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
     
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtSurname.Text = row.Cells[2].Value.ToString();
            txtAge.Text = row.Cells[3].Value.ToString();
            txtAddress.Text = row.Cells[4].Value.ToString();
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            var StudentForm = new StudentForm
            {
                Id=Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Address = txtAddress.Text,
            };

            var json = JsonConvert.SerializeObject(StudentForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7223/");

            var result = await client.PutAsync($"api/Student/{txtId.Text}", content);

            string resultContent = await result.Content.ReadAsStringAsync();

          
            //MessageBox.Show(resultContent);
            if (((int)result.StatusCode) == 200)
            {

               // MessageBox.Show("Updated!");

                var result2 = await client.GetAsync("api/Student");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent2);
                dataGridView1.DataSource = info;
            }

            else
            {
                MessageBox.Show("Error");
            }
        }
    
       
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7223/");

            var result = await client.DeleteAsync($"api/Student/{txtId.Text}");

            string resultContent = await result.Content.ReadAsStringAsync();


            //Response response = new Response();
            //if (resultContent.Contains("false"))
            //{

            //    response = JsonConvert.DeserializeObject<Response>(resultContent);
            //    var errorMessage = $"{response.Message}";
            //    MessageBox.Show(errorMessage);

            //}

            //MessageBox.Show(resultContent);
           
            if (((int)result.StatusCode) == 200)
            {
               
                //MessageBox.Show("Deleted!");
                var result2 = await client.GetAsync("api/Student");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent2);
                dataGridView1.DataSource = info;
             }

            else
            {
                MessageBox.Show("Error");
            }
        }


        //private async void Get()
        //{
        //    HttpClient client = new HttpClient();
        //    var result = await client.GetAsync("api/Student");

        //    string resultContent = await result.Content.ReadAsStringAsync();

        //    var info = JsonConvert.DeserializeObject<List<StudentForm>>(resultContent);
        //    dataGridView1.DataSource = info;
        //}
    }
}

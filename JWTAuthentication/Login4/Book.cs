using Login4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login4
{
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private async void Book_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var result = await client.GetAsync("api/Book");

            string resultContent = await result.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<List<BookForm>>(resultContent);

            dataGridView1.DataSource = info;

            this.dataGridView1.AllowUserToAddRows = false;

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Author";
            comboBox1.DataSource = info;    
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var BookForm = new BookForm
            {

                Name = txtName.Text,
                Author = txtAuthor.Text,

            };

            var json = JsonConvert.SerializeObject(BookForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7223/");
            var result = await client.PostAsync("api/Book", content);

            string resultContent = await result.Content.ReadAsStringAsync();

            if (((int)result.StatusCode) == 200)
            {

                // MessageBox.Show("Student created successfully!");

                var result2 = await client.GetAsync("api/Book");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<BookForm>>(resultContent2);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = info;
            }

            else
            {
                MessageBox.Show("Error");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            txtAuthor.Text = row.Cells[2].Value.ToString();
           
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var BookForm = new BookForm
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Author = txtAuthor.Text,
            };

            var json = JsonConvert.SerializeObject(BookForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var token = ProtectToken.Decrypt(ProtectToken.PrToken);
            client.BaseAddress = new Uri("https://localhost:7223/");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("https://localhost:7223/");

            var result = await client.PutAsync($"api/Book/{txtId.Text}", content);

            string resultContent = await result.Content.ReadAsStringAsync();


            //MessageBox.Show(resultContent);
            if (((int)result.StatusCode) == 200)
            {

                // MessageBox.Show("Updated!");

                var result2 = await client.GetAsync("api/Book");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<BookForm>>(resultContent2);
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

            var result = await client.DeleteAsync($"api/Book/{txtId.Text}");

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
                var result2 = await client.GetAsync("api/Book");

                string resultContent2 = await result2.Content.ReadAsStringAsync();

                var info = JsonConvert.DeserializeObject<List<BookForm>>(resultContent2);
                dataGridView1.DataSource = info;
            }

            else
            {
                MessageBox.Show("Error");
            }
        }

        private  void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          BookForm form = (BookForm)comboBox1.SelectedItem;
            txtId.Text = form.Id.ToString();
            txtName.Text = form.Name.ToString();  
            txtAuthor.Text = form.Author.ToString();


             

        }
    }
}

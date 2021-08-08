using DukyanWinUI.DTOClasses;
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

namespace DukyanWinUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44339/api/");
                Task<HttpResponseMessage> getTask = client.GetAsync("home/getstock");

                HttpResponseMessage result = new HttpResponseMessage();

                try
                {
                    result = getTask.Result;
                }
                catch (Exception)
                {
                    MessageBox.Show("DepoAPI bağlantıyı reddetti");
                    return;
                }

                if (result.IsSuccessStatusCode)
                {
                    string contentString = await getTask.Result.Content.ReadAsStringAsync();

                    StockDTO[] resultContent = JsonConvert.DeserializeObject<StockDTO[]>(contentString);


                    string[] lstViewItems = new string[resultContent.Length];


                    foreach (StockDTO element in resultContent)
                    {
                        lstViewItems = new string[] { element.ID.ToString(), element.UnitPrice.ToString(), element.UnitInStock.ToString(), element.ProductName };
                        ListViewItem item = new ListViewItem(lstViewItems);
                        listView1.Items.Add(item);
                    }

                    label2.Text = listView1.Items.Count.ToString();

                    
                }
                else
                {
                    MessageBox.Show("DepoAPI ile ilgili bir sorun oluştu");
                }
            }



            //Diğer yolu bu, bu yolun tek sıkıntısı API kapalıysa yada çalışmıyorsa bu proje patlıyor.

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44339/api/");
            //    HttpResponseMessage gettask = await client.GetAsync("home/getstock");
            //    gettask.EnsureSuccessStatusCode();

            //    string contentstring = await gettask.Content.ReadAsStringAsync();

            //    StockDTO[] resultcontent = JsonConvert.DeserializeObject<StockDTO[]>(contentstring);

            //    lstBox.Items.AddRange(resultcontent);
            //}
        }
    }
}


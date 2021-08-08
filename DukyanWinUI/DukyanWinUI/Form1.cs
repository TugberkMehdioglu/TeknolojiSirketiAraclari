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
                        ListViewItem listItem = new ListViewItem(lstViewItems);
                        lstView.Items.Add(listItem);
                    }

                    label2.Text = lstView.Items.Count.ToString();


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

        private void txtID_Click(object sender, EventArgs e)
        {
            txtID.Clear();
        }

        private void txtAmount_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (listStock.Count > 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44339/api/");
                    Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Home/StockDrop", listStock);

                    HttpResponseMessage result;

                    try
                    {
                        result = postTask.Result;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("DepoAPI bağlantıyı reddetti");
                        return;
                    }

                    if (result.IsSuccessStatusCode)
                    {
                        listStock.Clear();//List içindeki ürünler temizlendi
                        lstBox.Items.Clear();//ListBox'taki gösterge temizlendi
                        MessageBox.Show("Sipariş tamamlandı");
                    }
                    else MessageBox.Show("DepoAPI ile ilgili bir sorun oluştu");
                }
            }
            else MessageBox.Show("Lütfen sipariş edilecek ürünleri ekleyiniz");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lstView.Items.Clear();
            Form1_Load(sender, e);
        }

        //DepoAPI'daki StockDrop action'ı List<StockDropDTO> tipinde argüman istiyor.
        List<StockDropDTO> listStock = new List<StockDropDTO>();

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtAmount.Text)) && (!(txtID.Text == "Satın alınacak ürün ID") && !(txtAmount.Text == "Miktar")))
            {
                int id;
                short amount;

                try
                {
                    id = Convert.ToInt32(txtID.Text);
                    amount = Convert.ToInt16(txtAmount.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen ID ve Miktar kısımlarında geçerli format kullanınız");
                    return;
                }

                listStock.Add(new StockDropDTO { ID = id, Quantity = amount });

                lstBox.Items.Add($"{id} ID'li üründen {amount} adet.");
            }
            else MessageBox.Show("Lütfen gerekli alanları boş bırakmayınız");
        }
    }
}


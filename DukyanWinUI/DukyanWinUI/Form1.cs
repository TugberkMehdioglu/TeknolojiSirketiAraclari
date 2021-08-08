using DukyanWinUI.DesignPatterns.SingletonPattern;
using DukyanWinUI.DTOClasses;
using DukyanWinUI.Models.Context;
using DukyanWinUI.Models.Entities;
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
        MyContext _db;
        public Form1()
        {
            InitializeComponent();
            _db = DBTool.DBInstance;
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
            //Flat null geçilebilir müstakil daireler için
            if (listStock.Count > 0 && (!string.IsNullOrEmpty(txtFullName.Text) && (!string.IsNullOrEmpty(txtPhone.Text)) && (!string.IsNullOrEmpty(txtCountry.Text) && (!string.IsNullOrEmpty(txtCity.Text)) && (!string.IsNullOrEmpty(txtNeighborhood.Text)) && (!string.IsNullOrEmpty(txtStreet.Text)) && (!string.IsNullOrEmpty(txtAptNo.Text)) && (!string.IsNullOrEmpty(txtDistrcit.Text)))))
            {
                //AptNo ve FlatNo prop'ları byte tipinde olduğu için try ile kontrolü sağlandı
                byte aptNo;
                byte flatNo;

                try
                {
                    aptNo = Convert.ToByte(txtAptNo.Text);
                    flatNo = Convert.ToByte(txtFlat.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen AptNo ve KapıNo kısımlarını doğru giriniz");
                    return;
                }

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

                        Order myOrder = new Order
                        {
                            FullName = txtFullName.Text,
                            Phone = txtPhone.Text,
                            Country = txtCountry.Text,
                            City = txtCity.Text,
                            District = txtDistrcit.Text,
                            Neighborhood = txtNeighborhood.Text,
                            Street = txtStreet.Text,
                            AptNo = aptNo,
                            Flat = flatNo
                        };

                        //for (int i = 0; i < listStock.Count; i++)
                        //{
                        //    myOrder.ProductID[i]=
                        //}

                        foreach (StockDropDTO item in listStock)
                        {
                            myOrder.ProductID = new string[] { item.ID.ToString() };
                            myOrder.Amount = item.Quantity;
                        }

                        _db.Orders.Add(myOrder);
                        _db.SaveChanges();

                        MessageBox.Show("Sipariş tamamlandı");
                    }
                    else MessageBox.Show("DepoAPI ile ilgili bir sorun oluştu");
                }
            }
            else MessageBox.Show("Lütfen sipariş edilecek ürünleri ve teslimat bilgilerinin eksiksiz olduğundan emin olun");


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
                    MessageBox.Show("Lütfen ID ve Miktar kısımlarına sadece sayı giriniz");
                    return;
                }

                listStock.Add(new StockDropDTO { ID = id, Quantity = amount });

                lstBox.Items.Add(listStock.LastOrDefault());

                txtID.Clear();
                txtAmount.Clear();
            }
            else MessageBox.Show("Lütfen gerekli alanları boş bırakmayınız");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstBox.SelectedIndex > -1)
            {
                StockDropDTO toBeDeleted = (lstBox.SelectedItem as StockDropDTO);
                listStock.Remove(toBeDeleted);
                lstBox.Items.Remove(lstBox.SelectedItem);
            }
            else MessageBox.Show("Sipariş Listesinden silmek istediğiniz ürünü seçin");
        }

        private void txtFullName_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.Clear();
        }

        private void txtCountry_Click(object sender, EventArgs e)
        {
            txtCountry.Clear();
        }

        private void txtCity_Click(object sender, EventArgs e)
        {
            txtCity.Clear();
        }

        private void txtDistrcit_Click(object sender, EventArgs e)
        {
            txtDistrcit.Clear();
        }

        private void txtNeighborhood_Click(object sender, EventArgs e)
        {
            txtNeighborhood.Clear();
        }

        private void txtStreet_Click(object sender, EventArgs e)
        {
            txtStreet.Clear();
        }

        private void txtAptNo_Click(object sender, EventArgs e)
        {
            txtAptNo.Clear();
        }

        private void txtFlat_Click(object sender, EventArgs e)
        {
            txtFlat.Clear();
        }
    }
}


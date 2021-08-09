using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukyanWinUI.Models.Entities
{
    //Ürünleri WinUi'da tutmak istemiyoruz, sadece DepoAPI'dan görüntülemesini yapıyoruz
    public class Product
    {
        public int ID { get; set; }

        //Relational Properties
        public List<OrderDetail> Details { get; set; }

    }
}

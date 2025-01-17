﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankaAPI.DTOClasses
{
    //Diğer sitelerin bize yollicağı veride istediğimiz bilgileri bu class'ta property olarak veriyoruz
    public class PaymentDTO
    {
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string SecurityNumber { get; set; }
        public string CardNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardExpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}
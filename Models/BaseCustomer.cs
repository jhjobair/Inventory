using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BaseCustomer
    {
        public string Name { get; set; }
        public int TotalSell { get; set; }
        public DateTime SellDate { get; set; }
        public int CustomerId { get; set; }


        public List<BaseCustomer> CustomerList { get; set; }

        public static List<BaseCustomer> ListCustomerData()
        {
            List<BaseCustomer> listCustomer = new List<BaseCustomer>();

            Random random = new Random();

            for(int i=0; i < 40; i++)
            {
                BaseCustomer customer = new BaseCustomer();
                customer.Name = "Customer_"+ random.Next(1, 45).ToString();
                customer.TotalSell = random.Next(1, 16);
                customer.SellDate = DateTime.Now;
                customer.CustomerId = random.Next(1, 11);
                listCustomer.Add(customer);
            }
          

            return listCustomer;
        }


    }
}
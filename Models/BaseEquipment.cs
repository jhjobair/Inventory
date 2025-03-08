
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BaseEquipment
    {
        public string Name { get; set; }
        public int EcCount { get; set; }
        public DateTime DateEntry { get; set; }

        public List<BaseEquipment> ListEquipment { get; set; }

        public BaseEquipment()
        {
            ListEquipment = new List<BaseEquipment>();
        }

        public static List<BaseEquipment> ListEquipmentData()
        {
            List<BaseEquipment> list = new List<BaseEquipment>();
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                BaseEquipment baseEquipment = new BaseEquipment();
                baseEquipment.Name = "Laptop_" + i.ToString();
                baseEquipment.EcCount = random.Next(1, 50);
                baseEquipment.DateEntry = DateTime.Now.Date;
                list.Add(baseEquipment);
            }
            return list;
        }
    }
}

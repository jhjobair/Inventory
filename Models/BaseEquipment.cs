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

        public List<BaseEquipment> ListEquipment {  get; set; }

        public BaseEquipment()
        {
            ListEquipment = new List<BaseEquipment>();
        }

        public static List<BaseEquipment> ListEquipmentData()
        {
            List<BaseEquipment> list = new List<BaseEquipment>();

            BaseEquipment baseEquipment = new BaseEquipment();
            baseEquipment.Name = "Laptop";
            baseEquipment.EcCount = 4;
            baseEquipment.DateEntry = DateTime.Now.Date;
            list.Add(baseEquipment);

            baseEquipment = new BaseEquipment();
            baseEquipment.Name = "Mouse";
            baseEquipment.EcCount = 5;
            baseEquipment.DateEntry = DateTime.Now.Date;
            list.Add(baseEquipment);

            baseEquipment = new BaseEquipment();
            baseEquipment.Name = "Keyboard";
            baseEquipment.EcCount = 5;
            baseEquipment.DateEntry = DateTime.Now.Date;
            list.Add(baseEquipment);

            return list;
        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Modules
{
    public class Device
    {
        public string Brend { get; set; }            // бренд
        public string  DeviceName { get; set; }      // название техники
        public int Price { get; set; }               // цена
        public string PersonInCharge { get; set; }   // ответственное лицо
        public int Quantity { get; set; }            // количество
        public int WarrantyPeriod { get; set; }      // срок гарантии
        
        public void Show()
        {
            Console.WriteLine($"Brend: {Brend}, DeviceName: {DeviceName}, Price: {Price}, PersonInCharge: {PersonInCharge}, Quantity: {Quantity}, WarrantyPeriod: {WarrantyPeriod}");
        }
    }

    
}

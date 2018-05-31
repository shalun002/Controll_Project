using Devices.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public enum IBrend { Samsung, DELL, HP, BENQ, XEROX, CISCO, PANASONIC }
    public enum DeviceName { Printer, PC, Monitor, Telephone, Scaner, Mouse, Progector }

    public class ServiceDevice
    {
        private Random rand = new Random();

        public string pathDevice = @"DeviceInfo.txt";
        public List<Device> devices;

        public ServiceDevice()
        {
            devices = new List<Device>();
        }

        public void DeviceGenerator()
        {
            for (int i = 0; i < rand.Next(1, 20); i++)
            {
                Device device = new Device();

                device.Brend = ((IBrend)rand.Next(0, 8)).ToString();
                device.DeviceName = ((DeviceName)rand.Next(0, 8)).ToString();
                device.Price = rand.Next(10000, 100000);
                device.Quantity = rand.Next(1, 100);
                device.WarrantyPeriod = rand.Next(1, 5);
                devices.Add(device);
            }
        }
    }
}

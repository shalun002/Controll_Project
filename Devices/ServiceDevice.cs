﻿using Devices.Modules;
using Path;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Devices
{
    public class ServiceDevice
    {
        private PathInfo path = new PathInfo();

        public List<Device> devices = new List<Device>();

        /// <summary>
        /// Добавление устройств в коллекцию
        /// </summary>
        public void AddDevice()
        {
            Device device = new Device();

            Console.Write("Введите название Бренда: ");
            device.Brend = Console.ReadLine();

            Console.Write("Введите название устройства: ");
            device.DeviceName = Console.ReadLine();

            Console.Write("Введите колличество: ");
            device.Quantity = Int32.Parse(Console.ReadLine());

            Console.Write("Введите цену устройства: ");
            device.Price = int.Parse(Console.ReadLine());

            Console.Write("Введите срок гарантии: ");
            device.WarrantyPeriod = int.Parse(Console.ReadLine());

            Console.Write("Введите ответственное лицо: ");
            device.PersonInCharge = Console.ReadLine();

            if (isExistsDevice(device))
            {
                devices.Add(device);
                addDeviceToXml(device);
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Console.WriteLine();
                Console.WriteLine("Товар добавлен успешно!!!");
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Thread.Sleep(1200);
                Console.Clear();

            }
        }

        private bool isExistsDevice(Device device)
        {
            if (devices.Where(w => w.DeviceName == device.DeviceName).Count() > 0)
            {
                Console.WriteLine("Такой товар уже существует");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Запись в Xml файл
        /// </summary>
        private void addDeviceToXml(Device dev)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Device");

            XmlElement Brend = doc.CreateElement("Brend");
            Brend.InnerText = dev.Brend;
            xcom = doc.CreateComment("Бренд устройства");
            Brend.AppendChild(xcom);

            XmlElement DeviceName = doc.CreateElement("DeviceName");
            DeviceName.InnerText = dev.DeviceName;
            xcom = doc.CreateComment("Название устройства");
            DeviceName.AppendChild(xcom);

            XmlElement Price = doc.CreateElement("Price");
            Price.InnerText = dev.Price.ToString();
            xcom = doc.CreateComment("Стоимость устройства");
            Price.AppendChild(xcom);

            XmlElement PersonInCharge = doc.CreateElement("PersonInCharge");
            PersonInCharge.InnerText = dev.PersonInCharge;
            xcom = doc.CreateComment("Ответственное лицо");
            PersonInCharge.AppendChild(xcom);

            XmlElement Quantity = doc.CreateElement("Quantity");
            Quantity.InnerText = dev.Quantity.ToString();
            xcom = doc.CreateComment("Количество");
            Quantity.AppendChild(xcom);

            XmlElement WarrantyPeriod = doc.CreateElement("WarrantyPeriod");
            WarrantyPeriod.InnerText = dev.WarrantyPeriod.ToString();
            xcom = doc.CreateComment("Количество");
            WarrantyPeriod.AppendChild(xcom);

            elem.AppendChild(Brend);
            elem.AppendChild(DeviceName);
            elem.AppendChild(Price);
            elem.AppendChild(PersonInCharge);
            elem.AppendChild(Quantity);
            elem.AppendChild(WarrantyPeriod);

            doc.DocumentElement.AppendChild(elem);
            doc.Save(path.pathDevice);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(path.pathDevice);
            if (fi.Exists)
            {
                xd.Load(path.pathDevice);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Devices");
                xd.AppendChild(xl);
                xd.Save(path.pathDevice);
            }
            return xd;
        }

        /// <summary>
        /// Поиск по названию устройства
        /// </summary>m>
        public void SearchDeviceByDeviceName(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "DeviceName" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Show(item);
                    break;
                }
                else
                    Console.WriteLine();
                    Console.WriteLine("Такого товара нет в базе данных!");
                    Console.WriteLine();
                Thread.Sleep(1200);
                Console.Clear();
            }
        }

        private XmlElement Show(XmlElement pho)
        {
            foreach (XmlElement item in pho.ChildNodes)
            {
                Console.WriteLine(item.Name + " - " + item.InnerText);
                Console.WriteLine();
            }
            return pho;
        }

        /// <summary>
        /// Редактирование устройства
        /// </summary>
        public void SearchDeviceByNameForEdit(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "DeviceName" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Edit(item);
                    break;
                }
            }
            if (find)
                xd.Save(path.pathDevice);
            Console.WriteLine();
            Console.WriteLine("Данные отредактированы и записаны!");
            Thread.Sleep(1200);
            Console.Clear();
        }

        private XmlElement Edit(XmlElement dev)
        {
            foreach(XmlElement item in dev.ChildNodes)
            {
                Console.WriteLine(item.Name + " :(" + item.InnerText + ") -");
                string cn = Console.ReadLine();

                if (!string.IsNullOrEmpty(cn))
                    item.InnerText = cn;
            }
            return dev;
        }

        /// <summary>
        /// Удаление устройства
        /// </summary>
        public void SearchDeviceByNameForDelete(string name)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(path.pathDevice);
            XmlNode root = xd.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Device[DeviceName = '{0}']", name));
            root.RemoveChild(node);
            xd.Save(path.pathDevice);
            Console.WriteLine();
            Console.WriteLine("Элементы удалены еспешно!");
            Thread.Sleep(1200);
            Console.Clear();
        }
    }
}

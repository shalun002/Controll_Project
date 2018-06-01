using Organizations.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Organizations
{
    public class OrganizationService
    {
        public string pathOrg = @"OrgInfo.xml";
        public List<Organization> organizations = new List<Organization>();

        ///<summary>
        /// Добавление организации в коллекцию
        /// </summary>
        public void AddOrganization()
        {
            try
            {
                Organization organization = new Organization();

                Console.WriteLine("Введите название организации: ");
                organization.OrgName = Console.ReadLine();

                Console.WriteLine("Введите адрес организации: ");
                organization.AddressOrganization = Console.ReadLine();

                Console.WriteLine("Введите телефон организации: ");
                organization.TelefonNumber = Console.ReadLine();
                
                if (isExistsOrganization(organization))
                {
                    organizations.Add(organization);
                    addOrganizationToXml(organization);
                    Console.WriteLine();
                    Console.WriteLine("==================================================================");
                    Console.WriteLine();
                    Console.WriteLine("Организация добавлена успешно!!!");
                    Console.WriteLine();
                    Console.WriteLine("==================================================================");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private bool isExistsOrganization(Organization organization)
        {
            if (organizations.Where(w => w.OrgName == organization.OrgName).Count() > 0)
            {
                Console.WriteLine("Такая организация уже существует");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Запись в Xml файл
        /// </summary>
        private void addOrganizationToXml(Organization org)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Organization");

            XmlElement OrgName = doc.CreateElement("OrgName");
            OrgName.InnerText = org.OrgName;
            xcom = doc.CreateComment("Название организации");
            OrgName.AppendChild(xcom);

            XmlElement TelefonNumber = doc.CreateElement("TelefonNumber");
            TelefonNumber.InnerText = org.TelefonNumber;
            xcom = doc.CreateComment("Номер телефона организации");
            TelefonNumber.AppendChild(xcom);

            XmlElement AddressOrganization = doc.CreateElement("AddressOrganization");
            AddressOrganization.InnerText = org.AddressOrganization.ToString();
            xcom = doc.CreateComment("Адрес организации");
            AddressOrganization.AppendChild(xcom);

            elem.AppendChild(OrgName);
            elem.AppendChild(TelefonNumber);
            elem.AppendChild(AddressOrganization);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(pathOrg);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(pathOrg);
            if (fi.Exists)
            {
                xd.Load(pathOrg);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Organizations");
                xd.AppendChild(xl);
                xd.Save(pathOrg);
            }
            return xd;
        }

        /// <summary>
        /// Поиск по названию организации
        /// </summary>m>
        public void SearchOrganizationByOrgName(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "OrgName" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Show(item);
                    break;
                }
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
        /// Редактирование организации
        /// </summary>
        public void SearchOrganizationByNameForEdit(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "OrgName" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Edit(item);
                    break;
                }
            }
            if (find)
                xd.Save(pathOrg);
            Console.WriteLine();
            Console.WriteLine("Данные отредактированы и записаны!");
        }

        private XmlElement Edit(XmlElement dev)
        {
            foreach (XmlElement item in dev.ChildNodes)
            {
                Console.WriteLine(item.Name + " :(" + item.InnerText + ") -");
                string cn = Console.ReadLine();

                if (!string.IsNullOrEmpty(cn))
                    item.InnerText = cn;
            }
            return dev;
        }

        /// <summary>
        /// Удаление организации
        /// </summary>
        public void SearchOrganByNameForDelete(string name)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(pathOrg);
            XmlNode root = xd.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Organization[OrgName = '{0}']", name));
            root.RemoveChild(node);
            xd.Save(pathOrg);
            Console.WriteLine();
            Console.WriteLine("Элементы удалены еспешно!");
        }

        public void ShowAll()
        {

        }
    }
}
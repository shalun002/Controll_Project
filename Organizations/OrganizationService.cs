using Organizations.Modules;
using Path;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Organizations
{
    public class OrganizationService
    {
        private PathInfo path = new PathInfo();

        public List<Organization> organizations = new List<Organization>();
        private static Organization organization = new Organization();

        ///<summary>
        /// Добавление организации в коллекцию
        /// </summary>
        public void AddOrganization()
        {
            try
            {
                Organization organization = new Organization();

                Console.Write("Введите название организации: ");
                organization.OrgName = Console.ReadLine();

                Console.Write("Введите адрес организации: ");
                organization.AddressOrganization = Console.ReadLine();

                Console.Write("Введите телефон организации: ");
                organization.TelefonNumber = Console.ReadLine();

                Console.Write("Выберите департамент из списка: ");
                Console.WriteLine();
                AddDepartament(null);
                organization.Departament = Console.ReadLine();


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
                    Thread.Sleep(1200);
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
        private void addOrganizationToXml(Organization organization)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Organization");

            XmlElement OrgName = doc.CreateElement("OrgName");
            OrgName.InnerText = organization.OrgName;
            xcom = doc.CreateComment("Название организации");
            OrgName.AppendChild(xcom);

            XmlElement TelefonNumber = doc.CreateElement("TelefonNumber");
            TelefonNumber.InnerText = organization.TelefonNumber;
            xcom = doc.CreateComment("Номер телефона организации");
            TelefonNumber.AppendChild(xcom);

            XmlElement AddressOrganization = doc.CreateElement("AddressOrganization");
            AddressOrganization.InnerText = organization.AddressOrganization.ToString();
            xcom = doc.CreateComment("Адрес организации");
            AddressOrganization.AppendChild(xcom);

            XmlElement Departament = doc.CreateElement("Departament");
            Departament.InnerText = organization.Departament.ToString();
            xcom = doc.CreateComment("Департамент организации");
            Departament.AppendChild(xcom);

            
            elem.AppendChild(OrgName);
            elem.AppendChild(TelefonNumber);
            elem.AppendChild(AddressOrganization);
            elem.AppendChild(Departament);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(path.pathOrg);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(path.pathOrg);
            if (fi.Exists)
            {
                xd.Load(path.pathOrg);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Organizations");
                xd.AppendChild(xl);
                xd.Save(path.pathOrg);
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
                xd.Save(path.pathOrg);
            Console.WriteLine();
            Console.WriteLine("Данные отредактированы и записаны!");
            Thread.Sleep(1200);
            Console.Clear();
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
            xd.Load(path.pathOrg);
            XmlNode root = xd.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Organization[OrgName = '{0}']", name));
            root.RemoveChild(node);
            xd.Save(path.pathOrg);
            Console.WriteLine();
            Console.WriteLine("Элементы удалены еспешно!");
            Thread.Sleep(1200);
            Console.Clear();
        }

        public void ShowAll()
        {
            var xd = XDocument.Load(path.pathOrg);

            foreach (var x in xd.Descendants())
            {
                if (x.HasElements)
                Console.WriteLine();
                else
                    Console.WriteLine("\t{0}: \t{1}", x.Name, x.Value);
            }
            Console.ReadKey();
        }

        public XmlElement AddDepartament (XmlElement xml)
        {
            var xd = XDocument.Load(path.pathDep);

            foreach (var x in xd.Descendants())
            {
                if (x.HasElements)
                    Console.WriteLine();
                else
                    Console.WriteLine("\t{0}: \t{1}", x.Name, x.Value);
            }
            return xml;
        }
    }
}
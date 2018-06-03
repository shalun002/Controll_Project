using Departments.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Departments
{
    public class ServiceDepart
    {
        public string pathDep = @"DepartInfo.xml";
        public List<Depart> departs = new List<Depart>();

        public ServiceDepart() : this("") { }

        public ServiceDepart(string pathDep)
        {
            if (string.IsNullOrEmpty(pathDep))
                this.pathDep = Path.Combine(@"DepartInfo.xml");
            else
                this.pathDep = pathDep;
        }

        /// <summary>
        /// Добавление департамента в коллекцию
        /// </summary>
        public void AddDepart()
        {
            Depart depart = new Depart();

            Console.Write("Введите название департамента: ");
            depart.DepartName = Console.ReadLine();

            Console.Write("Введите номер телефона депертамента: ");
            depart.DepartTelNumber = Int32.Parse(Console.ReadLine());

            if (isExistsDepart(depart))
            {
                departs.Add(depart);
                addDepartToXml(depart);
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Console.WriteLine();
                Console.WriteLine("Департамент добавлен успешно!!!");
                Console.WriteLine();
                Console.WriteLine("==================================================================");
                Thread.Sleep(2000);
                Console.Clear();

            }
        }

        /// <summary>
        /// Запись в Xml файл
        /// </summary>
        private void addDepartToXml(Depart dep)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Departament");

            XmlElement DepartName = doc.CreateElement("DepartName");
            DepartName.InnerText = dep.DepartName;
            xcom = doc.CreateComment("Название департамента");
            DepartName.AppendChild(xcom);

            XmlElement DepartTelNumber = doc.CreateElement("DepartTelNumber");
            DepartTelNumber.InnerText = dep.DepartTelNumber.ToString();
            xcom = doc.CreateComment("Номер телефона департамента");
            DepartTelNumber.AppendChild(xcom);

            elem.AppendChild(DepartName);
            elem.AppendChild(DepartTelNumber);
            
            doc.DocumentElement.AppendChild(elem);
            doc.Save(pathDep);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(pathDep);
            if (fi.Exists)
            {
                xd.Load(pathDep);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Departaments");
                xd.AppendChild(xl);
                xd.Save(pathDep);
            }
            return xd;
        }

        private bool isExistsDepart(Depart depart)
        {
            if (departs.Where(w => w.DepartName == depart.DepartName).Count() > 0)
            {
                Console.WriteLine("Такой департамент уже существует");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Поиск по названию департамента
        /// </summary>m>
        public void SearchDepartByName(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "DepartName" && i.InnerText == name)
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
        /// Редактирование департамента
        /// </summary>
        public void SearchDepartByNameForEdit(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "DepartName" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Edit(item);
                    break;
                }
            }
            if (find)
                xd.Save(pathDep);
            Console.WriteLine();
            Console.WriteLine("Данные отредактированы и записаны!");
        }

        private XmlElement Edit(XmlElement dep)
        {
            foreach (XmlElement item in dep.ChildNodes)
            {
                Console.WriteLine(item.Name + " :(" + item.InnerText + ") -");
                string cn = Console.ReadLine();

                if (!string.IsNullOrEmpty(cn))
                    item.InnerText = cn;
            }
            return dep;
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        public void SearchDepartByNameForDelete(string name)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(pathDep);
            XmlNode root = xd.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Departament[DepartName = '{0}']", name));
            root.RemoveChild(node);
            xd.Save(pathDep);
            Console.WriteLine();
            Console.WriteLine("Элементы удалены еспешно!");
        }
    }
}

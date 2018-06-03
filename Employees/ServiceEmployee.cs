using Devices.Modules;
using Employees.Modules;
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

namespace Employees
{
    public class ServiceEmployee
    {
        private PathInfo path = new PathInfo();
        private Random r = new Random();

        public List<Employee> employees = new List<Employee>();

        public void AddEmployee()
        {
            try
            {
                Employee employee = new Employee();

                Console.Write("Введите имя и фамилию сотрудника: ");
                employee.Name = Console.ReadLine();

                Console.Write("Введите название организации: ");
                employee.OrganizationName = Console.ReadLine();

                Console.Write("Введите название департамента: ");
                employee.DepartmensName = Console.ReadLine();

                Console.Write("Введите название устройства: ");
                employee.Device = Console.ReadLine();

                if (isExistsOrganization(employee))
                {
                    employees.Add(employee);
                    addEmployeeToXml(employee);
                    Console.WriteLine();
                    Console.WriteLine("==================================================================");
                    Console.WriteLine();
                    Console.WriteLine("Сотрудник добавлен успешно!!!");
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

        /// <summary>
        /// Запись в Xml файл
        /// </summary>
        private void addEmployeeToXml(Employee employee)
        {
            XmlDocument doc = getDocument();
            XmlComment xcom;
            XmlElement elem = doc.CreateElement("Employee");

            XmlElement Name = doc.CreateElement("Name");
            Name.InnerText = employee.Name;
            xcom = doc.CreateComment("Имя и фамилия сотрудника");
            Name.AppendChild(xcom);

            XmlElement OrganizationName = doc.CreateElement("OrganizationName");
            OrganizationName.InnerText = employee.OrganizationName;
            xcom = doc.CreateComment("Название организации");
            OrganizationName.AppendChild(xcom);

            XmlElement DepartmensName = doc.CreateElement("DepartmensName");
            DepartmensName.InnerText = employee.DepartmensName;
            xcom = doc.CreateComment("Название департамента");
            DepartmensName.AppendChild(xcom);

            XmlElement Device = doc.CreateElement("Device");
            Device.InnerText = employee.Device;
            xcom = doc.CreateComment("Название устройства");
            Device.AppendChild(xcom);

            elem.AppendChild(Name);
            elem.AppendChild(OrganizationName);
            elem.AppendChild(DepartmensName);
            elem.AppendChild(Device);
            doc.DocumentElement.AppendChild(elem);
            doc.Save(path.pathEmployee);
        }

        private XmlDocument getDocument()
        {
            XmlDocument xd = new XmlDocument();

            FileInfo fi = new FileInfo(path.pathEmployee);
            if (fi.Exists)
            {
                xd.Load(path.pathEmployee);
            }
            else
            {
                XmlElement xl = xd.CreateElement("Employees");
                xd.AppendChild(xl);
                xd.Save(path.pathEmployee);
            }
            return xd;
        }

        private bool isExistsOrganization(Employee employee)
        {
            if (employees.Where(w => w.Name == employee.Name).Count() > 0)
            {
                Console.WriteLine("Такой сотрудник уже существует");
                return false;
            }
            return true;

        }

        /// <summary>
        /// Поиск по имени
        /// </summary>m>
        public void SearchEmployeeByName(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "Name" && i.InnerText == name)
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
        /// Редактирование сотрудника
        /// </summary>
        public void SearchEmployeeByNameForEdit(string name)
        {
            XmlDocument xd = getDocument();
            XmlElement root = xd.DocumentElement;

            bool find = false;

            foreach (XmlElement item in root)
            {
                find = false;

                foreach (XmlNode i in item.ChildNodes)
                {
                    if (i.Name == "Name" && i.InnerText == name)
                        find = true;
                }
                if (find)
                {
                    XmlElement el = Edit(item);
                    break;
                }
            }
            if (find)
                xd.Save(path.pathEmployee);
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
        public void SearchEmployeeByNameForDelete(string name)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(path.pathEmployee);
            XmlNode root = xd.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Name[Name = '{0}']", name));
            root.RemoveChild(node);
            xd.Save(path.pathEmployee);
            Console.WriteLine();
            Console.WriteLine("Элементы удалены еспешно!");
        }

        public void ShowAll()
        {
            var xd = XDocument.Load(path.pathEmployee);

            foreach (var x in xd.Descendants())
            {
                if (x.HasElements)
                    Console.WriteLine("\n{0}\n ", x.Name);
                else
                    Console.WriteLine("\t{0}: \t{1}", x.Name, x.Value);
            }
        }
    }
}

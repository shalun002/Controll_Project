using Departments;
using Devices;
using Employees;
using Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammMenu
{
    public class Menu
    {
        public void ProgrammMenu()
        {
            MenuDevice dev = new MenuDevice();
            OrganizationMenu menu = new OrganizationMenu();
            MenuDepart menuDepart = new MenuDepart();
            EmployeesMenu em = new EmployeesMenu();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("========== Menu ==========");
                Console.WriteLine();
                Console.WriteLine("1. Устройства");
                Console.WriteLine("2. Отделы");
                Console.WriteLine("3. Организации");
                Console.WriteLine("4. Сотрудники");
                Console.WriteLine("5. Выход");
                Console.WriteLine();
                Console.WriteLine("==========================");
                Console.WriteLine();

                Console.Write("Выберите действие: ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("============ Устройства ============");
                        Console.WriteLine();
                        dev.DeviceMenu();
                        break;
                    case 2:
                        Console.WriteLine("============ Отделы ============");
                        Console.WriteLine();
                        menuDepart.DepartMenu();
                        break;
                    case 3:
                        Console.WriteLine("============ Организации ============");
                        Console.WriteLine();
                        menu.OrgMenu();
                        break;
                    case 4:
                        Console.WriteLine("============ Сотрудники ============");
                        Console.WriteLine();
                        em.EmplMenu();
                        break;
                    case 5:
                        break;
                }
            }
        }
    }
}

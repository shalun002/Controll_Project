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
            MenuOrganization menu = new MenuOrganization();

            Console.WriteLine();
            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Устройства");
            Console.WriteLine("2. Отделы");
            Console.WriteLine("3. Организации");
            Console.WriteLine("4. Сотрудники");
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
                    return;
                case 3:
                    Console.WriteLine("============ Организации ============");
                    Console.WriteLine();
                    menu.OrganizationMenu();
                    break;
                case 4:
                    break;
            }

        }
    }
}

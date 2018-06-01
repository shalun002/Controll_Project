using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class MenuDevice
    {
        public void DeviceMenu()
        {
            ServiceDevice sd = new ServiceDevice();

            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Добавить устройство");
            Console.WriteLine("2. Удалить устройство");
            Console.WriteLine("3. Редактировать данные");
            Console.WriteLine("4. Поиск устройства");
            Console.WriteLine("5. Вернуться в главное меню");
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
                    Console.WriteLine("============ Добавление ============");
                    Console.WriteLine();
                    sd.AddDevice();
                    return;
                case 2:
                    Console.WriteLine("============ Удаление ============");
                    Console.WriteLine();
                    Console.Write("Введите название устройства, которое хотите удалить: ");
                    sd.SearchDeviceByNameForDelete(Console.ReadLine());

                    break;
                case 3:
                    Console.WriteLine("============ Редактирование ============");
                    Console.WriteLine();
                    Console.Write("Введите название устройства, которое хотите отредактировать: ");
                    sd.SearchDeviceByNameForEdit(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("============ Поиск ============");
                    Console.WriteLine();
                    Console.Write("Введите название устройства: ");
                    sd.SearchDeviceByDeviceName(Console.ReadLine());
                    break;
                case 5:
                    break;
            }
        }
    }
}

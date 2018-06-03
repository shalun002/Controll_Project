using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departments
{
    public class MenuDepart
    {
        public void DepartMenu()
        {
            ServiceDepart sd = new ServiceDepart();

            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Добавить департамент");
            Console.WriteLine("2. Удалить департамент");
            Console.WriteLine("3. Редактировать департамент");
            Console.WriteLine("4. Поиск департамента");
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
                    sd.AddDepart();
                    break;
                case 2:
                    Console.WriteLine("============ Удаление ============");
                    Console.WriteLine();
                    Console.Write("Введите название департамента, которое хотите удалить: ");
                    sd.SearchDepartByNameForDelete(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("============ Редактирование ============");
                    Console.WriteLine();
                    Console.Write("Введите название департамента, которое хотите отредактировать: ");
                    sd.SearchDepartByNameForEdit(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("============ Поиск ============");
                    Console.WriteLine();
                    Console.Write("Введите название устройства: ");
                    sd.SearchDepartByName(Console.ReadLine());
                    break;
                case 5:

                    break;
            }
        }
    }
}

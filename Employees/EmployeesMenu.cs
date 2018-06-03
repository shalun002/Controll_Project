using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class EmployeesMenu
    {
        public void EmplMenu()
        {
            ServiceEmployee se = new ServiceEmployee();

            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Редактировать сотрудника");
            Console.WriteLine("4. Поиск сотрудника по имени");
            Console.WriteLine("5. Показать всех сотрудников");
            Console.WriteLine("6. Выйти в главное меню");

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
                    se.AddEmployee();
                    break;
                case 2:
                    Console.WriteLine("============ Удаление ============");
                    Console.WriteLine();
                    Console.Write("Введите имя и фамилию сотрудника, чтобы удалить: ");
                    se.SearchEmployeeByNameForDelete(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("============ Редактирование ============");
                    Console.WriteLine();
                    Console.Write("Введите имя и фамилию сотрудника, чтобы отредактировать: ");
                    se.SearchEmployeeByNameForEdit(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("============ Поиск ============");
                    Console.WriteLine();
                    Console.Write("Введите имя и фамилию сотрудника: ");
                    se.SearchEmployeeByName(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("============ Показать всех сотрудников ============");
                    Console.WriteLine();
                    //se.SearchOrganizationByOrgName(Console.ReadLine());
                    break;
                case 6:
                    break;
            }
        }
    }
}

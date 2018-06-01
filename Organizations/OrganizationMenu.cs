using Organizations.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations
{
    public class OrganizationMenu
    {
        public void OrgMenu()
        {
            OrganizationService so = new OrganizationService();

            Console.WriteLine("========== Menu ==========");
            Console.WriteLine();
            Console.WriteLine("1. Добавить организацию");
            Console.WriteLine("2. Удалить организацию");
            Console.WriteLine("3. Редактировать организацию");
            Console.WriteLine("4. Поиск организации");
            Console.WriteLine("5. Показать все организации");
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
                    so.AddOrganization();
                    break;
                case 2:
                    Console.WriteLine("============ Удаление ============");
                    Console.WriteLine();
                    so.SearchOrganByNameForDelete(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("============ Редактирование ============");
                    Console.WriteLine();
                    so.SearchOrganizationByNameForEdit(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("============ Поиск ============");
                    Console.WriteLine();
                    so.SearchOrganizationByOrgName(Console.ReadLine());
                    break;
                case 5:
                    so.Show();
                    break;
                case 6:
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesDepartment;

namespace HumanResourcesDepartmentConsoleApplication
{
    class Program
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Display all employees.");
            Console.WriteLine("2. Displya all subdivisions.");
            Console.WriteLine("3. Add Employee.");
            Console.WriteLine("4. Add subdivision.");
            Console.WriteLine("5. Set/Сhange division.");
            Console.WriteLine("6. Set/Chenge emplyeer.");
            Console.WriteLine("7. Chenge position.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine("Choose one of the menu items!");
        }
        static void Main(string[] args)
        {
            Company company = new Company("Google");
            Program.DisplayMenu();
            Console.ReadLine();
        }
    }
}

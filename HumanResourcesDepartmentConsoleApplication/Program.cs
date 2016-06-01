using System;
using System.IO;
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
            Console.WriteLine("3. Add employee.");
            Console.WriteLine("4. Add subdivision.");
            Console.WriteLine("5. Set/Сhange division.");
            Console.WriteLine("6. Set/Chenge emplyeer.");
            Console.WriteLine("7. Chenge position.");
            Console.WriteLine("8. Delete employee.");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("Choose one of the menu items!");
        }
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Console.Write("Input company's name: ");
            string companyName = Console.ReadLine().Trim();
            Company company = menu.LoadObject(companyName);
            while (true)
            {
                Program.DisplayMenu();
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Display all employees.");
                        menu.PrintEmployeeList(company.Employees);
                        break;
                    case 2:
                        Console.WriteLine("Displya all subdivisions.");
                        menu.PrinSubdivisionList(company.Subdivisions);
                        break;
                    case 3:
                        Console.WriteLine("Add Employee.");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Lastname: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Contact details: ");
                        string contactDetails = Console.ReadLine();
                        Console.Write("Position: ");
                        string position = Console.ReadLine();
                        company.AddEmployee(name, lastName, contactDetails, position);
                        Console.WriteLine("Employee added!");
                        menu.SaveObject(company);
                        break;
                    case 4:
                        Console.WriteLine("Add subdivision.");
                        Console.Write("Subdivision's name: ");
                        string subdivisionName = Console.ReadLine();
                        company.AddSubdivision(subdivisionName);
                        Console.WriteLine("Subdivision added!");
                        menu.SaveObject(company);
                        break;
                    case 5:
                        Console.WriteLine("Set/Сhange division.");
                        Console.Write("Empleyee's id: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Subdivision's name: ");
                        string subName = Console.ReadLine();
                        company.SetSubdivision(id, subName);
                        Console.WriteLine("Subdivision seted/changed.");
                        menu.SaveObject(company);
                        break;
                    case 6:
                        Console.WriteLine("Set/Chenge emplyeer.");
                        Console.Write("Employee's id:");
                        int emlpoyeeId = int.Parse(Console.ReadLine());
                        Console.Write("Employer's id:");
                        int emlpoyerId = int.Parse(Console.ReadLine());
                        company.SetEmployer(emlpoyeeId, emlpoyerId);
                        Console.WriteLine("Subdivision seted/changed.");
                        menu.SaveObject(company);
                        break;
                    case 7:
                        
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Incorrect number of the menu!");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}

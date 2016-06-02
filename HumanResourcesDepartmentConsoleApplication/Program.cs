using System;
using HumanResourcesDepartment;

namespace HumanResourcesDepartmentConsoleApplication
{
    class Program
    {
        /// <summary>
        /// This method displays menu.
        /// </summary>
        public void DisplayMenu()
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

        /// <summary>
        /// This method adds new employee in company.
        /// </summary>
        /// <param name="company">Company</param>
        public void AddEmployee(Company company)
        {
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
        }

        /// <summary>
        /// This method adds new subdivision in company.
        /// </summary>
        /// <param name="company">Company</param>
        public void AddSubdivision(Company company)
        {
            Console.WriteLine("Add subdivision.");
            Console.Write("Subdivision's name: ");
            string subdivisionName = Console.ReadLine();
            company.AddSubdivision(subdivisionName);
            Console.WriteLine("Subdivision added!");
        }

        /// <summary>
        /// This method set or change employee's subdivision.
        /// </summary>
        /// <param name="company">Company</param>
        public void SetChangeDivision(Company company)
        {
            Console.WriteLine("Set/Сhange division.");
            Console.Write("Empleyee's id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Subdivision's name: ");
            string subName = Console.ReadLine();
            try
            {
                company.SetSubdivision(id, subName);
                Console.WriteLine("Subdivision seted/changed.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("This subdivision or employee does not exist! " + e.Message);
            }
            
        }

        /// <summary>
        /// This method set or change employee's employer.
        /// </summary>
        /// <param name="company">Company</param>
        public void SetChangeEmployer(Company company)
        {
            Console.WriteLine("Set/Change emplyeer.");
            Console.Write("Employee's id:");
            int emlpoyeeId = int.Parse(Console.ReadLine());
            Console.Write("Employer's id:");
            int emlpoyerId = int.Parse(Console.ReadLine());
            try
            {
                company.SetEmployer(emlpoyeeId, emlpoyerId);
                Console.WriteLine("Subdivision seted/changed.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("This employer or employee does not exist! " + e.Message);
            }
            
        }
        
        /// <summary>
        /// This method changes employee's position.
        /// </summary>
        /// <param name="company">Company</param>
        public void ChangePosition(Company company)
        {
            Console.WriteLine("Change employee's position.");
            Console.Write("Employee's id:");
            int emlpoyeeId = int.Parse(Console.ReadLine());
            Console.Write("Position: ");
            string position = Console.ReadLine();
            try
            {
                company.FindById(emlpoyeeId).ChangePosition(position);
                Console.WriteLine("Position Changed.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("This employee does not exist! " + e.Message);
            }            
            
        }

        /// <summary>
        /// This method removes employee by id.
        /// </summary>
        /// <param name="company">Company</param>
        public void RemoveEmployee(Company company)
        {
            Console.WriteLine("Delete employee");
            Console.Write("Employee's id: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                company.RemoveEmloyee(company.FindById(id));
                Console.WriteLine("Employee deleted.");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("This employee does not exist! " + e.Message);
            }

        }

        /// <summary>
        /// This method close console application.
        /// </summary>
        /// <param name="flag">bool</param>
        /// <returns>bool</returns>
        public bool ExitConsoleApplication(bool flag)
        {
            Console.Write("Are you sure you want to close the application? (yes/no): ");
            string res = Console.ReadLine();
            if (res == "yes" || res == "y")
                return true;
            else if (res == "no" || res == "n")
                return false;
            else
                Console.WriteLine("Incorrect unswer!");
            return false;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            Menu menu = new Menu();
            Console.Write("Input company's name(Example: Google): ");
            string companyName = Console.ReadLine().Trim();
            Company company = menu.LoadObject(companyName);
            bool exit = false;
            while (!exit)
            {
                program.DisplayMenu();
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
                        program.AddEmployee(company);
                        menu.SaveObject(company);
                        break;
                    case 4:
                        program.AddSubdivision(company);
                        menu.SaveObject(company);
                        break;
                    case 5:
                        program.SetChangeDivision(company);
                        menu.SaveObject(company);
                        break;
                    case 6:
                        program.SetChangeEmployer(company);
                        menu.SaveObject(company);
                        break;
                    case 7:
                        program.ChangePosition(company);
                        menu.SaveObject(company);
                        break;
                    case 8:
                        program.RemoveEmployee(company);
                        menu.SaveObject(company);
                        break;
                    case 0:
                        exit = program.ExitConsoleApplication(exit);
                        menu.SaveObject(company);
                        break;
                    default:
                        Console.WriteLine("Incorrect number of the menu!");
                        break;
                }
            }
            Console.Write("Press any key!");
            Console.ReadLine();
        }
    }
}

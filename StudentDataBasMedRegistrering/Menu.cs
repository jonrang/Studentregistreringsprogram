using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualBasic;

namespace StudentDataBasMedRegistrering
{
    internal class Menu
    {
        private StudentManager manager;

        public Menu(StudentManager manager)
        {
            this.manager = manager;
            Console.WriteLine("Welcome to the student database");
            MainMenu();
        }
        private void MainMenu()
        {

            do
            {
                Console.WriteLine("Main menu");
                Console.WriteLine("1. List students");
                Console.WriteLine("2. Register new student");
                Console.WriteLine("3. Change a students information");
                Console.WriteLine("4. Close program"); 
            } while (MenuChoice());
            
        }
        private bool MenuChoice()
        {
            int choice = InPutTry(1, 4);
            switch (choice)
            {
                case 1:
                    manager.ListStudents();
                    break;
                case 2:
                    RegisterStudent();
                    break;
                case 3:
                    ChangeStudentInfo();
                    break;
                default:
                    return false;
            }
            return true;
        }
        private void RegisterStudent()
        {
            Student student = new();
            Console.Clear();
            Console.WriteLine("Register new student");
            Console.WriteLine("Input first name:");
            student.FirstName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Input last name:");
            student.LastName = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Input city:");
            student.City = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Student to be added:");
            Console.WriteLine(student.ToString());
            Console.WriteLine("1. Proceed");
            Console.WriteLine("2. Return to menu");
            if (InPutTry(1, 2) == 1)
            {
                manager.RegisterStudent(student);
            }
        }

        private void ChangeStudentInfo()
        {
            Console.Clear();
            Student student;
            Console.WriteLine("Change student info");
            Console.WriteLine("Input id of student whose info you wish to change:");
            student = manager.GetStudentInfo(InPutTry(1, manager.GetStudentCount()));
            Console.WriteLine(student.ToString());
            Console.WriteLine("Change name?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            if (InPutTry(1, 2) == 1)
            {
                Console.WriteLine("Input new first name:");
                student.FirstName = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Input last name:");
                student.LastName = Console.ReadLine() ?? string.Empty;
            }
            Console.WriteLine("Change city?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            if (InPutTry(1, 2) == 1)
            {
                Console.WriteLine("Input city:");
                student.City = Console.ReadLine() ?? string.Empty;
            }
            Console.WriteLine("New student info:");
            Console.WriteLine(student.ToString());
            Console.WriteLine("1. Save changes");
            Console.WriteLine("2. Discard changes");
            if (InPutTry(1, 2) == 1)
            {
                manager.UpdateStudent(student);
            }
        }

        private int InPutTry(int min, int max)
        {
            int inPut;
            try
            {
                inPut = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please input a number");
                return InPutTry(min, max);
            }
            ;
            if (inPut < min || inPut > max)
            {
                Console.WriteLine($"Please input number between {min} and {max}");
                return InPutTry(min, max);
            }
            return inPut;
        }
    }
}

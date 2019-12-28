using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> perList = new List<Person>();
            Student s = new Student();
            Lecturer l = new Lecturer();
            int choice = 0;
            while (true)
            {
                Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                Console.WriteLine("\t1. Manage Students");
                Console.WriteLine("\t2. Manage Lecturers");
                Console.WriteLine("\t3. Exit\n");
                Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                Console.WriteLine("Choose Function");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("You must enter a Number!!");
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        int choice1 = 0;
                        do
                        {
                            Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                            Console.WriteLine("\t1. Add new Student");
                            Console.WriteLine("\t2. View all Students");
                            Console.WriteLine("\t3. Search Students");
                            Console.WriteLine("\t4. Delete Student");
                            Console.WriteLine("\t5. Update Student");
                            Console.WriteLine("\t6. Back to Main Menu\n");
                            Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                            Console.WriteLine("Choose Function");
                            try
                            {
                                choice1 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("You must enter a Number!!");
                                choice1 = 0;
                            }
                            switch (choice1)
                            {
                                case 1:
                                    s.AddStudent(perList);
                                    break;
                                case 2:
                                    s.ViewStudent(perList);
                                    break;
                                case 3:
                                    s.SearchStudent(perList);
                                    break;
                                case 4:
                                    s.Delete(perList, "Student");
                                    break;
                                case 5:
                                    s.UpdateStudent(perList);
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("Enter a number from 1 to 6 !!");
                                    break;
                            }
                        }
                        while (choice1 != 6);
                        break;
                    case 2:
                        int choice2 = 0;
                        do
                        {
                            Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                            Console.WriteLine("\t1. Add new Lecturer");
                            Console.WriteLine("\t2. View all Lecturers");
                            Console.WriteLine("\t3. Search Lecturers");
                            Console.WriteLine("\t4. Delete Lecturer");
                            Console.WriteLine("\t5. Update Lecturer");
                            Console.WriteLine("\t6. Back to Main Menu\n");
                            Console.WriteLine("*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*\n");
                            Console.WriteLine("Choose Function");
                            try
                            {
                                choice2 = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("You must enter a Number!!");
                                choice2 = 0;
                            }
                            switch (choice2)
                            {
                                case 1:
                                    l.AddLecturer(perList);
                                    break;
                                case 2:
                                    l.ViewLecturer(perList);
                                    break;
                                case 3:
                                    l.SearchLecturer(perList);
                                    break;
                                case 4:
                                    l.Delete(perList, "Lecturer");
                                    break;
                                case 5:
                                    l.UpdateLecturer(perList);
                                    break;
                                case 6:
                                    break;
                                default:
                                    Console.WriteLine("Enter a number from 1 to 6 !!");
                                    break;
                            }
                        }
                        while (choice2 != 6);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a number from 1 to 3 !!");
                        break;
                }
            }
        }
    }
}

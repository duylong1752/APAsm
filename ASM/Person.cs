using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    abstract class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public Person()
        {
        }
        public Person(string id, string name,DateTime dob, string email, string add)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.email = email;
            this.address = add;
        }
        public abstract void Display();
        public bool SearchID(string id)
        {
            if (this.id == id)
            {
                return true;
            }
            return false;
        }
        public bool SearchName(string name)
        {
            if (this.name.ToLower().Contains(name.ToLower()))
            {
                return true;
            }
            return false;
        }
        public void Add(List<Person> perlist, string str)
        {
            Console.WriteLine("==========Add new "+str+"==========");
            bool f = false;
            while (f == false)
            {
                Console.WriteLine(str+"'s ID:");
                this.id = Console.ReadLine();
                if (DataType.CheckID(id,str))
                {
                    if (DataType.CheckExists(id, perlist))
                    {
                        Console.WriteLine("The ID already exists !!");
                    }
                    else
                    {
                        Console.WriteLine(str+"'s Name:");
                        this.name = Console.ReadLine();
                        while (f == false)
                        {
                            Console.WriteLine(str+"'s Date of Birth (dd/mm/yyyy):");
                            try
                            {
                                this.dob = Convert.ToDateTime(Console.ReadLine());
                                while (f == false)
                                {
                                    Console.WriteLine(str+"'s Email:");
                                    string email = Console.ReadLine();
                                    if (DataType.Email(email))
                                    {
                                        this.email = email;
                                        Console.WriteLine(str+"'s Address:");
                                        this.address = Console.ReadLine();
                                        f = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Email is not valid!!");
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("DOB is not valid");
                            }
                        }
                    }

                }
                else
                {
                    if (str == "Student")
                    {
                        Console.WriteLine("Student's ID must be: GTxxxxx or GCxxxxx");
                    }
                    else
                    {
                        Console.WriteLine("Lecturer's ID must be: xxxxxxxx");
                    }
                }
            }
        }
        public void Delete(List<Person> perList,string str)
        {
            if (perList.Count == 0)
            {
                Console.WriteLine("Have no "+str+" in List !!");
            }
            else
            {
                Console.WriteLine("Enter "+str+"'s ID:");
                string id = Console.ReadLine();
                foreach (var per in perList)
                {
                    if (per.SearchID(id))
                    {
                        Console.WriteLine("Do you really want to Delete this "+str+"? (y/n)");
                        string choose = Console.ReadLine();
                        if (choose.ToLower() == "y")
                        {
                            perList.Remove(per);
                            Console.WriteLine("Delete "+str+" successfully!!");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Have no "+str+" with that ID");
                    }
                }
            }
        }
        public string Update(List<Person> perList,string str)
        {
            if (perList.Count == 0)
            {
                Console.WriteLine("Have no "+str+" in List !!");
                return "";
            }
            else
            {
                Console.WriteLine("Enter "+str+"'s ID:");
                string id = Console.ReadLine();
                foreach (var per in perList)
                {
                    if (per.SearchID(id))
                    {
                        Console.WriteLine("Below are "+str+"'s information. If you want to change each field, enter new data or just press Enter to skip");
                        Console.WriteLine(str+"'s ID: " + per.id);
                        Console.WriteLine(str+"'s Name: " + per.name);
                        string name = Console.ReadLine();
                        per.name = DataType.InputValue(per.name, name);
                        bool f = false;
                        while (f == false)
                        {
                            Console.WriteLine(str+"'s DOB: " + per.dob.ToShortDateString());
                            string date = Console.ReadLine();
                            try
                            {
                                per.dob = DataType.InputDate(date, per.dob);
                                while (f == false)
                                {
                                    Console.WriteLine(str+"'s Email: " + per.email);
                                    string email = Console.ReadLine();
                                    if (email == "")
                                    {
                                        Console.WriteLine(str+"'s Address: " + per.address);
                                        string add = Console.ReadLine();
                                        per.address = DataType.InputValue(per.address, add);                  
                                        f = true;
                                    }
                                    else
                                    {
                                        if (DataType.Email(email))
                                        {
                                            per.email = email;
                                            Console.WriteLine(str+"'s Address: " + per.address);
                                            string add = Console.ReadLine();
                                            per.address = DataType.InputValue(per.address, add);
                                            f = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Email is not valid!!");
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("DOB is not valid");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Have no "+str+" with that ID");
                    }
                }
                return id;
            }
        }
    }
}

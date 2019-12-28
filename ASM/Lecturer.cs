using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    class Lecturer : Person
    {
        public string lecDept { get; set; }
        public Lecturer()
        {
        }
        public Lecturer(string id, string name, DateTime dob, string email, string add, string dept) : base(id, name, dob, email, add)
        {
            this.lecDept = dept;
        }
        public override void Display()
        {
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", this.id, this.name, this.dob.ToShortDateString(), this.email, this.address, this.lecDept);
        }
        public void AddLecturer(List<Person> perList)
        {
            string str = "Lecturer";
            base.Add(perList, str);
            Console.WriteLine("Lecturer's Department:");
            this.lecDept = Console.ReadLine();
            perList.Add(new Lecturer(this.id, this.name, this.dob, this.email, this.address, this.lecDept));
        }
        public void ViewLecturer(List<Person> perList)
        {
            if (perList.Count != 0)
            {
                Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Department");
                foreach (var per in perList)
                {
                    if (per is Lecturer)
                    {
                        per.Display();
                    }
                }
            }
            else
            {
                Console.WriteLine("Have no Element in List");
            }
        }
        public void SearchLecturer(List<Person> perList)
        {
            if (perList.Count == 0)
            {
                Console.WriteLine("Have no Lecturer in List !!");
            }
            else
            {
                Console.WriteLine("Enter Lecturer's Name:");
                string sname = Console.ReadLine();
                if (DataType.CheckExists(sname, perList))
                {
                    Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Department");
                    foreach (var per in perList)
                    {
                        if (per.SearchName(sname))
                        {
                            per.Display();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Have no Lecturer with that Name");
                }

            }

        }
        public void UpdateLecturer(List<Person> perList)
        {
            string str = "Lecturer";
            string id = base.Update(perList, str);

            foreach (var per in perList)
            {
                if (per.SearchID(id))
                {
                    Lecturer l = per as Lecturer;
                    Console.WriteLine("Lecturer's Department: " + l.lecDept);
                    string ldept = Console.ReadLine();
                    l.lecDept = DataType.InputValue(l.lecDept, ldept);
                    Console.WriteLine("Update Lecturer Successfully!!");
                    Console.WriteLine("New Lecturer's Information:");
                    Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Department");
                    l.Display();
                }
            }
        }
    }
}

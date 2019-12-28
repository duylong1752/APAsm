using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    class Student:Person
    {
        public string stdBatch { get; set; }
        public Student()
        {
        }
        public Student(string id,string name,DateTime dob,string email,string add,string batch):base( id, name, dob, email, add)
        {
            this.stdBatch = batch;
        }
        public override void Display()
        {
            Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", this.id, this.name, this.dob.ToShortDateString(), this.email, this.address,this.stdBatch);
        }
        public void AddStudent(List<Person> perList)
        {
            string str = "Student";
            base.Add(perList, str);
            Console.WriteLine("Student's Batch:");
            this.stdBatch = Console.ReadLine();
            perList.Add(new Student(this.id, this.name, this.dob, this.email, this.address, this.stdBatch));
        }
        public void ViewStudent(List<Person> perList)
        {
            if (perList.Count != 0)
            {
                Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Batch");
                foreach(var per in perList)
                {
                    if(per is Student)
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
        public void SearchStudent(List<Person> perList)
        {
            if (perList.Count == 0)
            {
                Console.WriteLine("Have no Student in List !!");
            }
            else
            {
                Console.WriteLine("Enter Student's Name:");
                string sname = Console.ReadLine();
                if (DataType.CheckExists(sname, perList))
                {
                    Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Batch");
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
                    Console.WriteLine("Have no Student with that Name");
                }

            }
        }
        public void UpdateStudent(List<Person> perList)
        {
            string str = "Student";
            string id=base.Update(perList, str);

            foreach(var per in perList)
            {
                if (per.SearchID(id))
                {
                    Student s = per as Student;
                    Console.WriteLine("Student's Batch: " + s.stdBatch);
                    string sbatch = Console.ReadLine();
                    s.stdBatch = DataType.InputValue(s.stdBatch, sbatch);
                    Console.WriteLine("Update Student Successfully!!");
                    Console.WriteLine("New Student's Information:");
                    Console.WriteLine("|{0,-10}|{1,-20}|{2,-15}|{3,-20}|{4,-20}|{5,-15}|", "ID", "Name", "DOB", "Email", "Address", "Batch");
                    s.Display();
                }
            }
        }
    }
}

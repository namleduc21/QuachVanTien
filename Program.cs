using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IStudent
    {
        int StudID { get; set; }
        string StudName { get; set; }
        string StudGender { get; set; }
        string StudClass { get; set; }
        int StudAge { get; set; }
        float StudAvgMark { get; }
        void Print();

    }
    class Student : IStudent
    {
        public Student()
        { }
        public Student(int studID, string studName, string studGender, string studClass, int studAge, float studAvgMark)
        {
            StudID = studID;
            StudName = studName;
            StudGender = studGender;
            StudClass = studClass;
            StudAge = studAge;
            StudAvgMark = studAvgMark;



        }
        public int StudID { get; set; }
        public string StudName { get; set; }
        public string StudGender { get; set; }
        public string StudClass { get; set; }
        public int StudAge { get; set; }
        public float StudAvgMark { get; set; }
        public virtual void Print()
        {
            Console.WriteLine(StudID);
            Console.WriteLine(StudName);
            Console.WriteLine(StudGender);
            Console.WriteLine(StudClass);
            Console.WriteLine(StudAge);
            Console.WriteLine(StudAvgMark);
        }

        int[] MarkList = new int[3];
        public int this[int i]
        {
            get { return MarkList[i]; }
            set { MarkList[i] = value; }
        }
        public void CalAvg()
        {
            float sum = 0;

            foreach (int i in MarkList)
            {
                sum += i;
            }

            StudAvgMark = sum / MarkList.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Student> listOfStudent = new Dictionary<int, Student>();

        Nhap:
            Console.Clear();
            Console.WriteLine("Please select an option:");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Insert new student:");
            Console.WriteLine("2. Display all the student list:");
            Console.WriteLine("3. Calculator average mark:");
            Console.WriteLine("4. Find student:");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("=======================================");
            Console.Write("Option:");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    Student student = new Student();
                    Console.WriteLine("1. Insert new student...");
                    Console.WriteLine();
                    Console.Write(" Input student ID\t:");
                    student.StudID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write(" Input student name\t:");
                    student.StudName = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write(" Input student gender\t:");
                    student.StudGender = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write(" Input student age\t:");
                    student.StudAge = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write(" Input student class\t:");
                    student.StudClass = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine(" Input student mark:");
                    Console.WriteLine();
                    Console.Write("\tinput mark 1:");
                    int mark1 = Convert.ToInt32(Console.ReadLine());
                    student[0] = mark1;
                    Console.WriteLine();
                    Console.Write("\tinput mark 2:");
                    int mark2 = Convert.ToInt32(Console.ReadLine());
                    student[1] = mark2;
                    Console.WriteLine();
                    Console.Write("\tinput mark 3:");
                    int mark3 = Convert.ToInt32(Console.ReadLine());
                    student[2] = mark3;

                    listOfStudent.Add(student.StudID, student);
                    break;
                case 2:
                    Console.Clear();
                    foreach (KeyValuePair<int, Student> item in listOfStudent)
                    {
                        ((IStudent)item.Value).Print();
                    }

                    break;
                case 3:
                    Console.Clear();
                    foreach (KeyValuePair<int, Student> item in listOfStudent)
                    {
                        item.Value.CalAvg();
                        item.Value.Print();
                    }

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("=======================================");
                    Console.WriteLine("1. Find by ID...");
                    Console.WriteLine("2. Find by Name...");
                    Console.WriteLine("3. Find by Class...");
                    Console.WriteLine("4. Return.");
                    Console.WriteLine("=======================================");
                    Console.Write("Option: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                            Console.Write("Input ID: ");
                            int a = Convert.ToInt32(Console.ReadLine());

                            Student student2 = new Student();
                            if (listOfStudent.TryGetValue(a, out student2))
                            {
                                Console.WriteLine("Find success!");
                                Console.Write("----- Student's information -----");
                                student2.Print();
                                break;
                            }

                            Console.WriteLine("Student is not exist!");
                            break;
                        case 2:
                            Console.Write("Input Name: ");
                            string s = Console.ReadLine();

                            var student3 = listOfStudent.Where(x => x.Value.StudName == s).FirstOrDefault();
                            if (student3.Value == null)
                            {
                                Console.WriteLine("Student is not exist!");
                                break;
                            }
                            Console.WriteLine("Find success!");
                            Console.Write("----- Student's information -----");
                            student3.Value.Print();

                            break;
                        case 3:
                            List<Student> list = new List<Student>();
                            Console.Write("Input Class: ");
                            string d = Console.ReadLine();

                            var student4 = listOfStudent.Where(x => x.Value.StudClass == d).FirstOrDefault();
                            if (student4.Value == null)
                            {
                                Console.WriteLine("Student is not exist!");
                                break;
                            }

                            Console.WriteLine("Find success!");
                            foreach (KeyValuePair<int, Student> item in listOfStudent)
                            {
                                if (item.Value.StudClass == d)
                                {
                                    list.Add(item.Value);
                                }
                            }

                            list.Sort
                                (
                                (x, y) => x.StudName.CompareTo(y.StudName)
                                );

                            foreach (Student item in list)
                            {
                                item.Print();
                            }

                            break;
                        case 4:
                            goto Nhap;
                        default:
                            break;
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.Write("Input is invalid! please re-input: ");
                    goto Nhap;
            }

            Console.Write("Do you want to continue?(Y/N): ");
        Continue:
            char c = Convert.ToChar(Console.ReadLine());
            if (c == 'y' || c == 'Y')
            {
                goto Nhap;
            }
            else if (c == 'n' || c == 'N')
            {
                return;
            }
            else
            {
                Console.Write("Input is invalid! please re-input: ");
                goto Continue;
            }
        }
    }
}

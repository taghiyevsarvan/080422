using System;
using System.Collections.Generic;

namespace _080422
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            menu:
            Console.WriteLine("========MENU=======");
            Console.WriteLine("1. Telebe elave et\n2. Telebeye imtahan elave et\n3 .Telebenin bir imtahan balina bax");
            Console.WriteLine("4. Telebenin bütün imtahanlarini goster\n5. Telebenin imtahan ortalamasini goster");
            Console.WriteLine("6. Telebeden imtahan sil\n0. Proqrami bitir");
            Console.Write("\nSeciminiz: ");
            string choose = Console.ReadLine();
            string examName;
            double studentPoint;
            bool quit=false;
            int studentNo;
            Student checkStudentNo;
            do
            {
                switch (choose)
                {
                    case "1":
                        Student student = new Student();
                        Console.Write("Telebenin adi ve soyadini daxil edin: ");
                        student.FullName = Console.ReadLine();
                        students.Add(student);
                        Console.WriteLine("\nTelebe elave edildi...");
                        goto menu;
                    case "2":
                        studentNo = IntChecker("Telebe No: ", "Telebe No duzgun daxil edin: ");
                        Console.Write("Imtahan adi: ");
                        examName = Console.ReadLine();
                        studentPoint = DoubleChecker("Imtahan balini daxil edin: ", "Imtahan bali 0 ve 100 arasinda olmalidir: ");
                        checkStudentNo = students.Find(student => student.No == studentNo);
                        if (checkStudentNo != null)
                            checkStudentNo.AddExam(examName, studentPoint);
                        Console.WriteLine("Imthana elave edildi...");
                        goto menu;
                    case "3":
                        studentNo = IntChecker("Telebe No: ", "Telebe No duzgun daxil edin: ");
                        Console.Write("Imtahan adi: ");
                        examName = Console.ReadLine();
                        checkStudentNo = students.Find(student => student.No == studentNo);
                        if (checkStudentNo != null)
                        {
                            Console.Write(studentNo + ".Telebenin " + examName + " adli imtahan bali: ");
                            Console.WriteLine(checkStudentNo.GetExamResult(examName));
                        }
                        goto menu;
                    case "4":
                        studentNo = IntChecker("Telebe No: ", "Telebe No duzgun daxil edin: ");
                        checkStudentNo = students.Find(student => student.No == studentNo);
                        if (checkStudentNo != null)
                        {
                            Console.Write(studentNo + ".Telebenin imtahan ballari: ");
                            foreach (var stdnt in checkStudentNo.Exams)
                            {
                                int i = 0;
                                i++;
                                Console.WriteLine(i + "." + "imtahan: " + stdnt.Key + " - Bal: " + stdnt.Value);
                            }
                        }
                        goto menu;
                    case "5":
                        studentNo = IntChecker("Telebe No Daxil Edin :", "Telebe No Duzgun Daxil Edin :");
                        checkStudentNo = students.Find(std => std.No == studentNo);
                        if (checkStudentNo != null)
                        {
                            Console.Write(studentNo + ".Telebenin imtahanlarinin ortalama bali: ");
                            Console.WriteLine(checkStudentNo.GetExamAvg());
                        }
                        goto menu;
                    case "6":
                        studentNo = IntChecker("No :", "No int olsun :");
                        examName = Console.ReadLine();
                        checkStudentNo = students.Find(std => std.No == studentNo);
                        if (checkStudentNo != null)
                        {
                            if (checkStudentNo.Exams.ContainsKey(examName))
                            {
                                checkStudentNo.Exams.Remove(examName);
                                Console.WriteLine("Daxil edilen imtahan silindi...");
                            }
                        }
                        goto menu;
                    case "0":
                        quit = true;
                        Console.WriteLine("\nProgram dayandirildi...");
                        break;
                    default:
                        goto menu;
                }
            } while (!quit);
        }
        
        static double DoubleChecker(string msj, string wrong)
        {
            Console.Write(msj);
            string DoubleStr = Console.ReadLine();
            bool checkDouble;
            double no;
            checkDouble = Double.TryParse(DoubleStr, out no);
            while (!checkDouble)
            {
                Console.Write(wrong);
                DoubleStr = Console.ReadLine();
                checkDouble = double.TryParse(DoubleStr, out no);
            }
            return no;
        }

        static int IntChecker(string msj, string wrong)
        {
            Console.Write(msj);
            string noStr = Console.ReadLine();
            bool checkInt;
            int no;
            checkInt = int.TryParse(noStr, out no);
            while (!checkInt)
            {
                Console.Write(wrong);
                noStr = Console.ReadLine();
                checkInt = int.TryParse(noStr, out no);
            }
            return no;
        }

        

    }
}

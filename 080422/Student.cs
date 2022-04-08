using System;
using System.Collections.Generic;
using System.Text;

namespace _080422
{
    internal class Student
    {
        private static int _no;
        public Student()
        {
            _no++;
            this.No = _no;
        }

        public int No { get; }
        public string FullName { get; set; }
        public Dictionary<string, double> Exams = new Dictionary<string, double>();       

        public void AddExam(string examName, double point)
        {
            if (!string.IsNullOrEmpty(examName) && point <= 100 && point >= 0)
                Exams.Add(examName, point);            
        }

        public double GetExamResult(string examName)
        {
            if (!string.IsNullOrEmpty(examName))
            {

                if (Exams.ContainsKey(examName))
                {
                    return Exams[examName];
                }
                else
                {
                    throw new Exception("imtahan tapilmadi.");
                }
            }
            else
                throw new NullReferenceException("examName null ola bilmez.");
            
        }
        public double GetExamAvg()
        {
            double avgTotal = 0;
            foreach (var item in Exams)
            {
                avgTotal = avgTotal + item.Value;
            }
            return avgTotal = avgTotal / Exams.Count;
        }

    }
}

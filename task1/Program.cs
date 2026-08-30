using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Degree from 0 to 100:");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Attendance Rate from 0 to 100:");
            int attendance_rate= int.Parse(Console.ReadLine());
            if (degree < 0 || degree > 100 ||
            attendance_rate < 0 || attendance_rate > 100)
            {
                Console.WriteLine("Invalid Input: Values must be between 0 and 100.");
                return;
            }

            if (attendance_rate < 75)
            {
                Console.WriteLine("Status: Failed - Reason: Low Attendance Rate\" (Do not evaluate the grade");
                return;
            }
            if (degree>=90){
                Console.WriteLine("Grade: A (Excellent)");
            }
            else if (degree>= 80)
            {
                Console.WriteLine("Grade: B (Very Good)");
            }
            else if (degree>= 70)
            {
                Console.WriteLine("Grade: C (Good)");
            }
            else if (degree>= 50)
            {
                Console.WriteLine("Grade: D (Pass)");
            }
            else
            {
                Console.WriteLine("Grade: F (Fail)");
            }
        }
    }
}

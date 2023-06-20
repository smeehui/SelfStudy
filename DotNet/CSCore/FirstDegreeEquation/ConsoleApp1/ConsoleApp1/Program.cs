using System.Runtime.CompilerServices;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Giai phuong trinh bac hai: aX^2 + bX + c = 0");
        double a = EnterOperants("A");
        double b = EnterOperants("B");
        double c = EnterOperants("C");
        if (a==0)
        {
            if (b!=0)
            {
                PrintMessage("Phuong trinh mot nghiem la: " + SolveFirstDegEquation(b, c));
            }
            else if (c!=0) { 
                PrintMessage("Phuong trinh vo nghiem.");
            }else
            {
                PrintMessage("Phuong trinh vo so nghiem");
            }
        }
        else
        {
            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                PrintMessage("Phuong trinh vo nghiem");
            }
            else if (delta ==0)
            {
                PrintMessage("Phuong trinh co nghiem kep x1 = x2 = " + (-b / (2 * a)) );
            }
            else
            {
                PrintMessage("Phuong trinh co 2 nghiem:");
                PrintMessage("Nghiem x1: " + ((-b - Math.Sqrt(delta))/(2 * a)) );
                PrintMessage("Nghiem x2: " + ((-b + Math.Sqrt(delta))/(2 * a)) );
            }
        }
        Console.ReadLine();
    }

    private static void PrintMessage(string v)
    {
        Console.WriteLine($"{v}");
    }

    private static double SolveFirstDegEquation(double b, double c)
    {
        return -c / b;   
    }

    private static double EnterOperants(string operant)
    {
        Console.WriteLine("Nhap so hang {0}, # to return", operant);
        string enteredValue;
        while (true)
        {
            try
            {
                enteredValue = Console.ReadLine();
                if (enteredValue!=null)
                {
                    return double.Parse(enteredValue);
                }
                Console.WriteLine("Vui lòng nhập một số.");
            }
            catch(Exception) {
                Console.WriteLine("Số không hợp lệ, vui lòng nhập lại");
            }
        }
    }
}
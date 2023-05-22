// using System;
internal class Program
{
   public static void Main(string[] args)
   {
        bool? a = null;
        a = (true || false) && true;
        Console.WriteLine(a);
        Console.ReadLine();
    }
}
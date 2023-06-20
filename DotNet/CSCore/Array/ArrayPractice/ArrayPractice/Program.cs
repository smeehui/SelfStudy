using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] a = { 1, 20, 39, 4, 5, 6, 70, 8, 9, 10, 11 };
        //foreach (var item in a)
        //{
        //    Console.WriteLine(item);
        //}
        IOrderedEnumerable<int> orderedEnumerable= a.OrderDescending();
        foreach (var item in orderedEnumerable)
        {
            Console.Write(item);
            Console.Write("-");
        }
        Console.WriteLine(a.Rank);
        Console.ReadLine();
    }
}
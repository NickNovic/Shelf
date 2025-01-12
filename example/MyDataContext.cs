
using src.Models;
using src.Models.Abstractions;

namespace example;

public class MyDataContext : DataContext
{
    public Dataset<int>? Nums { get; set; }   
    public override void Setup()
    {
        Console.WriteLine("Setup");
        Nums = new Dataset<int>();
    }
}
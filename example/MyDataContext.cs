using src.Models;

namespace example;

public class MyDataContext : DataContext
{
    public Dataset<int>? Nums { get; set; }
    public Dataset<int>? Nums2 { get; set; }
    public Dataset<int>? Nums3 { get; set; }
    public override void Setup()
    {
        Console.WriteLine("Setup");
    }
}
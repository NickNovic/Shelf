using src.Models;
using src.Models.Abstractions;
using src.Services.QueryProcessor;

namespace example;

public class Program
{
    public static void Main()
    {
        using(MyDataContext dataContext = new()){
            var res = dataContext.Nums.Where(b => b == 0).ToList();
        }
    }
}
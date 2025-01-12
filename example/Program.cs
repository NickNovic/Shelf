// ============================================================
// File Name: Program.cs
// Created On: 12-01-2025
// Description: Code in this folder represents a simple example
// of how to use project from src folder.
// ============================================================

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
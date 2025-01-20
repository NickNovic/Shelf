// ============================================================
// File Name: DataContext.cs
// Created On: 10-01-2025
// Description: Here I describe DataContext class. It's used to
// connect to the database and execute queries.
// ============================================================

using src.Models.Abstractions;

namespace src.Models;

public abstract class DataContext : IDisposable
{
    public DataContext()
    {
        Setup();
        SetNamesForTables();

    }

    public virtual void Dispose()
    {
        Disconnect();
    }

    /// <summary>
    /// This method is called when DataContext is created.
    /// It's used to set up DataContext.
    /// For example, it can be used to set up database connection.
    /// </summary>
    public abstract void Setup();

    public virtual void Disconnect()
    {
        Console.WriteLine("Disconnect");
    }

    // this method works via reflection in runtime, what is kinda bad
    // In future, I will try to use reflection in compile time
    private void SetNamesForTables(){
        
        var props = GetType().GetProperties();
        foreach(var prop in props)
        {
            if(prop.PropertyType.IsAssignableTo(typeof(IDataset)))
            {
                //var dataset = Activator.CreateInstance(prop.PropertyType) as IDataset;
                prop.SetValue(this, Activator.CreateInstance(prop.PropertyType, prop.Name) as IDataset);
                //dataset.Name = prop.Name;
                //Console.WriteLine(prop..Name);
            }
        }
    }
}
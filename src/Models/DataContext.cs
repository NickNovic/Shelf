// ============================================================
// File Name: DataContext.cs
// Created On: 10-01-2025
// Description: Here I describe DataContext class. It's used to
// connect to the database and execute queries.
// ============================================================

namespace src.Models;

public abstract class DataContext : IDisposable
{
    public DataContext()
    {
        Setup();
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
}
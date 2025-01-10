// ============================================================
// File Name: IDataset.cs
// Created On: 10-01-2025
// ============================================================
// Description: This interface is abstraction for 
// interraction with data in database
//  
// This Dataset inherit from IQueryable<T> and IQueryable,
// so it can be used in LINQ queries and on it can be performed
// any operations like First(), Count(), Where(), etc.
// Also, it contains methods like Add(), Remove(), Update() which
// Are not included in LINQ because, according to MSDN:
// "A query is an expression that retrieves data from a data source."
// So, operations like Add(), Remove(), Update() are not(and I hope never would be)
// included in LINQ.
// 
// ============================================================

using System.Linq.Expressions;

namespace src.Models.Abstractions;

public interface IDataset<T> : IQueryable<T>, IQueryable
{
    // I think Async methods sometimes would cause problems
    public void Add(T entity);
    public void AddAsync(T entity);
    public void AddRange(IEnumerable<T> entityes);
    public void AddRangeAsync(IEnumerable<T> entityes);
    public void Remove(T entity);
    public void RemoveAsync(T entity);
    public void RemoveRange(IEnumerable<T> entityes);
    public void RemoveRangeAsync(IEnumerable<T> entityes);
    public void Update(T entity);
    public void UpdateAsync(T entity);
    public void SaveChanges();
    public void SaveChangesAsync();
    
    // These async methods are asyncronus override of LINQ methods

    // TODO: Create separate class which extends functionality of IDataset<T>
    // with these async methods.

    // public void FirstOrDefaultAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void FirstAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void LastOrDefaultAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void LastAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void SingleOrDefaultAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void SingleAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
    // public void CountAsync(this IQueryable<T> source, Expression<Func<T, bool>> predicate);
}
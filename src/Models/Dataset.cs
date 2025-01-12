// ============================================================
// File Name: Dataset.cs
// Created On: 10-01-2025
// Description: Default implementation of IDataset<T>
// ============================================================

using System.Linq.Expressions;
using System.Collections;
using src.Models.Abstractions;

namespace src.Models;

public class Dataset<T> : IDataset<T>, IQueryable<T>, IQueryable, IEnumerable<T>, IEnumerable
{
    public Expression Expression { get; }
    
    public IQueryProvider Provider { get; }
    
    public Dataset()
    {
        Provider = new QuerryProvider();
        Expression = Expression.Constant(this);
    }
    public Dataset(IQueryProvider provider, Expression expression)
    {
        Provider = provider; 
        Expression = expression;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<T> entityes)
    {
        throw new NotImplementedException();
    }

    public void AddRangeAsync(IEnumerable<T> entityes)
    {
        throw new NotImplementedException();
    }

    public void RemoveAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entityes)
    {
        throw new NotImplementedException();
    }

    public void RemoveRangeAsync(IEnumerable<T> entityes)
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Type ElementType => typeof(T);
}
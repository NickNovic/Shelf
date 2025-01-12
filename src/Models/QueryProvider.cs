// ============================================================
// File Name: QueryProvider.cs
// Created On: 12-01-2025
// This class is used to manage LINQ queries.
// It implements IQueryProvider interface for LINQ queries.
// ============================================================ 

using System.Data;
using System.Linq.Expressions;
using src.Models;
using src.Services.QueryProcessor;

internal class QuerryProvider : IQueryProvider
{
    public IQueryable CreateQuery(Expression expression)
    {
        var elementType = expression.Type.GetGenericArguments().First();
        var queryableType = typeof(DataSet).MakeGenericType(elementType);
        return (IQueryable)Activator.CreateInstance(queryableType, this, expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        return new Dataset<TElement>(this, expression);
    }

    public object Execute(Expression expression)
    {
        // Translate and execute the expression tree.
        return Execute<object>(expression);
    }

    public TResult Execute<TResult>(Expression expression)
    {
        if(expression is not MethodCallExpression){
            throw new ArgumentException("Expression must be a method call expression");
        }

        ReadQueryProcessor readQueryProcessor = new();
        var query = readQueryProcessor.Read(expression);
        
        // Custom logic for query execution (e.g., database or API call)

        // This is a dummy implementation for demonstration purposes.
        return (TResult)(new List<int>()).AsQueryable();
    }
}
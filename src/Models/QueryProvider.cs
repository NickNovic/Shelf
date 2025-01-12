using System.Data;
using System.Linq.Expressions;
using src.Models;

public class QuerryProvider : IQueryProvider
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
        // Custom logic for query execution (e.g., database or API call)
        throw new NotImplementedException();
    }
}
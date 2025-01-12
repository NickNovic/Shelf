// ============================================================
// File Name: ReadQueryProcessor.cs
// Created On: 12-01-2025
// Description: This querry processor now has dummy implementation
// just for demonstration purposes.
// ============================================================

using System.Linq.Expressions;

namespace src.Services.QueryProcessor;

public class ReadQueryProcessor : IQueryProcessor
{
    public string Read(Expression expression)
    {
        if(expression is not MethodCallExpression){
            throw new ArgumentException("Expression must be a method call expression");
        }
        
        var methodExpression = expression as MethodCallExpression;

        string query = "";
        if(methodExpression.Method.Name == "Where")
        {
            string lambda = ReadLambda(methodExpression.Arguments[1]);
            query = "WHERE" + " " + lambda;
        }
        
        Console.WriteLine(query);
        return query;
    }

    private string ReadLambda(Expression expression)
    {   
        var binaryExpression = expression as UnaryExpression;
        
        if(binaryExpression != null){
            var lambda = binaryExpression.Operand as LambdaExpression;
            var body = lambda.Body.ToString();
            var result = body.Remove(0,1);
            result = result.Remove(result.Length-1);
            
            return result;
        }

        throw new ArgumentException("Invalid expression");
    }
}
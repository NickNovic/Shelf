// ============================================================
// File Name: ReadQueryProcessor.cs
// Created On: 12-01-2025
// Description: This querry processor now has dummy implementation
// just for demonstration purposes.
// ============================================================

using System.Linq.Expressions;
using src.Models;
using src.Models.Abstractions;

namespace src.Services.QueryProcessor;

public class ReadQueryProcessor : IQueryProcessor
{
    private readonly ReadQueryBuilder _readQueryBuilder = new();
    
    public string Read(Expression expression)
    {
        if(expression is not MethodCallExpression){
            throw new ArgumentException("Invalid expression");
        }
        
        var methodCallExpression = expression as MethodCallExpression;
        var methodName = methodCallExpression.Method.Name;

        if(methodCallExpression.Arguments.First() is not ConstantExpression)
        {
            Read(methodCallExpression.Arguments.First());
        }else{
            var constant = methodCallExpression.Arguments.First() as ConstantExpression;
            var dataset = (IDataset)constant.Value;
            _readQueryBuilder.SetFROM(dataset.Name);
            System.Console.WriteLine(_readQueryBuilder.BuildQuery());
        }

        return _readQueryBuilder.BuildQuery();
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
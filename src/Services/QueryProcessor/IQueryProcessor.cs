// ============================================================
// File Name: IQueryProcessor.cs
// Created On: 12-01-2025
// Description: This interface is used to process queries
// 
// In this project will be two realisations of this interface:
// 1. ReadQueryProcessor
// 2. WriteQueryProcessors
// They differ in the way that query they process.
// I plan to inject different implementations of this interface
// dependending on the type of query.
// ============================================================

using System.Linq.Expressions;

namespace src.Services.QueryProcessor;
public interface IQueryProcessor
{
    /// <summary>
    /// This method reads from expression and returns a 
    /// string that represents the query.
    /// </summary>
    /// <param name="expression">Expression to be processed</param>
    /// <returns>String that represents the query</returns>
    public string Read(Expression expression);
}
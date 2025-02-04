// ============================================================
// File Name: SqlGenerationException.cs
// Created On: 20-01-2025
// Description: Exception, that represents errors on generation of SQL Query
// ============================================================

namespace src.Exceptions
{
    public class SqlGenerationException : Exception
    {
        public SqlGenerationException(string message) : base(message){ }
    }
}
using System.Net.Security;

namespace src.Services.QueryProcessor;

public class ReadQueryBuilder
{   public Dictionary<string, List<string>> SqlMap { get; set; } = new(){
        {"SELECT", new()},
        {"FROM", new()},
        {"WHERE", new()},
        {"SORT BY", new()},
    };
    
    string _query = "";
    public ReadQueryBuilder SetSELECT(List<string> args)
    {
        _query += "SELECT ";
        
        foreach(var arg in args)
        {
            _query += arg + ", ";
        }

        return this;
    }
    
    public ReadQueryBuilder SetFROM(string table)
    {
        // if(_query.Length > 0)
        // {
        //     _query += "\n";
        // }
        // 
        // _query += "FROM " + table;

        SqlMap["FROM"].Add(table);


        return this;
    }

    public ReadQueryBuilder SetWHERE(string condition)
    {    
        if(_query.Length > 0)
        {
            _query += "\n";
        }
       
       _query += "WHERE " + condition;
       
       return this;
    }

    private void RestoreSqlMap()
    {
        if(SqlMap["SELECT"].Count == 0){
            SqlMap["SELECT"].Add("*");
        }
    }

    private string BuildQueryString()
    {
        foreach(var key in SqlMap.Keys){
            if(SqlMap[key].Count != 0)
            {
                _query += key + " " + string.Join(", ", SqlMap[key]) + "\n";
            }
        }
        return _query;
    }

    public string BuildQuery()
    {
        RestoreSqlMap();
        return BuildQueryString();
    }
}
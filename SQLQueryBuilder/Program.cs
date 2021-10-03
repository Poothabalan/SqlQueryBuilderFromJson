using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using SQLQueryBuilder.Common;
using SQLQueryBuilder;
using SQLQueryBuilder.Implementations;
using SQLQueryBuilder.Interfaces;
using Microsoft.SqlServer.Management.SqlParser.Parser;

namespace SQLBuilderExecutor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SQL Query Builder  \n");

         Console.WriteLine("Evaluation - 1 \n");

            var jsonString = File.ReadAllText("Evaluation1_Input.json");
            StatementModel statementModel = Common.GetCommandObjectModel(jsonString);
            IOperation operation = OperationFactory.GetOperationObject(statementModel.Operation);
            string statement = operation.BuildQuery(statementModel);
            Console.WriteLine("Statement : \n");
            Console.WriteLine(statement+"\n");
            var parseResult = Parser.Parse(statement);
            Console.WriteLine($"Is SQL Parsing Successful :{(parseResult.Errors.Count() == 0 ? "Success":"Failure").ToString()}");

            //To Run the Second Evaluation please uncomment the below section

            /* Console.WriteLine("Evaluation - 2 \n");

            var jsonString = File.ReadAllText("Evaluation2_Input.json");
            StatementModel statementModel = Common.GetCommandObjectModel(jsonString);
            IOperation operation = OperationFactory.GetOperationObject(statementModel.Operation);
            string statement = operation.BuildQuery(statementModel);
            Console.WriteLine("Statement : \n");
            Console.WriteLine(statement + "\n");
            var parseResult = Parser.Parse(statement);
            Console.WriteLine($"Is SQL Parsing Successful :{(parseResult.Errors.Count() == 0 ? "Success" : "Failure").ToString()}");*/

            Console.ReadLine();
}
}
}

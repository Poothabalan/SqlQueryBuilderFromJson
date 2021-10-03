using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SQLQueryBuilder.Common
{
    public class Operators
    {
        public const string Equal = "Equal";
        public const string NotEqual = "NotEqual";
        public const string In = "In";
        public const string NotIn = "NotIn";
        public const string Between = "Between";
        public const string GreaterThanEq = "GTE";
    }
    public class Operation
    {
        public const string Select = "Select";
        public const string Delete = "Delete";
        public const string Update = "Update";
    }
    public class Attributes
    {
        public const string Name = "Name";
        public const string FieldName = "fieldName";
        public const string FieldValue = "fieldValue";
        public const string Operator = "Operator";
    }
    public class Common
    {
        /// <summary>
        /// Method for extracting the Model from JSON object
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static StatementModel GetCommandObjectModel(string jsonString)
        {
            StatementModel statementModel = new StatementModel();
            dynamic a = JsonConvert.DeserializeObject(jsonString);

            statementModel.TableName = a.TableName;
            statementModel.Operation = a.Operation;
            statementModel.columns = ((JArray)(a.columns)).Select(_column => new Column
            {
                Name = (string)_column[Attributes.Name]
            }).ToList();
            statementModel.ConditionalClauses = new ConditionalClauses();
            statementModel.ConditionalClauses.OR = ((JArray)(a.ConditionalClauses.OR)).Select(_attributes => new ConditionalAttributes
            {
                fieldName = (string)_attributes[Attributes.FieldName],
                fieldValue = _attributes[Attributes.FieldValue],
                Operator = (string)_attributes[Attributes.Operator]

            }).ToList();
            statementModel.ConditionalClauses.AND = ((JArray)(a.ConditionalClauses.AND)).Select(_attributes => new ConditionalAttributes
            {
                fieldName = (string)_attributes[Attributes.FieldName],
                fieldValue = _attributes[Attributes.FieldValue],
                Operator = (string)_attributes[Attributes.Operator]

            }).ToList();
            return statementModel;
        }
    }
}

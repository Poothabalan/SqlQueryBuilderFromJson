using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Common;
using SQLQueryBuilder.Interfaces;
using SQLQueryBuilder.Implementations;
using System.Linq;

namespace SQLQueryBuilder.Abstractions
{
    public abstract class Operator
    {
        /// <summary>
        /// Base Method for building the operand queries
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            if (value.GetType() == typeof(JValue) || value.GetType() == typeof(System.String))
            {
                int Conversion;
                _statement.AppendWithSpace(int.TryParse(value.ToString(), out Conversion) ? value.ToString() : "'"+ value.ToString()+"'");
            }
            if (value.GetType() == typeof(JObject))
            {
                StatementModel statementModel = Common.Common.GetCommandObjectModel(value.ToString());
                if (statementModel.columns.Count() != 1)
                    throw new Exception("In SubQuery Only one Column is Permissible");
                IOperation operation = OperationFactory.GetOperationObject(statementModel.Operation);
                string statement = operation.BuildQuery(statementModel);
                _statement.Append("(");
                _statement.AppendLine();
                _statement.AppendWithSpace(statement);
                _statement.AppendLine();
                _statement.AppendWithSpace(")");
            }
            return _statement.ToString();
        }
    }
}

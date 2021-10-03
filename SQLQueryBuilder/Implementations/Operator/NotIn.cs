using Newtonsoft.Json.Linq;
using SQLQueryBuilder.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Common;

namespace SQLQueryBuilder.Implementations
{
    public class NotIn : Operator
    {
        public override string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            _statement.AppendWithSpace("NOT IN");
            if (value.GetType() == typeof(JValue))
            {
                _statement.Append("(");
                _statement.Append(value.ToString());
                _statement.Append(")");
            }
            else
                _statement.Append(base.BuildOperand(value));
            return _statement.ToString();
        }
    }
}

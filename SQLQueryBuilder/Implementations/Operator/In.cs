using Newtonsoft.Json.Linq;
using SQLQueryBuilder.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Common;
using System.Linq;

namespace SQLQueryBuilder.Implementations
{
    public class In : Operator
    {
        public override string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            _statement.AppendWithSpace("IN");
            if (value.GetType() == typeof(JValue))
            {
                _statement.Append("(");
                _statement.Append(value.ToString());
                _statement.AppendWithSpace(")");
            }else if(value.GetType() == typeof(JArray))
            {
                _statement.Append("(");
                _statement.Append(string.Join(",", ((JArray)value).Select(e => {
                    int Conversion;
                    if (int.TryParse(e.ToString(), out Conversion))
                        return value.ToString();
                    else
                       return ("'" + e.ToString() + "'").ToString();
                    }).ToArray()));
                _statement.AppendWithSpace(")");
            }
            else
            _statement.Append(base.BuildOperand(value));
            return _statement.ToString();
        }
    }
}

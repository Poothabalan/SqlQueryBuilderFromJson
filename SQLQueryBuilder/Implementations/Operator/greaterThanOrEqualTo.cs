using System;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Common;
using SQLQueryBuilder.Abstractions;

namespace SQLQueryBuilder.Implementations
{
    public class GreaterThanOrEqualTo : Operator
    {
        public override string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            _statement.AppendWithSpace(">=");
            _statement.Append(base.BuildOperand(value));
            return _statement.ToString();
        }
    }
}

using SQLQueryBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SQLQueryBuilder.Abstractions;
using SQLQueryBuilder.Common;

namespace SQLQueryBuilder.Implementations
{
    public class Equal : Operator
    {
        public override string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            _statement.AppendWithSpace("=");
            _statement.Append(base.BuildOperand(value));
            return _statement.ToString();
        }
    }
}

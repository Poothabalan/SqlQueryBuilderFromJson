using SQLQueryBuilder.Abstractions;
using SQLQueryBuilder.Common;
using SQLQueryBuilder.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder.Factory
{
    public class OperatorFactory
    {
        public static Operator GetOperationObject(string strOperator)
        {
            switch (strOperator)
            {
                case Operators.Equal:
                    return new Equal();
                case Operators.NotEqual:
                    return new NotEqual();
                case Operators.In:
                    return new In();
                case Operators.NotIn:
                    return new NotIn();
                case Operators.Between:
                    return new Between();
                case Operators.GreaterThanEq:
                    return new GreaterThanOrEqualTo();
                default:
                    throw new Exception("Given Operator Not Supported by this SQLQueryBuilder");
            }
        }
    }
}

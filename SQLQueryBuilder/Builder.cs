using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder
{
    class Builder
    {
        public string BuildQuery(StatementModel root)
        {
            /*if (root == null)
                throw new NullReferenceException("Input Object Cannot be null");
            StringBuilder _statement =new StringBuilder();
            _statement.Append("Select * From "{root.TableName}" where ");
            foreach(ConditionalAttributes _conditionAttribute in root.ConditionalClauses.AND)
            {
                _statement.Append(_conditionAttribute.fieldName+" "{_conditionAttribute.Operator}+" "+{_conditionAttribute.fieldValue});
            }
            return _statement.ToString();*/
            return string.Empty;
        }
    }
}


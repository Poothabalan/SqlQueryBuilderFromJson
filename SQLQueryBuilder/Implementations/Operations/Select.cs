using SQLQueryBuilder.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Factory;
using SQLQueryBuilder.Abstractions;
using SQLQueryBuilder.Common;
using Newtonsoft.Json.Linq;

namespace SQLQueryBuilder.Implementations
{
    public class Select : IOperation
    {
        public string BuildQuery(StatementModel statementModel)
        {
            if (statementModel == null)
                throw new NullReferenceException("Input Object Cannot be null");
            StringBuilder _statement =new StringBuilder();
            _statement.AppendWithSpace("SELECT");
            if (statementModel.columns.Count() > 0)
            {
                _statement.AppendWithSpace(string.Join(",", statementModel.columns.Select(column=> column.Name).ToArray()));
            }
            else
                _statement.AppendWithSpace("*");
            _statement.AppendWithSpace("FROM");
            _statement.AppendLine(statementModel.TableName);
            if(statementModel.ConditionalClauses.AND.Count() >0 || statementModel.ConditionalClauses.OR.Count() > 0)
            _statement.AppendWithSpace("WHERE");
            ConditionalAttributes _cdnlAttrAndLast = statementModel.ConditionalClauses.AND.LastOrDefault();
            foreach (ConditionalAttributes _conditionAttribute in statementModel.ConditionalClauses.AND)
            {
                _statement.AppendWithSpace(_conditionAttribute.fieldName);
                Operator  _operator = OperatorFactory.GetOperationObject(_conditionAttribute.Operator);
                _statement.Append(_operator.BuildOperand(_conditionAttribute.fieldValue));
                if (!_conditionAttribute.Equals(_cdnlAttrAndLast))
                    _statement.AppendWithSpace("AND");
                else if(statementModel.ConditionalClauses.OR.Count() > 0)
                    _statement.AppendWithSpace("OR");
            }
            ConditionalAttributes _cdnlAttrORLast = statementModel.ConditionalClauses.OR.LastOrDefault();
            foreach (ConditionalAttributes _conditionAttribute in statementModel.ConditionalClauses.OR)
            {
                _statement.AppendWithSpace(_conditionAttribute.fieldName);
                Operator _operator = OperatorFactory.GetOperationObject(_conditionAttribute.Operator);
                _statement.Append(_operator.BuildOperand(_conditionAttribute.fieldValue));
                if (!_conditionAttribute.Equals(_cdnlAttrORLast))
                    _statement.AppendWithSpace("OR");
            }
            return _statement.ToString();
        }
    }
}

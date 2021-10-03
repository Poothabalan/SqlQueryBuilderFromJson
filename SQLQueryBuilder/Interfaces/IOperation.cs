using SQLQueryBuilder.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder.Interfaces
{
    public interface IOperation
    {
        public string BuildQuery(StatementModel statementModel);
    }
}

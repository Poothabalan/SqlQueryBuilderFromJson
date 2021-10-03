using SQLQueryBuilder.Common;
using SQLQueryBuilder.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder.Implementations
{
    class OperationFactory
    {
       public static IOperation GetOperationObject(string operation)
        {
            switch (operation)
            {
                case Operation.Update:
                    return new Update();
                case Operation.Delete:
                    return new Delete();
                case Operation.Select:
                default:
                    return new Select();
            }
        }
    }
}

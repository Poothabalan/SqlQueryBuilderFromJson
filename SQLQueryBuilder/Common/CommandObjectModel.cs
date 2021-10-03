using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder
{
   
    public class Column
    {
        public string Name { get; set; }
    }
    public class ConditionalAttributes
    {
        private object _fieldValue = string.Empty;
        public string fieldName { get; set; }
        public object fieldValue
        {
            get
            {
                return this._fieldValue;
            }
            set
            {
                this._fieldValue = value;
            }
        }
        public string Operator { get; set; }
    }

    public class ConditionalClauses
    {
        public List<ConditionalAttributes> OR { get; set; }
        public List<ConditionalAttributes> AND { get; set; }
    }

    public class StatementModel
    {
        public string TableName { get; set; }
        public List<Column> columns { get; set; }
        public ConditionalClauses ConditionalClauses { get; set; }

        public string Operation { get; set; }

    }
    public class BetweenModel
    {
        public string Smallest { get; set; }
        public string Largest { get; set; }
    }

}

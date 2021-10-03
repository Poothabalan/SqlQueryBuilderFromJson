using System;
using System.Collections.Generic;
using System.Text;
using SQLQueryBuilder.Common;
using SQLQueryBuilder.Abstractions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SQLQueryBuilder.Implementations
{
    public class Between : Operator
    {
        public override string BuildOperand(object value)
        {
            StringBuilder _statement = new StringBuilder();
            _statement.AppendWithSpace("Between");
            if(value.GetType() == typeof(JObject))
            {
                BetweenModel betweenModel = JsonConvert.DeserializeObject<BetweenModel>(value.ToString());
                if (string.IsNullOrEmpty(betweenModel.Smallest) || string.IsNullOrEmpty(betweenModel.Largest))
                    throw new Exception("For Between Operator Smallest and Largest Number Are mandatory");                       
                _statement.AppendWithSpace(betweenModel.Smallest);
                _statement.AppendWithSpace("and");
                _statement.AppendWithSpace(betweenModel.Largest);
            }
            return _statement.ToString();
        }
    }
}

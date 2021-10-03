using System;
using System.Collections.Generic;
using System.Text;

namespace SQLQueryBuilder.Common
{
    static class Extensions
    {
        public static StringBuilder AppendWithSpace(this StringBuilder stringBuilder,string inputString)
        {
            stringBuilder.Append(inputString);
            stringBuilder.Append(" ");
            return stringBuilder;
        }
    }
}

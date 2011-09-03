using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace TechTalk.SpecFlow.Future40Ideas
{
    public class DynamicSet : List<object>
    {
        public DynamicSet(Table table)
        {
            var pivotTable = new PivotTable(table);
            for (var index = 0; index < table.Rows.Count(); index++)
                Add(new DynamicInstance(pivotTable.GetInstanceTable(index)));
        }
    }
}
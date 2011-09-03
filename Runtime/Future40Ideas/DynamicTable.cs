using System.Dynamic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace TechTalk.SpecFlow.Future40Ideas
{
    public class DynamicTable : DynamicObject
    {
        private readonly Table table;

        public DynamicTable(Table table)
        {
            this.table = table;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (table.Rows.Any(x => binder.Name.MatchesThisColumnName(x[0])) == false) return false;
            result = table.Rows.First(x => binder.Name.MatchesThisColumnName(x[0]))[1];
            return true;
        }
    }
}
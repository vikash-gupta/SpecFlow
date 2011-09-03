using System.Dynamic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace TechTalk.SpecFlow.Future40Ideas
{
    public class DynamicInstance : DynamicObject
    {
        private readonly Table table;

        public DynamicInstance(Table table)
        {
            this.table = table;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (table.Rows.Any(x => MatchesThisColumnName(binder, x)) == false) return false;
            result = table.Rows.First(x => MatchesThisColumnName(binder, x))[1];
            return true;
        }

        private static bool MatchesThisColumnName(GetMemberBinder binder, TableRow x)
        {
            return binder.Name.MatchesThisColumnName(x[0]);
        }
    }
}
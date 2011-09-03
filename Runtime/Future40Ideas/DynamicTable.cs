using System.Dynamic;
using System.Linq;

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
            if (table.Rows.Any(x => x[0] == binder.Name) == false) return false;
            result = table.Rows.First(x => x[0] == binder.Name)[1];
            return true;
        }
    }
}
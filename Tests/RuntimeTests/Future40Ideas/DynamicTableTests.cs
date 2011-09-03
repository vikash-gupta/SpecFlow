using System.Dynamic;
using System.Linq;
using NUnit.Framework;
using Should;

namespace TechTalk.SpecFlow.RuntimeTests.Future40Ideas
{
    [TestFixture]
    public class DynamicTableTests
    {
        [Test]
        public void Returns_Galt_as_last_name_with_LastName_Galt_table_row()
        {
            var table = new Table("Field", "Value");
            table.AddRow("LastName", "Galt");

            dynamic dynamicTable = new DynamicTable(table);

            string value = dynamicTable.LastName;

            value.ShouldEqual("Galt");
        }

        [Test]
        public void Returns_John_as_first_name_when_John_is_the_second_row_in_the_table()
        {
            var table = new Table("Field", "Value");
            table.AddRow("LastName", "Galt");
            table.AddRow("FirstName", "John");

            dynamic dynamicTable = new DynamicTable(table);

            string value = dynamicTable.FirstName;

            value.ShouldEqual("John");
        }

        [Test]
        public void Uses_the_first_column_to_determine_the_field_name_instead_of_Field()
        {
            var table = new Table("x", "Value");
            table.AddRow("LastName", "Galt");

            dynamic dynamicTable = new DynamicTable(table);

            string value = dynamicTable.LastName;

            value.ShouldEqual("Galt");
        }

        [Test]
        public void Uses_the_second_column_to_determine_the_value_instead_of_Value()
        {
            var table = new Table("Field", "y");
            table.AddRow("LastName", "Galt");

            dynamic dynamicTable = new DynamicTable(table);

            string value = dynamicTable.LastName;

            value.ShouldEqual("Galt");
        }
    }

    public class DynamicTable : DynamicObject
    {
        private readonly Table table;

        public DynamicTable(Table table)
        {
            this.table = table;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = table.Rows.First(x => x[0] == binder.Name)[1];
            return true;
        }
    }
}
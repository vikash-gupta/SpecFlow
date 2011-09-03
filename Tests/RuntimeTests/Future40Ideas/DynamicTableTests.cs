using System;
using Microsoft.CSharp.RuntimeBinder;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Future40Ideas;

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

        [Test]
        public void Returns_property_not_found_exception_for_property_that_does_not_exist()


        {
            var table = new Table("x", "y");
            table.AddRow("LastName", "Galt");

            dynamic dynamicTable = new DynamicTable(table);

            Exception exception = null;
            try
            {
                var value = dynamicTable.IDoNotExist;
            } catch(Exception ex)
            {
                exception = ex;
            }
            exception.ShouldNotBeNull();
            exception.ShouldBeType(typeof (RuntimeBinderException));
        }

        [Test]
        public void Uses_intelligent_name_matching_for_field_names()
        {
            var table = new Table("Field", "Value");
            table.AddRow("LastName", "Wyatt");
            table.AddRow("first name", "Ellis");

            dynamic dynamicTable = new DynamicTable(table);

            string value = dynamicTable.FirstName;

            value.ShouldEqual("Ellis");            
        }
    }
}
using System.Linq;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Future40Ideas;

namespace TechTalk.SpecFlow.RuntimeTests.Future40Ideas
{
    [TestFixture]
    public class DynamicSetTests
    {
        [Test]
        public void Passing_in_a_table_with_one_row_results_in_one_dynamic_instance()
        {
            var table = new Table("FirstName", "LastName");
            table.AddRow("Ellis", "Wyatt");

            var dynamicSet = new DynamicSet(table);

            dynamicSet.Count.ShouldEqual(1);
            Assert.IsInstanceOf(typeof (DynamicInstance), dynamicSet.First());
        }

        [Test]
        public void Passing_in_a_table_with_two_rows_results_in_two_dynamic_instances()
        {
            var table = new Table("FirstName", "LastName");
            table.AddRow("Ellis", "Wyatt");
            table.AddRow("Dominique", "Roark");

            var dynamicSet = new DynamicSet(table);

            dynamicSet.Count.ShouldEqual(2);
            Assert.IsInstanceOf(typeof (DynamicInstance), dynamicSet.First());
            Assert.IsInstanceOf(typeof (DynamicInstance), dynamicSet.Last());
        }

        [Test]
        public void Values_from_the_set_table_are_passed_to_the_dynamic_isntances()
        {
            var table = new Table("FirstName", "LastName");
            table.AddRow("Ellis", "Wyatt");
            table.AddRow("Dominique", "Roark");

            var dynamicSet = new DynamicSet(table);

            dynamic first = dynamicSet.First();
            Assert.AreEqual("Ellis", first.FirstName);
            Assert.AreEqual("Wyatt", first.LastName);

            dynamic second = dynamicSet.Last();
            Assert.AreEqual("Dominique", second.FirstName);
            Assert.AreEqual("Roark", second.LastName);
        }
    }
}
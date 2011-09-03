using System.Linq;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Future40Ideas;

namespace TechTalk.SpecFlow.RuntimeTests.Future40Ideas
{
    [TestFixture]
    public class DynamicHelperTests
    {
        [Test]
        public void ToDynamicInstance_returns_a_dynamic_instance_of_the_table()
        {
            var table = new Table("x", "y");
            table.AddRow("FirstName", "Howard");
            table.AddRow("LastName", "Roark");

            dynamic dynamicInstance = table.ToDynamicInstance();

            Assert.IsNotNull(dynamicInstance);
            Assert.AreEqual("Howard", dynamicInstance.FirstName);
            Assert.AreEqual("Roark", dynamicInstance.LastName);
        }

        [Test]
        public void ToDynamicSet_returns_a_dynamic_set_of_the_table()
        {
            var table = new Table("Name", "Sku");
            table.AddRow("Baby bottle", "bottle");
            table.AddRow("Baby bib", "bib");

            var dynamicSet = table.ToDynamicSet();

            dynamicSet.Count.ShouldEqual(2);

            dynamic first = dynamicSet.First();
            Assert.AreEqual("Baby bottle", first.Name);
            Assert.AreEqual("bottle", first.Sku);

            dynamic second = dynamicSet.First();
            Assert.AreEqual("Baby bottle", second.Name);
            Assert.AreEqual("bottle", second.Sku);
        }
    }
}
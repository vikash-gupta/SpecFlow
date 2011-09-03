using NUnit.Framework;
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
    }
}
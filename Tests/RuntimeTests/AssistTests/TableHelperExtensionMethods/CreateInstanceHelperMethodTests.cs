using System;
using System.Globalization;
using Moq;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.RuntimeTests.AssistTests.ExampleEntities;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.TableHelperExtensionMethods
{
    [TestFixture]
    public class CreateInstanceHelperMethodTests : CreateInstanceHelperMethodTestBase
    {
        public CreateInstanceHelperMethodTests()
            : base(t => t.CreateInstance<Person>())
        {
        }

        [Test]
        public virtual void Create_instance_will_return_an_instance_of_T()
        {
            var table = new Table("Field", "Value");
            var person = GetThePerson(table);
            person.ShouldNotBeNull();
        }

        [Test]
        public void Can_create_an_instance_with_similar_enum_values()
        {
            var table = new Table("Field", "Value");
            table.AddRow("FourthColor", "Green");
            table.AddRow("ThirdColor", "Red");
            table.AddRow("SecondColor", "Red");
            table.AddRow("FirstColor", "Red");

            var @class = table.CreateInstance<AClassWithMultipleEnums>();

            @class.FirstColor.ShouldEqual(AClassWithMultipleEnums.Color.Red);
            @class.SecondColor.ShouldEqual(AClassWithMultipleEnums.ColorAgain.Red);
            @class.ThirdColor.ShouldEqual(AClassWithMultipleEnums.Color.Red);
            @class.FourthColor.ShouldEqual(AClassWithMultipleEnums.ColorAgain.Green);
        }

        public class AClassWithMultipleEnums
        {
            public Color FirstColor { get; set; }
            public ColorAgain SecondColor { get; set; }
            public Color ThirdColor { get; set; }
            public ColorAgain FourthColor { get; set; }

            public enum Color { Red, Green, Blue }
            public enum ColorAgain { Red, Green, Blue}
        }
    }

    [TestFixture]
    public class CreateInstanceSupportForStepArgumentTransformations
    {
        [Test]
        public void CreateInstance_will_use_available_step_argument_transformations_to_set_the_value()
        {
            var table = new Table("Field", "Value");
            table.AddRow("Thing", "Expected value");

            var mock = new Mock<IStepArgumentTypeConverter>();
            mock.Setup(x => x.CanConvert("Expected value", typeof (TestingTransform), CultureInfo.InvariantCulture))
                .Returns(true);
            var expected = new TestingTransform();
            mock.Setup(x => x.Convert("Expected value", typeof (TestingTransform), CultureInfo.InvariantCulture))
                .Returns(expected);

            ObjectContainer.StepArgumentTypeConverter = mock.Object;

            var container = table.CreateInstance<TestingContainer>();

            container.Thing.ShouldBeSameAs(expected);
        }

        public class TestingContainer
        {
            public TestingTransform Thing { get; set; }
        }

        public class TestingTransform
        {
            public string Name { get; set; }
        }
    }
}
using Messages.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messages.Core.Enums.Extensions;
using FluentAssertions;

namespace Messages.Core.UnitTests.Enum
{
    [TestClass, TestCategory(nameof(Enums.Extensions))]
    public class GetDescriptionUnitTests : BaseMock
    {
        [TestMethod]
        public void GetDescription_ShouldRetornEmptyString_FieldInfoIsNull()
        {
            var messageType = (MessageType)int.MaxValue;

            var response = messageType.GetDescription();

            response.Should().BeEmpty();
        }

        [TestMethod]
        public void GetDescription_ShouldReturnEnumToString_NoCustomAttributes()
        {
            var testEnum = AnyEnum.Any;

            var response = testEnum.GetDescription();

            response.Should().Be("Any");
        }

        [TestMethod]
        public void GetDescription_ShouldReturnEnumDescription_CustomAttibuteDefined()
        {
            var testEnum = AnyEnum.None;

            var response = testEnum.GetDescription();

            response.Should().Be("Undefined");
        }
    }
}

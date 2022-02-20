using FluentAssertions;
using Messages.Core.Enums;
using Messages.Core.Enums.Extensions;
using Messages.Core.Tests.Shared;
using Xunit;

namespace Messages.Core.Tests.Enum
{
    public class GetDescriptionUnitTests : BaseMock
    {
        [Fact]
        public void GetDescription_ShouldReturnEmptyString_FieldInfoIsNull()
        {
            var messageType = (MessageType)int.MaxValue;

            var response = messageType.GetDescription();

            response.Should().BeEmpty();
        }

        [Fact]
        public void GetDescription_ShouldReturnEnumToString_NoCustomAttributes()
        {
            var testEnum = AnyEnum.Any;

            var response = testEnum.GetDescription();

            response.Should().Be("Any");
        }

        [Fact]
        public void GetDescription_ShouldReturnEnumDescription_CustomAttibuteDefined()
        {
            var testEnum = AnyEnum.None;

            var response = testEnum.GetDescription();

            response.Should().Be("Undefined");
        }
    }
}

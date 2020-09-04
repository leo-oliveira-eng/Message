using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.VoidResponse
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class OkUnitTests : BaseMock
    {
        [TestMethod]
        public void OkResponse_ShouldCreateVoidResponse()
        {
            var response = Core.Response.Ok();

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }

        [TestMethod]
        public void OkResponse_ShouldCreateResponseWithOneMessage()
        {
            var message = MessageFake();

            var response = Core.Response.Ok(message);

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().Contain(message);
            response.Messages.Count.Should().Be(1);
        }
    }
}

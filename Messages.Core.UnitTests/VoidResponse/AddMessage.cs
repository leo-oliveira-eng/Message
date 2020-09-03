using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.VoidResponse
{
    [TestClass, TestCategory(nameof(Response))]
    public class AddMessage : BaseMock
    {
        [TestMethod]
        public void AddMessage_ShouldAddOneMessageToResponse()
        {
            var message = MessageFake();
            var voidResponse = Response.Create();

            var response = voidResponse.AddMessage(message);

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().Contain(message);
            response.Messages.Count.Should().Be(1);
        }
    }
}

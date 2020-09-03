using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.VoidResponse
{
    [TestClass, TestCategory(nameof(Response))]
    public class CreateUnitTests
    {
        [TestMethod]
        public void CreateResponse_ShouldCreateVoidResponse()
        {
            var response = Response.Create();

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }
    }
}

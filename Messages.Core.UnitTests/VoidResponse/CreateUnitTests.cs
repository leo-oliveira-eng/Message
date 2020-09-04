using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.VoidResponse
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class CreateUnitTests
    {
        [TestMethod]
        public void CreateResponse_ShouldCreateVoidResponse()
        {
            var response = Core.Response.Create();

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }
    }
}

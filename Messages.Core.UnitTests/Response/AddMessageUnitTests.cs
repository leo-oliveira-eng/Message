using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Response
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class AddMessageUnitTests : BaseMock
    {
        [TestMethod]
        public void SetValue_ShoultAddAMessageToResponse()
        {
            var student = StudentFake();
            var response = Response<Student>.Create();

            response.SetValue(student);

            response.HasError.Should().BeFalse();
            response.Data.HasValue.Should().BeTrue();
            response.Data.Value.Should().Be(student);
        }
    }
}

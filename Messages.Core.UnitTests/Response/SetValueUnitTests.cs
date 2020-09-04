using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Response
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class SetValueUnitTests : BaseMock
    {
        [TestMethod]
        public void SetValue_ShoultAssignAValueToResponse()
        {
            var student = StudentFake();
            var response = Core.Response<Student>.Create();

            response.SetValue(student);

            response.HasError.Should().BeFalse();
            response.Data.HasValue.Should().BeTrue();
            response.Data.Value.Should().Be(student);
        }
    }
}

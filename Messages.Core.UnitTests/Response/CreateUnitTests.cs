using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Response
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class CreateUnitTests : BaseMock
    {
        [TestMethod]
        public void CreateResponse_ShouldCreateResponseWithoutValue()
        {
            var response = Core.Response<Student>.Create();

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }

        [TestMethod]
        public void CreateResponse_ShouldCreateResponseEncapsulatingStudent()
        {
            var student = StudentFake();

            var response = Core.Response<Student>.Create(student);

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }
    }
}

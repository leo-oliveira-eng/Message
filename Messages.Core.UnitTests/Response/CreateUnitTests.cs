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
            var response = Response<Student>.Create();

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }

        [TestMethod]
        public void CreateResponse_ShouldCreateResponseEncapsulatingStudent()
        {
            var student = StudentFake();

            var response = Response<Student>.Create(student);

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().BeEmpty();
        }

        [TestMethod]
        public void CreateResponse_ShouldCreateResponseEncapsulatingStudentAndMessage()
        {
            var student = StudentFake();

            var response = Response<Student>.Create(MessageFake(), student);

            response.Should().NotBeNull();
            response.HasError.Should().BeFalse();
            response.Messages.Should().HaveCount(1);
            response.Data.HasValue.Should().BeTrue();
            response.Data.Value.Should().Be(student);
        }

        [TestMethod]
        public void CreateResponse_ShouldCreateResponseEncapsulatingMessage()
        {
            var response = Response<Student>.Create(MessageFake(text: "error", type: Enums.MessageType.BusinessError));

            response.Should().NotBeNull();
            response.HasError.Should().BeTrue();
            response.Messages.Should().HaveCount(1);
            response.Data.HasValue.Should().BeFalse();
            response.Data.Value.Should().BeNull();
        }
    }
}

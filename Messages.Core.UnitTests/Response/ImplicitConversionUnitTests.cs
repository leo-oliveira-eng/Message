using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Response
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class ImplicitConversionUnitTests : BaseMock
    {
        [TestMethod]
        public void ConversionOperator_ShouldPerformImplicitConversion()
        {
            var student = StudentFake();

            Response<Student> GetStudent() => student;

            var response = GetStudent();

            response.Data.HasValue.Should().BeTrue();
            response.Data.Value.Should().Be(student);
        }
    }
}

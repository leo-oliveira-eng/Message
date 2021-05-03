using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Maybe
{
    [TestClass, TestCategory("Maybe")]
    public class ImplicitConvertionUnitTests : BaseMock
    {
        [TestMethod]
        public void ConversionOperator_ShouldPerformImplicitConversion()
        {
            var student = StudentFake();

            Maybe<Student> GetStudent() => student;

            var response = GetStudent();

            response.HasValue.Should().BeTrue();
            response.Value.Should().Be(student);
        }
    }
}

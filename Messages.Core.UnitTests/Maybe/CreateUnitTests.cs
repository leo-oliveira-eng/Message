using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Maybe
{
    [TestClass, TestCategory("Maybe")]
    public class CreateUnitTests : BaseMock
    {
        [TestMethod]
        public void CreateMaybe_ShouldCreateWithoutParameters()
        {
            var student = StudentFake();
                
            var response = Maybe<Student>.Create(student);

            response.HasValue.Should().BeTrue();
            response.Value.Should().Be(student);
        }
    }
}

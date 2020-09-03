using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Messages.Core.UnitTests.Maybe
{
    [TestClass, TestCategory("Maybe")]
    public class CreateEmptyUnityTests : BaseMock
    {
        [TestMethod]
        public void CreateMaybe_ShouldCreateWithoutParameters()
        {
            var response = Maybe<Student>.Create();

            response.HasValue.Should().BeFalse();
            response.Value.Should().BeNull();
        }
    }
}

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Messages.Core.UnitTests.Response
{
    [TestClass, TestCategory(nameof(Core.Response))]
    public class AddMessageUnitTests : BaseMock
    {
        [TestMethod]
        public void SetValue_ShoultAddAMessageToResponse()
        {
            var response = Response<Student>.Create();

            response.AddMessage(MessageFake());

            response.Messages.Should().NotBeNull();
            response.Messages.Should().HaveCount(1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void SetValue_ShoultThowAnAgrumentNullExpection()
        {
            var response = Response<Student>.Create();

            response.AddMessage(null);
        }
    }
}

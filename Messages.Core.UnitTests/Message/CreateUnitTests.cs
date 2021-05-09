using FluentAssertions;
using Messages.Core.Enums;
using Messages.Core.Enums.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Messages.Core.UnitTests.Message
{
    [TestClass, TestCategory(nameof(Core.Message))]
    public class CreateUnitTests : BaseMock
    {
        [TestMethod]
        public void CreateMessage_ShouldCreateWithValidParameters()
        {
            var student = StudentFake(cpf: string.Empty);
            var enumDescription = MessageType.BusinessError.GetDescription();
            var textMessage = $"{nameof(student.Cpf)} is invalid";

            var response = Core.Message.Create(nameof(student.Cpf), textMessage);

            response.Type.Should().Be(MessageType.BusinessError);
            response.TypeDescription.Should().Be(enumDescription);
            response.Text.Should().Be(textMessage);
            response.Property.Should().Be(nameof(student.Cpf));
        }

        [TestMethod]
        public void CreateMessage_ShouldCreateWithValidParametersIncludingType()
        {
            var student = StudentFake(cpf: string.Empty);
            var messageType = MessageType.CriticalError;
            var enumDescription = messageType.GetDescription();
            var textMessage = $"{nameof(student.Cpf)} is invalid";

            var response = Core.Message.Create(nameof(student.Cpf), textMessage, messageType);

            response.Type.Should().Be(MessageType.CriticalError);
            response.TypeDescription.Should().Be(enumDescription);
            response.Text.Should().Be(textMessage);
            response.Property.Should().Be(nameof(student.Cpf));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateMessage_ShouldThrowArgumentException()
        {
            var messageType = MessageType.CriticalError;
            var textMessage = string.Empty;
            Student student;

            _ = Core.Message.Create(nameof(student.Cpf), textMessage, messageType);
        }
    }
}

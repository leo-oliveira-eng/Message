using Bogus;
using Messages.Core.Enums;
using System;
using System.ComponentModel;

namespace Messages.Core.Tests.Shared
{
    public class BaseMock
    {
        public class AnyClass
        {
            public Guid Code { get; set; }

            public string AnyProperty { get; set; } = null!;

            public string AnotherProperty { get; set; } = null!;
        }

        public enum AnyEnum
        {
            [Description("Undefined")]
            None = 0,

            Any = 1
        }

        public AnyClass AnyClassFake(Guid? code = null, string? any = null, string? another = null)
            => new Faker<AnyClass>()
                .RuleFor(x => x.Code, code ?? Guid.NewGuid())
                .RuleFor(x => x.AnyProperty, any ?? "Anything")
                .RuleFor(x => x.AnotherProperty, another ?? "Another thing")
                .Generate();

        public Message MessageFake(string? text = null, string? property = null, MessageType type = default)
            => new Faker<Message>()
                .RuleFor(x => x.Text, text ?? "Any message")
                .RuleFor(x => x.Property, property ?? "Any")
                .RuleFor(x => x.Type, type)
                .Generate();
    }
}

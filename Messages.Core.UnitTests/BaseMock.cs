using FizzWare.NBuilder;
using Messages.Core.Enums;
using System;
using System.ComponentModel;

namespace Messages.Core.UnitTests
{
    public class BaseMock
    {
        public class Student
        {
            public Guid Code { get; set; }

            public string Name { get; set; }

            public string Cpf { get; set; }
        }

        public enum AnyEnum
        {
            [Description("Undefined")]
            None = 0,

            Any = 1
        }

        public Student StudentFake(Guid? code = null, string name = null, string cpf = null)
            => Builder<Student>
                .CreateNew()
                .With(x => x.Code, code ?? Guid.NewGuid())
                .With(x => x.Name, name ?? "Sherlock Holmes")
                .With(x => x.Cpf, cpf ?? "123456789")
                .Build();

        public Core.Message MessageFake(string text = null, string property = null, MessageType type = default)
            => Builder<Core.Message>
                .CreateNew()
                .With(x => x.Text, text ?? "Any message")
                .With(x => x.Property, property ?? "Any")
                .With(x => x.Type, type)
                .Build();
    }
}

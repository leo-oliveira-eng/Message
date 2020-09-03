using Messages.Core.Enums;
using Messages.Core.Enums.Extensions;
using System;

namespace Messages.Core
{
    public class Message
    {
        #region Properties

        public MessageType Type { get; set; }

        public string Property { get; set; }

        public string TypeDescription => Type.GetDescription();

        public string Text { get; set; }

        #endregion

        #region Constructors

        [Obsolete("For class deserialization only", true)]
        Message() { }


        Message(string text, MessageType type = MessageType.BusinessError, string nameOfProperty = null)
        {          
            Text = text;
            Type = type;
            Property = nameOfProperty;
        }

        #endregion

        #region Methods

        public static Message Create(string property, string text, MessageType type = MessageType.BusinessError)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException(nameof(property));

            return new Message(text, type, property);
        }

        #endregion
    }
}

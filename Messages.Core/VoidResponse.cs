using Messages.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Messages.Core
{
    [DataContract]
    public class Response : HttpResponseMessage, IActionResult
    {
        #region Properties

        [DataMember]
        public IReadOnlyCollection<Message> Messages => _messages;

        private List<Message> _messages { get; set; } = new List<Message>();

        [DataMember]
        public bool HasError => _messages.Any(x => x.Type.Equals(MessageType.BusinessError) || x.Type.Equals(MessageType.CriticalError));

        #endregion

        #region Constructors

        internal protected Response() { }

        internal Response(Message message) => AddMessage(message);

        #endregion

        #region Methods

        public static Response Ok() => new Response();

        public static Response Create() => new Response();

        public static Response Ok(Message message) => new Response(message);

        public Response AddMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            _messages.Add(message);

            return this;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            return Task.CompletedTask;
        }

        #endregion
    }
}
using Messages.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages.Core.Extensions
{
    public static class ResponseExtensions
    {
        public static Response WithBusinessError(this Response response, string text)
        {
            var message = Message.Create(null, text, MessageType.BusinessError);

            return response.AddMessage(message);
        }

        public static Response<TValue> WithBusinessError<TValue>(this Response<TValue> response, string text)
        {
            var message = Message.Create(null, text, MessageType.BusinessError);

            return response.AddMessage(message);
        }

        public static Response WithBusinessError(this Response response, string property, string text, MessageType type = MessageType.BusinessError)
        {
            var message = Message.Create(property, text, type);

            return response.AddMessage(message);
        }

        public static Response<TValue> WithBusinessError<TValue>(this Response<TValue> response, string property, string text, MessageType type = MessageType.BusinessError)
        {
            var message = Message.Create(property, text, type);

            return response.AddMessage(message);
        }

        public static Response WithCriticalError(this Response response, string text)
        {
            var message = Message.Create(null, text, MessageType.CriticalError);

            return response.AddMessage(message);
        }

        public static Response<TValue> WithCriticalError<TValue>(this Response<TValue> response, string text)
        {
            var message = Message.Create(null, text, MessageType.CriticalError);

            return response.AddMessage(message);
        }

        public static Response WithMessages(this Response response, IEnumerable<Message> messages)
        {
            foreach (var message in messages)
                response.AddMessage(message);

            return response;
        }

        public static Response<TValue> WithMessages<TValue>(this Response<TValue> response, IEnumerable<Message> messages)
        {
            foreach (var message in messages)
                response.AddMessage(message);

            return response;
        }

        public static void Set<TValue>(this Response<TValue> response, params Func<TValue, Response>[] actions)
        {
            if (response == null || actions == null || actions.Count() == 0)
                return;

            actions.ToList()
                .ForEach(action =>
                {
                    var result = action.Invoke(response.Data.Value);

                    if (result.HasError)
                        response.WithMessages(result.Messages);
                });
        }

        public static Response<bool> TrueIfThereAreNoErrors(this Response<bool> response)
        {
            return response.SetValue(!response.HasError);
        }
    }
}

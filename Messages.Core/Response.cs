﻿using System.Runtime.Serialization;

namespace Messages.Core
{
    [DataContract]
    public class Response<TValue> : Response
    {
        #region Properties

        [DataMember]
        public Maybe<TValue> Data { get; set; } = Maybe<TValue>.Create();

        #endregion

        #region Contructors

        Response() { }

        public Response(Message message) : base(message) { }

        public Response(Message message, TValue value) : base(message) => SetValue(value);

        public Response(TValue value) => SetValue(value);

        #endregion

        #region Methods

        public static new Response<TValue> Create() => new Response<TValue>();

        public static Response<TValue> Create(TValue value) => new Response<TValue>(value);

        public Response<TValue> SetValue(TValue value)
        {
            Data = Maybe<TValue>.Create(value);
            return this;
        }

        public new Response<TValue> AddMessage(Message message)
        {
            base.AddMessage(message);

            return this;
        }

        #endregion

        #region Conversion Operators

        public static implicit operator Response<TValue>(TValue value) => Create(value);

        #endregion
    }
}

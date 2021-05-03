using System.Runtime.Serialization;

namespace Messages.Core
{
    [DataContract]
    public sealed class Maybe<TValue>
    {
        #region Properties

        [DataMember]
        public bool HasValue => Value != null;

        [DataMember]
        public TValue Value { get; set; }

        #endregion

        #region Constructors

        private Maybe() { }

        private Maybe(TValue value) => Value = value;

        #endregion

        #region Methods

        public static Maybe<TValue> Create(TValue value) => new Maybe<TValue>(value);

        public static Maybe<TValue> Create() => new Maybe<TValue>();

        #endregion

        #region Conversion Operators

        public static implicit operator Maybe<TValue>(TValue value) => Create(value);

        #endregion
    }
}

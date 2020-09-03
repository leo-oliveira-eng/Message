using System.ComponentModel;

namespace Messages.Core.Enums
{
    public enum MessageType
    {
        [Description("Undefined")]
        None = 0,

        [Description("Success")]
        Success = 1,

        [Description("Alert")]
        Alert = 2,

        [Description("Information")]
        Information = 3,

        [Description("Business error")]
        BusinessError = 4,

        [Description("Critical error")]
        CriticalError = 5
    }
}

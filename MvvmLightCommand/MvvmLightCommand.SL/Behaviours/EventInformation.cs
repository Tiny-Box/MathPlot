using System;
using System.Windows;

namespace MvvmLightCommand.SL4.TriggerActions
{
    public class EventInformation<TEventArgsType>
    {
        public object Sender { get; set; }
        public TEventArgsType EventArgs { get; set; }
        public object CommandArgument { get; set; }
    }

}

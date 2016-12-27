using System;
using Prism.Events;

namespace Lunula.Core.Events
{
    public class InitialisationErrorEvent : PubSubEvent<Exception>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Infrastructure.Abstractions.Messaging
{
    public interface IMessageDispatcher
    {
        void Dispatch<T>(string queueName, T message);
    }
}

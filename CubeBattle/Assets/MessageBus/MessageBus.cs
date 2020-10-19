using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.MessageBus
{
    public class MessageBus : IPublisher, ISubscriber
    {
        private Dictionary<Type, Action<object>> subscriders = new Dictionary<Type, Action<object>>();

        public void Subscriber<T>(Action<T> subscriber)
        {
            if (!subscriders.ContainsKey(typeof(T)))
            {
                subscriders[typeof(T)] = o => { };
            }

            subscriders[typeof(T)] =
                (Action<object>)Delegate.Combine(subscriders[typeof(T)], (Action<object>)(o => { subscriber((T)o); }));
        }

        public void Publish<T>(T message)
        {
            if (subscriders.ContainsKey(typeof(T)))
            {
                subscriders[typeof(T)].Invoke(message);
            }
        }

        public void UnSudscribe<T>(Action<T> subscriber)
        {
        }

    }
}
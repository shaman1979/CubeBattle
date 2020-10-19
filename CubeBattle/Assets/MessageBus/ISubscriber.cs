using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.MessageBus
{
    public interface ISubscriber
    {
        void Subscriber<T>(Action<T> subscriber);
        void UnSudscribe<T>(Action<T> subscriber);
    }
}
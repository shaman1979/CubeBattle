using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeBattle.MessageBus
{
    public interface IPublisher
    {
            void Publish<T>(T message);
    }
}
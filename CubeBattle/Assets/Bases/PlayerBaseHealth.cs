using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Bases
{
    public class PlayerBaseHealth : BaseHealth, IInitializable
    {
        public void Initialize()
        {
            subscriber.Subscriber<DealingPlayerBaseMessage>(message => DealingDamage(message.Damage));
            OnHealthChanged += health => Debug.Log($"Жизней у Игрока {health}");
        }
    }
}
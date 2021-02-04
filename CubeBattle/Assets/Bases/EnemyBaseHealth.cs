using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Bases
{
    public class EnemyBaseHealth : BaseHealth, IInitializable
    {
        public void Initialize()
        {
            subscriber.Subscriber<DealingEnemyBaseMessage>(message => DealingDamage(message.Damage));
            OnHealthChanged += health => Debug.Log($"Жизней у врага {health}");
        }
    }
}
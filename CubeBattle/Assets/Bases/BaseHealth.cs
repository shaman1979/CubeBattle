using CubeBattle.MessageBus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Bases
{
    public abstract class BaseHealth
    {
        public event Action<int> OnHealthChanged;

        [Inject]
        protected ISubscriber subscriber;

        [Inject]
        protected IPublisher publisher;

        private int health = 100;

        protected void DealingDamage(int damage)
        {
            health -= damage;
            health = Mathf.Clamp(health, 0, 100);
            OnHealthChanged?.Invoke(health);
        }
    }
}
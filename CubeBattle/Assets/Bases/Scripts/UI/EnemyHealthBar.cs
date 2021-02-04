using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Bases.UI
{
    public class EnemyHealthBar : HealthBar
    {
        private void Start()
        {
            subscriber.Subscriber<EnemyBaseHealthChangeMessage>(message => FillAmountChange(message.Health));
        }
    }
}
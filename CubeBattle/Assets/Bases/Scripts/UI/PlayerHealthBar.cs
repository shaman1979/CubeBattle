using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Bases.UI
{
    public class PlayerHealthBar : HealthBar
    {
        private void Start()
        {
            subscriber.Subscriber<PlayerBaseHealthChangeMessage>(message => FillAmountChange(message.Health));
        }
    }
}
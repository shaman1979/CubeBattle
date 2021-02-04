using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class DealingPlayerBaseMessage
    {
        public int Damage;

        public DealingPlayerBaseMessage(int damage)
        {
            Damage = damage;
        }
    }
}
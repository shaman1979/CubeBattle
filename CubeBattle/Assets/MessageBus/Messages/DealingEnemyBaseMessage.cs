using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class DealingEnemyBaseMessage
    {
        public int Damage;

        public DealingEnemyBaseMessage(int damage)
        {
            Damage = damage;
        }
    }
}
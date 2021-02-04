using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class EnemyBaseHealthChangeMessage
    {
        public int Health;

        public EnemyBaseHealthChangeMessage(int health)
        {
            Health = health;
        }
    }
}
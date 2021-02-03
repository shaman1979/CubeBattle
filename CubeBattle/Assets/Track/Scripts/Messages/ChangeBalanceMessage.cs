using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Tracks.Messages
{
    public class ChangeBalanceMessage
    {
        public int WarriorPower;
        public int EnemyPower;

        public ChangeBalanceMessage(int warriorPower, int enemyPower)
        {
            WarriorPower = warriorPower;
            EnemyPower = enemyPower;
        }
    }
}
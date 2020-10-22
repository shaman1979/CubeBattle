using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorPush : IInitializable
    {
        private readonly WarriorSensor warriorSensor;
        private readonly Setting setting;

        private bool isEnemy;

        public void Initialize()
        {
            warriorSensor.DiscoveredEnemy += EnemySpeedDown;
            warriorSensor.DiscoveresWarrior += WarriorSpeedUp;
        }

        public void ChangeWarrior(bool isEnemy) => this.isEnemy = isEnemy;

        private void WarriorSpeedUp(WarriorFacade warrior)
        {
            if(isEnemy)
            {

            }
        }

        private void EnemySpeedDown(WarriorFacade enemy)
        {
            if (isEnemy)
            {

            }
        }

        [System.Serializable]
        public class Setting
        {
            public int Power;
        }
    }
}

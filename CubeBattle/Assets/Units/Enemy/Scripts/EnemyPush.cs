using CubeBattle.Units.Warrior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.Enemy
{
    public class EnemyPush : IUnitPushing
    {
        private readonly Setting setting;

        private float pushBoost;

        private EnemyFacade enemyFacade;

        public EnemyPush(Setting setting)
        {
            this.setting = setting;
        }

        public void ApplicationPushBoost(float value)
        {
            if (value >= 0)
                pushBoost = value;
        }

        public void EnemyPushing(EnemyFacade enemy)
        {
            enemy.ApplicationForse(GetForge());
            enemy.Scaning();
            enemy.ChangeSpeed(GetForge());
        }

        public float GetForge()
        {
            return setting.PushingForse + pushBoost;
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
            warrior.ApplicationForse(-GetForge());
            warrior.ChangeSpeed(-GetForge());
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForse;
        }
    }
}
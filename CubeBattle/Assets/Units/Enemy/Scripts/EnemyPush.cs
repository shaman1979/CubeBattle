using CubeBattle.Units.Warrior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.Enemy
{
    public class EnemyPush : IUnitPushing
    {
        private readonly Setting setting;

        public EnemyPush(Setting setting)
        {
            this.setting = setting;
        }

        public void EnemyPushing(EnemyFacade enemy)
        {
            enemy.ApplicationForse(setting.PushingForse);
        }

        public void WarriorPushing(WarriorFacade warrior)
        {
            warrior.ApplicationForse(-setting.PushingForse);
        }

        [System.Serializable]
        public class Setting
        {
            public float PushingForse;
        }
    }
}
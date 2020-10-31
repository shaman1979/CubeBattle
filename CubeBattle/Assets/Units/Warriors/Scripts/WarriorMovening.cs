using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Warrior
{
    public class WarriorMovening : ITickable, IUnitMovening
    {
        private readonly Transform warrior;
        private readonly Setting setting;

        private float speedBoost = 0;

        public WarriorMovening([Inject(Id = "Unit")] Transform warrior, Setting setting, IUnitSensor warriorSensor)
        {
            this.warrior = warrior;
            this.setting = setting;

            warriorSensor.DiscoveredEnemy += (enemy) => speedBoost = -setting.Speed;
        }

        public void Tick()
        {
            Movening();
        }

        public void ChangeSpeed(float newSpeed)
        {
            speedBoost = newSpeed;
        }

        private void Movening()
        {
            warrior.Translate(0, 0, (setting.Speed + speedBoost) * Time.deltaTime);
        }

        [System.Serializable]
        public class Setting
        {
            public float Speed;
        }
    }
}
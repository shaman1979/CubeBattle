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
        private bool isPlaying = true;

        public WarriorMovening([Inject(Id = "Unit")] Transform warrior, Setting setting)
        {
            this.warrior = warrior;
            this.setting = setting;
        }

        public void Tick()
        {
            if(isPlaying)
                Movening();
        }

        public void ChangeSpeed(float newSpeed)
        {
            speedBoost = newSpeed;
            speedBoost = Mathf.Clamp(speedBoost, newSpeed, 0);
        }
        public void Stop()
        {
            isPlaying = false;
        }

        public void Start()
        {
            isPlaying = true;
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
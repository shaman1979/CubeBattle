﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorMovening : ITickable
    {
        [Inject(Id = "Warrior")]
        private Transform warrior;

        private readonly Setting setting;

        private float speedBoost = 0;

        public WarriorMovening(Setting setting)
        {
            this.setting = setting;
        }

        public void Tick()
        {
            Movening();
        }

        public void InversMovening(bool isInvers)
        {
            setting.Speed = isInvers ? -Mathf.Abs(setting.Speed) : Mathf.Abs(setting.Speed);
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
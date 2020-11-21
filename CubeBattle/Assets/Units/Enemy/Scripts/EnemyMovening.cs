using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Enemy
{
    public class EnemyMovening : ITickable, IUnitMovening
    {
        private readonly Transform enemy;
        private readonly Setting setting;

        private float speedBoost = 0;
        private bool isPlaying = true;

        public EnemyMovening([Inject(Id = "Unit")] Transform enemy, Setting setting)
        {
            this.enemy = enemy;
            this.setting = setting;
        }

        public void Tick()
        {
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
            if(isPlaying)
                enemy.Translate(0, 0, -(setting.Speed + speedBoost) * Time.deltaTime);
        }

        [System.Serializable]
        public class Setting
        {
            public float Speed;
        }
    }
}
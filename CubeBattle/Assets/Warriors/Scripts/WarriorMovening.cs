using System.Collections;
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

        public WarriorMovening(Setting setting)
        {
            this.setting = setting;
            if(setting.IsInversMove)
            {
                setting.Speed *= -1;
            }

        }

        public void Tick()
        {
            Movening();
        }

        private void Movening()
        {
            warrior.Translate(0, 0, setting.Speed * Time.deltaTime);
        }

        [System.Serializable]
        public class Setting
        {
            public float Speed;
            public bool IsInversMove;
        }
    }
}
using System;
using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorBorderChecker : IFixedTickable
    {
        public Action WentToBorder;

        private readonly Transform warrior;
        private readonly Setting setting;

        public WarriorBorderChecker([Inject(Id = "Warrior")]Transform warrior, Setting setting)
        {
            this.warrior = warrior;
            this.setting = setting;
        }

        public void FixedTick()
        {
            if(warrior.position.z > setting.UpBorder || warrior.position.z < setting.DownBorder)
            {
                WentToBorder?.Invoke();
            }
        }

        [System.Serializable]
        public class Setting
        {
            public float UpBorder;
            public float DownBorder;
        }
    }
}
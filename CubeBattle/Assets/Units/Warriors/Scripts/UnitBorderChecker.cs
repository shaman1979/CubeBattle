using System;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public class UnitBorderChecker : IFixedTickable
    {
        public Action WentToBorder;

        private readonly Transform warrior;
        private readonly Setting setting;

        public UnitBorderChecker([Inject(Id = "Unit")]Transform warrior, Setting setting)
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
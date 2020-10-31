using CubeBattle.Cameras.Extension;
using System;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public class UnitBorderChecker : IFixedTickable
    {
        public Action WentToBorder;

        private readonly Transform warrior;

        public UnitBorderChecker([Inject(Id = "Unit")]Transform warrior)
        {
            this.warrior = warrior;
        }

        public void FixedTick()
        {
            if(warrior.position.z > CameraExtensions.GetUpBorder() || warrior.position.z < CameraExtensions.GetDownBorder())
            {
                WentToBorder?.Invoke();
            }
        }
    }
}
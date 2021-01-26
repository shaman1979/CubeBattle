using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Movening
{
    public class UnitMovening : ITickable, IUnitMovening
    {
        private readonly Rigidbody unitRigidbody;
        private readonly Transform unitTransform;
        private readonly Setting setting;
        

        public UnitMovening(
            [Inject(Id = "Unit")] Rigidbody unitRigidbody,
            [Inject(Id = "Unit")] Transform unitTransform,
            Setting setting)
        {
            this.unitRigidbody = unitRigidbody;
            this.unitTransform = unitTransform;
            this.setting = setting;
        }

        public void Tick()
        {
            Movening();
        }

        private void Movening()
        {
            //unitRigidbody.MovePosition(GetNewPosition(setting.Speed * Time.deltaTime));
            unitRigidbody.velocity = GetNewPosition(setting.Speed * Time.deltaTime);
        }

        private Vector3 GetNewPosition(float speed)
        {
            return unitRigidbody.velocity + (setting.Direction * speed);
        }

        [System.Serializable]
        public class Setting
        {
            public float Speed;
            public Vector3 Direction;
        }
    }
}
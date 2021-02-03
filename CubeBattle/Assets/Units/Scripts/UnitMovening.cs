using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Movening
{
    public class UnitMovening : ITickable, IUnitMovening
    {
        private readonly Rigidbody unitRigidbody;
        private readonly Setting setting;

        public float Speed { get => setting.Speed; set => setting.Speed = value; }

        public UnitMovening(
            [Inject(Id = "Unit")] Rigidbody unitRigidbody,
            Setting setting)
        {
            this.unitRigidbody = unitRigidbody;
            this.setting = setting;
        }

        public void Tick()
        {
            Movening();
        }

        private void Movening()
        {
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
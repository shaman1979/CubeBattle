using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public class UnitPower
    {
        private readonly Rigidbody rigidbody;
        private readonly IUnitMovening unitMovening;

        public UnitPower([Inject(Id = "Unit")] Rigidbody unitRigidbody, IUnitMovening unitMovening)
        {
            rigidbody = unitRigidbody;
            this.unitMovening = unitMovening;
        }

        public void SetMass(float mass)
        {
            rigidbody.mass = mass;
        }

        public int GetPower()
        {
            return Mathf.RoundToInt(rigidbody.mass * unitMovening.Speed);
        }
    }
}
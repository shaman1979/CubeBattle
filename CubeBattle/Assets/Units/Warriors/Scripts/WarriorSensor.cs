using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.Warrior
{
    public class WarriorSensor : IFixedTickable, IUnitSensor
    {
        private readonly Transform origin;
        private readonly Setting setting;

        public Action<EnemyFacade> DiscoveredEnemy { get; set; }
        public Action<WarriorFacade> DiscoveresWarrior { get; set; }

        public WarriorSensor([Inject(Id = "Unit")] Transform origin, Setting setting)
        {
            this.origin = origin;
            this.setting = setting;
        }

        public void FixedTick()
        {
            RaycastHit hit;

            if (RayHitChecker(out hit))
            {
                var warrior = hit.transform.GetComponentInParent<UnitFacade>();

                if (warrior)
                {
                    if (warrior is WarriorFacade)
                    {
                        DiscoveresWarrior?.Invoke(warrior as WarriorFacade);
                    }
                    else if(warrior is EnemyFacade)
                    {
                        DiscoveredEnemy?.Invoke(warrior as EnemyFacade);
                    }
                }
            }
        }

        private bool RayHitChecker(out RaycastHit hit)
        {
            var ray = new Ray(origin.position, setting.Direction);

            Debug.DrawRay(ray.origin, ray.direction, Color.white);

            return Physics.Raycast(ray, out hit, setting.Distance);
        }

        [System.Serializable]
        public class Setting
        {
            public float Distance;
            public Vector3 Direction;
        }
    }
}
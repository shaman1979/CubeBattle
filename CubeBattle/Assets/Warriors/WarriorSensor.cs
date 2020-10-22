using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorSensor : IFixedTickable
    {
        private readonly Transform origin;
        private readonly Setting setting;

        private Vector3 direction;

        public Action<WarriorFacade> DiscoveredEnemy;
        public Action<WarriorFacade> DiscoveresWarrior;

        public WarriorSensor([Inject(Id = "Warrior")] Transform origin, Setting setting)
        {
            this.origin = origin;
            this.setting = setting;
        }

        public void FixedTick()
        {
            RaycastHit hit;

            if (RayHitChecker(out hit))
            {
                var warrior = hit.transform.GetComponentInParent<WarriorFacade>();

                if (warrior)
                {
                    if (warrior.IsEnemy())
                    {
                        DiscoveredEnemy?.Invoke(warrior);
                    }
                    else
                    {
                        DiscoveresWarrior?.Invoke(warrior);
                    }
                }
            }
        }

        public void Init(Vector3 direction)
        {
            this.direction = direction;
        }

        private bool RayHitChecker(out RaycastHit hit)
        {
            var ray = new Ray(origin.position, direction);

            Debug.DrawRay(ray.origin, ray.direction, Color.white);

            return Physics.Raycast(ray, out hit, setting.Distance);
        }

        [System.Serializable]
        public class Setting
        {
            public float Distance;
        }
    }
}
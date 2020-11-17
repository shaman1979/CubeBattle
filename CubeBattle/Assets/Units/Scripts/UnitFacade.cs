using CubeBattle.Tracks;
using Sirenix.OdinInspector;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public abstract class UnitFacade : SerializedMonoBehaviour
    {
        [Inject]
        protected IUnitSensor unitSensor;

        [Inject]
        protected UnitBorderChecker borderChecker;

        [Inject]
        protected IUnitMovening movening;

        [Inject]
        protected IUnitView view;

        [Inject]
        protected IUnitPushing pushing;

        protected IMemoryPool pool;

        protected CollisionGroup collisionGroup;

        public CollisionGroup GetCollisionGroup()
        {
            if(collisionGroup == null)
            {
                collisionGroup = new CollisionGroup();
                collisionGroup.AddUnit(this);
            }

            return collisionGroup;
        }

        public void SetCollisionGroup(CollisionGroup collisionGroup)
        {
            this.collisionGroup = collisionGroup;
        }

        public void Scaning()
        {
            unitSensor.Scaning();
            movening.Stop();
        }

        protected void Destroy()
        {
            pool.Despawn(this);
        }

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;

            unitSensor.DiscoveresWarrior += pushing.WarriorPushing;
            unitSensor.DiscoveredEnemy += pushing.EnemyPushing;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Scaning();
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Handles.Label(transform.position, pushing.GetForge().ToString());
            }
        }

        public abstract void ApplicationForse(float forse);
    }
}
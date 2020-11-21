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

        public void Scaning()
        {
            unitSensor.Scaning();
        }

        public void ApplicationForse(float forse)
        {
            pushing.ApplicationPushBoost(forse);
        }

        public void ChangeSpeed(float speed)
        {
            movening.ChangeSpeed(speed);
        }

        protected virtual void ResetSettingOnDefault()
        {
            movening.ChangeSpeed(0);
            pushing.ApplicationPushBoost(0);
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
    }
}
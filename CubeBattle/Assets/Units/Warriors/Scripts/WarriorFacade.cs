using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using UnityEditor.Experimental.GraphView;
using CubeBattle.Units;

namespace CubeBattle.Units.Warrior
{
    public class WarriorFacade : UnitFacade, IPoolable<IMemoryPool>
    {
        [Inject]
        private UnitBorderChecker borderChecker;

        [Inject]
        private IUnitMovening warriorMovening;

        [Inject]
        private IUnitView warriorView;

        [Inject]
        private IUnitSensor warriorSensor;

        private IMemoryPool pool;

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        //public bool IsEnemy() => isEnemy;

        public void OnSpawned(IMemoryPool memoryPool)
        {
            pool = memoryPool;
        }

        private void Destroy()
        {
            pool.Despawn(this);
        }
        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log("colision");
        //}

        //public void ApplicationForse(float forse)
        //{

        //}

        //private void WarriorSetting()
        //{
        //    warriorSensor.Init(Vector3.forward);
        //    //warriorPush.ChangeWarrior(isEnemy);
        //}

        //private void EnemySetting()
        //{
        //    warriorSensor.Init(-Vector3.forward);
        //    //warriorPush.ChangeWarrior(isEnemy);
        //}


    }
}
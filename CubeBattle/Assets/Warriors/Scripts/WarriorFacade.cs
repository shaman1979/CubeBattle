using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorFacade : SerializedMonoBehaviour, IPoolable<bool, IMemoryPool>
    {
        [Inject]
        private WarriorBorderChecker borderChecker;

        [Inject]
        private WarriorMovening warriorMovening;

        [Inject]
        private WarriorView warriorView;

        [Inject]
        private WarriorSensor warriorPush;

        private IMemoryPool pool;

        private bool isEnemy;

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public bool IsEnemy() => isEnemy;

        public void OnSpawned(bool isEnemy, IMemoryPool memoryPool)
        {
            pool = memoryPool;

            this.isEnemy = isEnemy;

            if (isEnemy)
            {
                EnemySetting();
            }
            else
            {
                WarriorSetting();
            }
        }

        private void WarriorSetting()
        {
            warriorMovening.InversMovening(false);
            warriorView.ChangeWarriorColor();
            warriorPush.Init(Vector3.forward);
        }

        private void EnemySetting()
        {
            warriorMovening.InversMovening(true);
            warriorView.ChangeEnemyColor();
            warriorPush.Init(-Vector3.forward);
        }

        private void Destroy()
        {
            pool.Despawn(this);
        }
    }
}
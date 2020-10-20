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

        private IMemoryPool pool;

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(bool isEnemy, IMemoryPool memoryPool)
        {
            pool = memoryPool;

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
        }

        private void EnemySetting()
        {
            warriorMovening.InversMovening(true);
            warriorView.ChangeEnemyColor();
        }

        private void Destroy()
        {
            pool.Despawn(this);
        }
    }
}
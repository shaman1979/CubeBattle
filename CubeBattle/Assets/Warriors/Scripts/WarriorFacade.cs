using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorFacade : SerializedMonoBehaviour, IPoolable<IMemoryPool>
    {
        [Inject]
        private WarriorBorderChecker borderChecker;

        private IMemoryPool pool;

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(IMemoryPool memoryPool)
        {
            pool = memoryPool;
        }

        private void Destroy()
        {
            pool.Despawn(this);
        }
    }
}
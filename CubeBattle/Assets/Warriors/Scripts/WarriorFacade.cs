using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;

namespace CubeBattle.Warrior
{
    public class WarriorFacade : SerializedMonoBehaviour, IPoolable<IMemoryPool>
    {
        private IMemoryPool pool;

        public void OnDespawned()
        {
            pool = null;
        }

        public void OnSpawned(IMemoryPool memoryPool)
        {
            pool = memoryPool;
        }
    }
}
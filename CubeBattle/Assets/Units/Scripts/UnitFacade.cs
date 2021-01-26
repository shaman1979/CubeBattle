using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public abstract class UnitFacade : SerializedMonoBehaviour
    {
        [Inject]
        protected UnitBorderChecker borderChecker;

        [Inject]
        protected IUnitMovening movening;

        [Inject]
        protected IUnitView view;

        protected IMemoryPool pool;

        protected void Destroy()
        {
            pool.Despawn(this);
        }

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }
    }
}
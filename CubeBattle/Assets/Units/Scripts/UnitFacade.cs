using CubeBattle.Tracks;
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

        [Inject]
        private UnitPower unitPower;

        protected IMemoryPool pool;

        protected TrackFacade track;

        protected void Destroy()
        {
            pool.Despawn(this);
            track.RemoveUnit(this);
        }

        public int GetPower()
        {
            return unitPower.GetPower();
        }

        private void Awake()
        {
            borderChecker.WentToBorder += Destroy;
        }
    }
}
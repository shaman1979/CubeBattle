using CubeBattle.MessageBus;
using CubeBattle.Tracks;
using CubeBattle.Units.Datas;
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
        protected IPublisher publisher;

        [Inject]
        protected UnitPower unitPower;

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

        public void Setup(UnitData data)
        {
            movening.SetSpeed(data.Speed);
            view.ChangeModel(data.View);
            unitPower.SetMass(data.Mass);
        }

        private void Awake()
        {
            borderChecker.WentToBorder += OnCollisionBorder;
        }

        protected abstract void OnCollisionBorder(UnitBorderChecker.BorderType borderType);
    }
}
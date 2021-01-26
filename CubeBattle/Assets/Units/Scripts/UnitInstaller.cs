using CubeBattle.Units.Movening;
using CubeBattle.Units.View;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units
{
    public abstract class UnitInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitMovening.Setting moveSetting;

        [SerializeField]
        private new Rigidbody rigidbody;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnitMovening>().AsSingle();
            Container.BindInstance(moveSetting);

            Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();
            Container.BindInterfacesTo<UnitView>().AsSingle();

            Container.BindInstance(gameObject.transform).WithId("Unit");
            Container.BindInstance(rigidbody).WithId("Unit");
        }
    }
}
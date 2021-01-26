using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Movening;
using CubeBattle.Units.Warrior;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.DI
{
    public class WarriorInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitMovening.Setting moveSetting;

        [SerializeField]
        private WarriorSensor.Setting sensorSetting;

        [SerializeField]
        private WarriorPush.Setting pushSetting;

        [SerializeField]
        private new Rigidbody rigidbody;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnitMovening>().AsSingle();
            Container.BindInstance(moveSetting);

            Container.BindInterfacesTo<WarriorView>().AsSingle();

            Container.BindInterfacesTo<WarriorSensor>().AsSingle();
            Container.BindInstance(sensorSetting);

            Container.BindInterfacesTo<WarriorPush>().AsSingle();
            Container.BindInstance(pushSetting);

            Container.BindInstance(gameObject.transform).WithId("Unit");

            Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();

            Container.BindInstance(rigidbody).WithId("Unit");
        }
    }
}
using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.DI
{
    public class WarriorInstaller : MonoInstaller
    {
        [SerializeField]
        private WarriorMovening.Setting moveSetting;

        [SerializeField]
        private WarriorSensor.Setting sensorSetting;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WarriorMovening>().AsSingle();
            Container.BindInstance(moveSetting);

            Container.BindInterfacesTo<WarriorView>().AsSingle();

            Container.BindInterfacesTo<WarriorSensor>().AsSingle();
            Container.BindInstance(sensorSetting);

            Container.BindInstance(gameObject.transform).WithId("Unit");

            Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();
        } 
    }
}
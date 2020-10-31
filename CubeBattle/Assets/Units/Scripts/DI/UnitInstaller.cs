using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using CubeBattle.Units.Warrior;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace CubeBattle.Units.DI
{
    public class UnitInstaller : MonoInstaller
    {
        [SerializeField]
        private UnitBorderChecker.Setting borderSetting;

        #region WarriorSettings
        [SerializeField, BoxGroup("Warrior")]
        private WarriorMovening.Setting moveSetting;

        [SerializeField, BoxGroup("Warrior")]
        private WarriorSensor.Setting sensorSetting;
        #endregion

        #region EnemySettings

        [SerializeField, BoxGroup("Enemy")]
        private EnemyMovening.Setting enemyMoveSetting;

        [SerializeField, BoxGroup("Enemy")]
        private EnemySensor.Setting enemySensorSetting;

        #endregion
        public override void InstallBindings()
        {
            Container.Bind<IUnitMovening>().To<WarriorMovening>().When(binder => binder.ObjectType == typeof(WarriorFacade));
            Container.BindInstance(moveSetting);

            Container.Bind<IUnitMovening>().To<EnemyMovening>().When(binder => binder.ObjectType == typeof(EnemyFacade));
            Container.BindInstance(enemyMoveSetting);

           

            Container.Bind<IUnitView>().To<WarriorView>().When(binder => binder.ObjectType == typeof(WarriorFacade));

            Container.Bind<IUnitView>().To<EnemyView>().When(binder => binder.ObjectType == typeof(EnemyFacade));


            Container.Bind<IUnitSensor>().To<WarriorSensor>().When(binder => binder.ObjectType == typeof(WarriorFacade));
            Container.BindInstance(sensorSetting);

            Container.Bind<IUnitSensor>().To<EnemySensor>().When(binder => binder.ObjectType == typeof(EnemyFacade));
            Container.BindInstance(enemySensorSetting);

            Container.BindInstance(gameObject.transform).WithId("Unit");
            
            Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();
            Container.BindInstance(borderSetting);
        } 
    }
}
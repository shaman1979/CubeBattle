using CubeBattle.Units;
using CubeBattle.Units.Enemy;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField]
    private UnitBorderChecker.Setting borderSetting;

    [SerializeField]
    private EnemyMovening.Setting moveSetting;

    [SerializeField]
    private EnemySensor.Setting sensorSetting;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EnemyMovening>().AsSingle();
        Container.BindInstance(moveSetting);

        Container.BindInterfacesTo<EnemyView>().AsSingle();

        Container.BindInterfacesTo<EnemySensor>().AsSingle();
        Container.BindInstance(sensorSetting);

        Container.BindInstance(gameObject.transform).WithId("Unit");

        Container.BindInterfacesAndSelfTo<UnitBorderChecker>().AsSingle();
        Container.BindInstance(borderSetting);
    }
}
using CubeBattle.Units.Datas;
using CubeBattle.Units.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameDatasInstaller", menuName = "Installers/GameDatasInstaller")]
public class GameDatasInstaller : ScriptableObjectInstaller<GameDatasInstaller>
{
    [SerializeField]
    private string unitDatasPath = "WarriorDatas";

    [SerializeField]
    private string storagesDatasPath = "Storages";

    public override void InstallBindings()
    {
        Container.Bind<IEnumerable<UnitData>>().FromMethod(binder =>
        {
            return new List<UnitData>(Resources.LoadAll<UnitData>(unitDatasPath));
        }).AsCached();

        Container.Bind<ModelViewStorage>().FromNewScriptableObjectResource(storagesDatasPath).AsSingle();
    }
}
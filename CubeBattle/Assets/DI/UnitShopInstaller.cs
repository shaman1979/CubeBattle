using CubeBattle.BuyUnits;
using UnityEngine;
using Zenject;

public class UnitShopInstaller : Installer<UnitShopInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlaceUnitMode>().AsSingle();
        Container.Bind<CursorCollision>().FromComponentInHierarchy().AsCached();
    }
}
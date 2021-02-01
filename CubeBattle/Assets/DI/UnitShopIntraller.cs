using CubeBattle.BuyUnits;
using UnityEngine;
using Zenject;

public class UnitShopIntraller : Installer<UnitShopIntraller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlaceUnitMode>().AsSingle();
        Container.Bind<CursorCollision>().FromComponentInHierarchy().AsCached();
    }
}
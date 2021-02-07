using CubeBattle.BuyUnits;
using CubeBattle.Units.Datas;
using CubeBattle.UnitShop;
using CubeBattle.UnitShop.UI;
using UnityEngine;
using Zenject;

public class UnitShopInstaller : Installer<UnitShopInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlaceUnitMode>().AsSingle();
        Container.Bind<CursorCollision>().FromComponentInHierarchy().AsCached();

        Container.BindInterfacesAndSelfTo<ShopInitialize>().AsSingle();

        Container.BindFactory<UnitBuyButton, UnitData, UnitBuyButton, UnitBuyButton.Factory>()
            .FromFactory<UnitBuyButtonFactory>();
    }
}
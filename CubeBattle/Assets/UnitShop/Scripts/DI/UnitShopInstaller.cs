using CubeBattle.BuyUnits;
using CubeBattle.Units.Datas;
using CubeBattle.UnitShop;
using CubeBattle.UnitShop.UI;
using UnityEngine;
using Zenject;

public class UnitShopInstaller : MonoInstaller<UnitShopInstaller>
{
    [SerializeField]
    private ShopInitialize.Setting shopSetting;

    [SerializeField]
    private Transform parent;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ShopInitialize>().AsSingle();

        Container.BindFactory<UnitBuyButton, UnitData, UnitBuyButton, UnitBuyButton.Factory>()
            .FromFactory<UnitBuyButtonFactory>();

        Container.BindInstance(shopSetting);
        Container.BindInstance(parent);
    }
}
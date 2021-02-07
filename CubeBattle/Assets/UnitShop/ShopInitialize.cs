using CubeBattle.Units.Datas;
using CubeBattle.UnitShop.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.UnitShop
{
    public class ShopInitialize : IInitializable
    {
        private readonly IEnumerable<UnitData> datas;
        private readonly Setting setting;
        private readonly UnitBuyButton.Factory factory;

        public ShopInitialize(IEnumerable<UnitData> datas, UnitBuyButton.Factory factory, Setting setting)
        {
            this.datas = datas;
            this.factory = factory;
            this.setting = setting;
        }

        public void Initialize()
        {
            foreach (var data in datas)
            {
                factory.Create(setting.Prefab, data);
            }
        }

        [System.Serializable]
        public class Setting
        {
            public UnitBuyButton Prefab;
        }
    }
}
using CubeBattle.Units.Datas;
using CubeBattle.UnitShop.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace CubeBattle.UnitShop
{
    public class ShopInitialize : IInitializable
    {
        private readonly IEnumerable<UnitData> datas;
        private readonly Setting setting;
        private readonly UnitBuyButton.Factory factory;
        private readonly Transform parent;

        public ShopInitialize(IEnumerable<UnitData> datas, UnitBuyButton.Factory factory, Setting setting, Transform parent)
        {
            this.datas = datas;
            this.factory = factory;
            this.setting = setting;
            this.parent = parent;
        }

        public void Initialize()
        {
            ButtonsGeneration();
        }

        private List<UnitBuyButton> ButtonsGeneration()
        {
            var buttons = new List<UnitBuyButton>(datas.Count());
            foreach (var data in datas)
            {
                buttons.Add(factory.Create(setting.Prefab, data));
            }

            return buttons;
        }

        private UnitBuyButton ButtonGenerate(UnitData data)
        {
            var button = factory.Create(setting.Prefab, data);

            button.transform.SetParent(parent);
            return button;
        }

        [System.Serializable]
        public class Setting
        {
            public UnitBuyButton Prefab;
        }
    }
}
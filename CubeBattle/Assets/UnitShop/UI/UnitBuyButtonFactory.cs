using CubeBattle.MessageBus;
using CubeBattle.Units.Datas;
using CubeBattle.UnitShop.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.UnitShop
{
    public class UnitBuyButtonFactory : IFactory<UnitBuyButton, UnitData, UnitBuyButton>
    {
        private readonly DiContainer container;
        private readonly IPublisher publisher;

        public UnitBuyButtonFactory(DiContainer container, IPublisher publisher)
        {
            this.container = container;
            this.publisher = publisher;
        }

        public UnitBuyButton Create(UnitBuyButton prefab, UnitData data)
        {
            var button = container.InstantiatePrefabForComponent<UnitBuyButton>(prefab);
            button.Setup(data, publisher);
            return button;
        }
    }
}
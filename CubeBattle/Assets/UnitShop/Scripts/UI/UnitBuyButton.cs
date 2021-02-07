using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CubeBattle.UnitShop.UI
{
    [RequireComponent(typeof(UnitBuyButtonView))]
    public class UnitBuyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField]
        private UnitBuyButtonView view;

        private IPublisher publisher = null;

        private UnitData currentData;

        public void Setup(UnitData data, IPublisher publisher)
        {
            currentData = data;
            this.publisher = publisher;

            view.IconChange(currentData.Icon);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Stop));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Run, currentData));
        }

        public class Factory : PlaceholderFactory<UnitBuyButton, UnitData, UnitBuyButton>
        { }
    }
}
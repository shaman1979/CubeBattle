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
    public class UnitBuyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler , IBeginDragHandler, IEndDragHandler
    {
        [SerializeField]
        private UnitBuyButtonView view;

        [SerializeField]
        private UnitBuyButtonActivator activator;

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
            activator.ButtonRecharge();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Run, currentData));
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Run, currentData));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Stop));
        }

        public class Factory : PlaceholderFactory<UnitBuyButton, UnitData, UnitBuyButton>
        { }
    }
}
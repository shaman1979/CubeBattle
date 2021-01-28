using CubeBattle.MessageBus;
using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace CubeBattle.UnitShop.UI
{
    public class UnitBuyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        [Inject]
        private IPublisher publisher = null;

        public void OnPointerUp(PointerEventData eventData)
        {
            publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Stop));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            publisher.Publish(new PlaceUnitMessage(BuyUnits.PlaceUnitMode.ModeWorker.Run));
        }
    }
}
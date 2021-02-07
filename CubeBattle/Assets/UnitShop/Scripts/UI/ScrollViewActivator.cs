using CubeBattle.MessageBus;
using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CubeBattle.UnitShop.UI
{
    [RequireComponent(typeof(ScrollRect))]
    public class ScrollViewActivator : MonoBehaviour
    {
        [Inject]
        private ISubscriber subscriber;

        private ScrollRect scroll;

        private void Start()
        {
            scroll = GetComponent<ScrollRect>();

            subscriber.Subscriber<PlaceUnitMessage>(message =>
            {
                switch (message.ModeWorker)
                {
                    case BuyUnits.PlaceUnitMode.ModeWorker.Run:
                        ScrollDisable();
                        break;
                    case BuyUnits.PlaceUnitMode.ModeWorker.Stop:
                        ScrollEnable();
                        break;
                    default:
                        break;
                }
            });
        }

        private void ScrollEnable()
        {
            scroll.enabled = true;
        }

        private void ScrollDisable()
        {
            scroll.enabled = false;
        }
    }
}
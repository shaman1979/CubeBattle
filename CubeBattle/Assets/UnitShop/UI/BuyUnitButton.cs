using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubeBattle.UnitShop.UI
{
    public class BuyUnitButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log($"Button up {eventData.position}");
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log($"Button down {eventData.position}");
        }
    }
}
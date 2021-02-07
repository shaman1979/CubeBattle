using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeBattle.UnitShop.UI
{
    public class UnitBuyButtonView : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        public void IconChange(Sprite iconSprite)
        {
            icon.sprite = iconSprite;
        }
    }
}

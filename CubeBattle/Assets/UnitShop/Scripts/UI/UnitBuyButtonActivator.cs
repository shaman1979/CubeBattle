using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubeBattle.UnitShop.UI
{
    [RequireComponent(typeof(Image))]
    public class UnitBuyButtonActivator : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Button button;

        private Coroutine rechargeCoroutine;


        [SerializeField]
        private float cooldownTime = 1;

        public void ButtonRecharge()
        {
            image.fillAmount = 0;
            button.interactable = false;

            if (rechargeCoroutine == null)
            {
                rechargeCoroutine = StartCoroutine(StartCooldown());
            }
        }

        private IEnumerator StartCooldown()
        {
            var fillingValue = 1 / (cooldownTime * 100);

            while (image.fillAmount < 1)
            {
                image.fillAmount += fillingValue;
                yield return null;
            }

            button.interactable = true;
            rechargeCoroutine = null;
        }
    }
}
using CubeBattle.MessageBus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CubeBattle.Bases.UI
{
    public abstract class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image bar;

        [Inject]
        protected ISubscriber subscriber;

        protected void FillAmountChange(int healthValue)
        {
            bar.fillAmount = healthValue / 100f;
        }
    }
}
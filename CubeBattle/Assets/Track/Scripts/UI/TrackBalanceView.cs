using CubeBattle.MessageBus;
using CubeBattle.Tracks.Messages;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace CubeBattle.Tracks
{
    public class TrackBalanceView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI warriorPower;

        [SerializeField]
        private TextMeshProUGUI enemyPower;

        [Inject(Id = "Local")]
        private ISubscriber subscriber;

        private void Start()
        {
            subscriber.Subscriber<ChangeBalanceMessage>(message =>
            {
                WarriorPowerUpdate(message.WarriorPower);
                EnemyPowerUpdate(message.EnemyPower);
            });
        }

        public void WarriorPowerUpdate(int power)
        {
            warriorPower.text = power.ToString();
        }

        public void EnemyPowerUpdate(int power)
        {
            enemyPower.text = power.ToString();
        }
    }
}
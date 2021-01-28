using CubeBattle.MessageBus;
using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.BuyUnits
{
    public class PlaceUnitMode : IInitializable 
    {
        private readonly ISubscriber subscriber;

        public PlaceUnitMode(ISubscriber subscriber)
        {
            this.subscriber = subscriber;
        }

        public void Initialize()
        {
            subscriber.Subscriber<PlaceUnitMessage>(message =>
            {
                switch (message.ModeWorker)
                {
                    case ModeWorker.Run:
                        Run();
                        break;
                    case ModeWorker.Stop:
                        Stop();
                        break;
                    default:
                        break;
                }
            });
        }

        public void Run()
        {
            Debug.Log($"Режим установки юнита запущен.");
        }

        public void Stop()
        {
            Debug.Log($"Режим установки юнита остановлен.");
        }

        public enum ModeWorker
        {
            Run,
            Stop
        }
    }
}
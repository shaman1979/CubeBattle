using CubeBattle.Cameras.Extension;
using CubeBattle.MessageBus;
using CubeBattle.Messages;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.BuyUnits
{
    public class PlaceUnitMode : IInitializable, ITickable
    {
        private readonly ISubscriber subscriber;
        private readonly PlaceUnitModeView view;

        private bool isRunning = false;

        public PlaceUnitMode(ISubscriber subscriber, PlaceUnitModeView view)
        {
            this.subscriber = subscriber;
            this.view = view;
        }

        public void Initialize()
        {
            subscriber.Subscriber<PlaceUnitMessage>(message =>
            {
                switch (message.ModeWorker)
                {
                    case ModeWorker.Run:
                        Run();
                        isRunning = true;
                        break;
                    case ModeWorker.Stop:
                        Stop();
                        isRunning = false;
                        break;
                }
            });
        }

        public void Tick()
        {
            if(isRunning)
            {
                view.PositionChange(CursorPosition());
            }
        }

        private void Run()
        {
            Debug.Log($"Режим установки юнита запущен.");

            view.PreviewShow(null, CursorPosition());
        }

        private void Stop()
        {
            Debug.Log($"Режим установки юнита остановлен.");
        }
        private Vector3 CursorPosition()
        {
            var plane = new Plane(Vector3.up, Vector3.zero);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(plane.Raycast(ray, out var position))
            {
                return ray.GetPoint(position);
            }

            return Vector3.zero;
        }

        public enum ModeWorker
        {
            Run,
            Stop
        }
    }
}
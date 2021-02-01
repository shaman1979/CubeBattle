using CubeBattle.Cameras.Extension;
using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Tracks;
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
        private readonly CursorCollision cursorCollision;

        private bool isRunning = false;

        public PlaceUnitMode(ISubscriber subscriber, PlaceUnitModeView view, CursorCollision cursorCollision)
        {
            this.subscriber = subscriber;
            this.view = view;
            this.cursorCollision = cursorCollision;
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
                }
            });

            
        }

        public void Tick()
        {
            if (isRunning)
            {
                view.PositionChange(CursorPosition());
            }
        }

        private void Run()
        {
            Debug.Log($"Режим установки юнита запущен.");
            isRunning = true;

            view.PreviewShow(null, CursorPosition());

            cursorCollision.OnTrackEnter += TrackSelection;
            cursorCollision.OnTrackExit += TrackRemoveSelection;
        }

        private void Stop()
        {
            isRunning = false;

            cursorCollision.OnTrackEnter -= TrackSelection;
            cursorCollision.OnTrackExit -= TrackRemoveSelection;

            Debug.Log($"Режим установки юнита остановлен.");
        }

        private void TrackSelection(TrackFacade trackFacade)
        {
            trackFacade.Selection();
        }

        private void TrackRemoveSelection(TrackFacade trackFacade)
        {
            trackFacade.RemoveSelection();
        }

        private Vector3 CursorPosition()
        {
            var plane = new Plane(Vector3.up, Vector3.zero);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var position))
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
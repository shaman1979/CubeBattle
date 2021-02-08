using CubeBattle.Cameras.Extension;
using CubeBattle.MessageBus;
using CubeBattle.Messages;
using CubeBattle.Tracks;
using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CubeBattle.BuyUnits
{
    public class PlaceUnitMode : IInitializable, ITickable
    {
        private readonly ISubscriber subscriber;
        private readonly IPublisher publisher;

        private readonly PlaceUnitModeView view;
        private readonly CursorCollision cursorCollision;

        private bool isRunning = false;
        private TrackFacade selectionTrack;

        private UnitData selectionUnitData;

        public PlaceUnitMode(
            ISubscriber subscriber,
            IPublisher publisher,
            PlaceUnitModeView view,
            CursorCollision cursorCollision)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
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
                        selectionUnitData = message.PlaceUnitData;
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

            view.PreviewHide();

            if (selectionTrack == null)
            {
                Debug.Log($"Режим установки юнита остановлен.");
                return;
            }

            if (selectionTrack.HasWarriorPlace())
            {
                publisher.Publish(new WarriorPlaceOnTrackMessage(selectionTrack, selectionUnitData));
            }

            TrackRemoveSelection(selectionTrack);

            Debug.Log($"Режим установки юнита завершен.");
        }

        private void TrackSelection(TrackFacade trackFacade)
        {
            trackFacade.Selection();
            selectionTrack = trackFacade;
        }

        private void TrackRemoveSelection(TrackFacade trackFacade)
        {
            trackFacade.RemoveSelection();
            selectionTrack = null;
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
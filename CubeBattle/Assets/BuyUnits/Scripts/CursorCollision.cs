using CubeBattle.Tracks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.BuyUnits
{
    public class CursorCollision : MonoBehaviour
    {
        public event Action<TrackFacade> OnTrackEnter;
        public event Action<TrackFacade> OnTrackExit;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<TrackFacade>(out var track))
            {
                OnTrackEnter?.Invoke(track);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<TrackFacade>(out var track))
            {
                OnTrackExit?.Invoke(track);
            }
        }
    }
}
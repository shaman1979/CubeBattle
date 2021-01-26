using CubeBattle.Tracks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class EnemyPlaceOnTrackMessage
    {
        public EnemyPlaceOnTrackMessage(TrackFacade trackFacade)
        {
            TrackFacade = trackFacade;
        }

        public TrackFacade TrackFacade { get; private set; }
    }
}
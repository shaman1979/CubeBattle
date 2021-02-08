using CubeBattle.Tracks;
using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class EnemyPlaceOnTrackMessage
    {
        public EnemyPlaceOnTrackMessage(TrackFacade trackFacade, UnitData data)
        {
            TrackFacade = trackFacade;
            Data = data;
        }

        public UnitData Data { get; private set; }

        public TrackFacade TrackFacade { get; private set; }
    }
}
using CubeBattle.Tracks;
using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class WarriorPlaceOnTrackMessage
    {
        public WarriorPlaceOnTrackMessage(TrackFacade trackFacade, UnitData data)
        {
            TrackFacade = trackFacade;
            Data = data;
        }

        public TrackFacade TrackFacade { get; private set; }

        public UnitData Data { get; private set; }
    }
}
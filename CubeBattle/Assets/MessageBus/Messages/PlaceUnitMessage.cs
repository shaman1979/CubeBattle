using CubeBattle.BuyUnits;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class PlaceUnitMessage
    {
        public PlaceUnitMode.ModeWorker ModeWorker { get; }

        public PlaceUnitMessage(PlaceUnitMode.ModeWorker modeWorker)
        {
            ModeWorker = modeWorker;
        }
    }
}
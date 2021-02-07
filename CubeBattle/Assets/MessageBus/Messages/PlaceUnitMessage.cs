using CubeBattle.BuyUnits;
using CubeBattle.Units.Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Messages
{
    public class PlaceUnitMessage
    {
        public PlaceUnitMode.ModeWorker ModeWorker { get; }

        public UnitData PlaceUnitData { get; }

        public PlaceUnitMessage(PlaceUnitMode.ModeWorker modeWorker)
        {
            ModeWorker = modeWorker;
        }

        public PlaceUnitMessage(PlaceUnitMode.ModeWorker modeWorker, UnitData placeUnitData) : this(modeWorker)
        {
            PlaceUnitData = placeUnitData;
        }
    }
}
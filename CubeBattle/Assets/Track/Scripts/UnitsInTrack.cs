using CubeBattle.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class UnitsInTrack
    {
        public event Action<UnitFacade> OnUnitAdding;
        public event Action<UnitFacade> OnUnitRemoved;

        private List<UnitFacade> units;

        public UnitsInTrack()
        {
            units = new List<UnitFacade>();
        }

        public void AddUnit(UnitFacade unit)
        {
            units.Add(unit);
            OnUnitAdding?.Invoke(unit);
        }

        public void RemoveUnit(UnitFacade unit)
        {
            units.Remove(unit);
            OnUnitRemoved?.Invoke(unit);
        }

        public IEnumerable<float> GetUnitTravelledPosition()
        {
            return units.Select(x => x.transform.position.z);
        }

        public void Clear()
        {
            units.Clear();
        }
    }
}
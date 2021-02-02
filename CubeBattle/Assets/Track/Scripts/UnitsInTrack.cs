using CubeBattle.Units;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CubeBattle.Tracks
{
    public class UnitsInTrack
    {
        private List<UnitFacade> units;

        public UnitsInTrack()
        {
            units = new List<UnitFacade>();
        }

        public void AddUnit(UnitFacade unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(UnitFacade unit)
        {
            units.Remove(unit);
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
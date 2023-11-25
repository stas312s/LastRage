using System.Collections.Generic;
using UnityEngine;

namespace StopZoneTriggers
{
    public class StopZoneService: IStopZoneService
    {
        public IReadOnlyList<Transform> StopPoints => _stopPoints;

        private List<Transform> _stopPoints;
        public void Initialize(List<Transform> stopPoints)
        {
            _stopPoints = stopPoints;
        }
    }
}
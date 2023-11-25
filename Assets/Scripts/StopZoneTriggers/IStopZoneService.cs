using System.Collections.Generic;
using UnityEngine;

namespace StopZoneTriggers
{
    public interface IStopZoneService
    {
        public IReadOnlyList<Transform> StopPoints { get; }

        public void Initialize(List<Transform> stopPoints);

        public void GetNearPoint(Vector2 point);
    }
}
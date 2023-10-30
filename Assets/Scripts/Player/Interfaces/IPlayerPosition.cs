using UnityEngine;

namespace Player.Interfaces
{
    public interface IPlayerPosition
    {
        public Transform Transform { get; }
        public Vector2 Position { get; }
    }
}
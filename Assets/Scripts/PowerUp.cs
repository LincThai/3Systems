using System;
using UnityEngine;

namespace ThreeSystems.PowerUp
{
    [CreateAssetMenu(fileName = "New PowerUp", menuName = "PowerUp", order = 0)]
    public class PowerUp : ScriptableObject
    {
        // Set Variables
        // These are for my duration and the amount to increase
        public float increaseAmount = 2f;
        public float duration = 60f;

        // This is to choose the effects
        public Effects effects;

        [Flags]
        public enum Effects
        {
            None = 0,
            MoveSpeed = 1,
            JumpHeight = 2
        }
    }
}

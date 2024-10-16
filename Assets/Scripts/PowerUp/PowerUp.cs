using System;
using UnityEngine;

namespace ThreeSystems.PowerUp
{
    [CreateAssetMenu(fileName = "New PowerUp", menuName = "PowerUp", order = 0)]
    public class PowerUp : ScriptableObject
    {
        // Set Variables
        // These are for my duration and the amount to increase
        [SerializeField] public float increaseAmount = 2f;
        [SerializeField] public float duration = 60f;

        // This is to choose the effects
        [SerializeField] private Effects activeEffect;
        public Effects ActiveEffect => activeEffect;

        [Flags]
        public enum Effects
        {
            None = 0,
            MoveSpeed = 1,
            JumpHeight = 2
        }
    }
}

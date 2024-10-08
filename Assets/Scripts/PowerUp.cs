using System;
using UnityEngine;

public class PowerUp : ScriptableObject
{
    public float increaseAmount = 2f;

    public Effects effects;

    [Flags]
    public enum Effects
    {
        None = 0,
        MoveSpeed = 1,
        JumpHeight = 2
    }
}

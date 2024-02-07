using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [field: SerializeField, Range(0, 10)] public float MaxHeight {  get; private set; }
    [field: SerializeField, Range(0, 10)] public float TimeToReachMaxHeight { get; private set; }

    public float StartYVelocity => 2 * MaxHeight / TimeToReachMaxHeight;
}
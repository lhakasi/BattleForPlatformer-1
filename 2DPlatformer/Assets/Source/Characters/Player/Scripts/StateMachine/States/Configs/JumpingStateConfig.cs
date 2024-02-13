using System;
using UnityEngine;

[Serializable]
public class JumpingStateConfig
{
    [field: SerializeField, Range(0, 10)] public float MaxHeight {  get; private set; }
    [field: SerializeField, Range(0, 10)] public float TimeToReachMaxHeight { get; private set; }

    private int _multuplier = 2;

    public float StartYVelocity => _multuplier * MaxHeight / TimeToReachMaxHeight;
}
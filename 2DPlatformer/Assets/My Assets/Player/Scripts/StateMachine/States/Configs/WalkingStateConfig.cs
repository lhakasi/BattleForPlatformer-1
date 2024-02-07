using System;
using UnityEngine;

[Serializable]
public class WalkingStateConfig
{
    [field: SerializeField, Range(0, 10)] public float Speed {  get; private set; }
}
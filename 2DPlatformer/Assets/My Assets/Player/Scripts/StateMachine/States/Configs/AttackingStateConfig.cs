using System;
using UnityEngine;

[Serializable]
public class AttackingStateConfig
{
    [field: SerializeField, Range(0, 100)] public int Damage { get; private set; }
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
}

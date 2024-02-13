using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementStrategyFactory
{    
    private Transform _target;
    private List<Vector3> _patrolPoints;
    private float _huntSpeedMultiplier;

    public MovementStrategyFactory(Transform target, float huntSpeedMultiplier, List<Transform> patrolPoints)
    {
        _target = target;
        _huntSpeedMultiplier = huntSpeedMultiplier;
        _patrolPoints = patrolPoints.Select(point => point.position).ToList();
    }

    public IMover Get(MoverTypes moverType, IMovable movable)
    {        
        switch (moverType)
        {
            case MoverTypes.PointByPoint:
                return new PointByPointMover(movable, _patrolPoints);

            case MoverTypes.TargetFollower:
                return new MoveToTargetPattern(movable, _huntSpeedMultiplier, _target);

            default:
                throw new ArgumentException(nameof(moverType));
        }
    }
}
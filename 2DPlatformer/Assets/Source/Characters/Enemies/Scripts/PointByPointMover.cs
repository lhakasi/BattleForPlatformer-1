using System.Collections.Generic;
using UnityEngine;
public class PointByPointMover : IMover
{
    private const float MinDistanceToTarget = 0.01f;

    private IMovable _movable;
    private Queue<Vector3> _targets;

    private Vector3 _currentTarget;

    private bool _isMoving;

    public PointByPointMover(IMovable movable, IEnumerable<Vector3> targets)
    {
        _movable = movable;
        _targets = new Queue<Vector3>(targets);
        _currentTarget = _targets.Dequeue();
    }

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Move(float deltaTime)
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _currentTarget - _movable.Transform.position;
        _movable.Transform.Translate(direction.normalized * _movable.Speed * deltaTime);

        if (direction.magnitude <= MinDistanceToTarget)
            SwitchTarget();
    }

    private void SwitchTarget()
    {
        _targets.Enqueue(_currentTarget);

        _currentTarget = _targets.Dequeue();
    }
}
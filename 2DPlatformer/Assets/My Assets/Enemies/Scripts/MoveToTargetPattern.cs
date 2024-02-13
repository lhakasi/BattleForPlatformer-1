using UnityEngine;

public class MoveToTargetPattern : IMover
{
    private IMovable _movable;
    private Transform _target;
    private float _huntSpeedMultiplier;

    private bool _isMoving;       

    public MoveToTargetPattern(IMovable movable, float huntSpeedMultiplier, Transform target)
    {
        _movable = movable;
        _huntSpeedMultiplier = huntSpeedMultiplier;
        _target = target;
    }       

    public void StartMove() => _isMoving = true;

    public void StopMove() => _isMoving = false;

    public void Update(float deltaTime)
    {
        if (_isMoving == false)
            return;

        Vector3 direction = _target.position - _movable.Transform.position;
        float xDirection = direction.normalized.x;
        Vector3 movement = new Vector3(xDirection, 0f, 0f) * (_movable.Speed*_huntSpeedMultiplier) * deltaTime;
        _movable.Transform.Translate(movement);
    }
}
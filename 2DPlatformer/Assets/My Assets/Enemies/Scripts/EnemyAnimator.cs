using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyWaypointMovement))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Walk = nameof(Walk);

    private Animator _animator;
    private EnemyWaypointMovement _waypointMovement;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _waypointMovement = GetComponent<EnemyWaypointMovement>();

        _animator.SetBool(Walk, true);
    }

    private void OnEnable() =>
        _waypointMovement.MoveStateChanged += OnMoveStateChanged;

    private void OnDisable() =>
        _waypointMovement.MoveStateChanged -= OnMoveStateChanged;

    private void OnMoveStateChanged(EnemyWaypointMovement.MoveStates states)
    {
        if (states == EnemyWaypointMovement.MoveStates.Walk)
            _animator.SetBool(Walk, true);
        else
            _animator.SetBool(Walk, false);
    }
}
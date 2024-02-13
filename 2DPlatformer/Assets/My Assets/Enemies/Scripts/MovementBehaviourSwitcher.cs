using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviourSwitcher : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private BoxCollider2D _dangerZone;
    [SerializeField, Range(0,5)] private float _huntSpeedMultiplier;

    private MovementStrategyFactory _factory;
    private MoverTypes _currentState;

    private bool _isPlayerNearby;

    private void Awake()
    {
        _factory = new MovementStrategyFactory(_target, _huntSpeedMultiplier, _patrolPoints);

        SetMover(MoverTypes.PointByPoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _isPlayerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            _isPlayerNearby = false;
    }

    private void Update()
    {  
        if (_isPlayerNearby)
        {
            SetMover(MoverTypes.TargetFollower);
        }
        else
        {
            if (_currentState != MoverTypes.PointByPoint)
                SetMover(MoverTypes.PointByPoint);            
        }
    }

    private void SetMover(MoverTypes moverType)
    {
        _enemy.SetMover(_factory.Get(moverType, _enemy));
        _currentState = moverType;
    }
}
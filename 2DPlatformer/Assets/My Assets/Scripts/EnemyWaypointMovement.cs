using System;
using UnityEngine;

public class EnemyWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    
    private Transform _target;

    private float _waitingTime;
    private int _currentPoint;

    public MoveStates MoveState { get; private set; }

    public event Action<MoveStates> MoveStateChanged;

    private void Awake()
    {   
        MoveState = MoveStates.Idle;
        _waitingTime = _delay;
    }

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
            _points[i] = _path.GetChild(i);

        _target = _points[_currentPoint];
    }

    private void Update()
    {
        if (transform.position == _target.position)
        {
            Idle();

            if (_waitingTime <= 0)
            {
                _waitingTime = _delay;
                _currentPoint++;

                if (_currentPoint >= _points.Length)
                    _currentPoint = 0;

                _target = _points[_currentPoint];
            }
            else
            {
                _waitingTime -= Time.deltaTime;
            }
        }
        else
        {
            Move(_target);
        }
    }

    private void Idle()
    {
        if (MoveState != MoveStates.Idle)
        {
            MoveState = MoveStates.Idle;
            MoveStateChanged?.Invoke(MoveState);
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards
            (transform.position, target.position, _speed * Time.deltaTime);

        if (MoveState != MoveStates.Walk)
        {
            MoveState = MoveStates.Walk;
            MoveStateChanged?.Invoke(MoveState);
        }

        ChangeDirection(target);
    }

    private void ChangeDirection(Transform target)
    {
        int left = 180;
        int right = 0;

        if (target.position.x < transform.position.x)
            Rotate(left);
        else if (target.position.x > transform.position.x)
            Rotate(right);
    }

    private void Rotate(int direction)
    {
        Vector3 rotate = transform.eulerAngles;
        rotate.y = direction;
        transform.rotation = Quaternion.Euler(rotate);
    }

    public enum MoveStates
    {
        Idle = 0,
        Walk = 1
    }
}
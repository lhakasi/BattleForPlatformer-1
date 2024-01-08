using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private GroundChecker _groundChecker;

    private bool _isJumping;

    public float HorizontalInput { get; private set; }
    public MoveStates MoveState { get; private set; }

    public event Action<MoveStates> MoveStateChanged;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        MoveState = MoveStates.Idle;
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        if (_groundChecker.IsGrounded == true)
        {
            _isJumping = false;

            Idle();

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }        

        if (HorizontalInput != 0)
            Move();
    }

    private void Idle()
    {
        if (MoveState != MoveStates.Idle)
        {
            MoveState = MoveStates.Idle;
            MoveStateChanged?.Invoke(MoveState);
        }
    }

    private void Move()
    {
        if (MoveState != MoveStates.Walk)
        {
            _rigidbody2D.velocity = new Vector2(HorizontalInput * _speed, _rigidbody2D.velocity.y);

            if (_isJumping == false)
            {
                MoveState = MoveStates.Walk;
                MoveStateChanged?.Invoke(MoveState);
            }
        }
    }

    private void Jump()
    {
        if (MoveState != MoveStates.Jump)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);

            MoveState = MoveStates.Jump;
            MoveStateChanged?.Invoke(MoveState);

            _isJumping = true;
        }
    }

    public enum MoveStates
    {
        Idle = 0,
        Walk = 1,
        Jump = 2
    }
}
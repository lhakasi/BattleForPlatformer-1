using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimator : MonoBehaviour
{    
    private const string Walk = nameof(Walk);
    private const string Jump = nameof(Jump);

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();        
    }
    private void OnEnable() =>
        _playerMovement.MoveStateChanged += OnMoveStateChanged;

    private void OnDisable() =>
        _playerMovement.MoveStateChanged -= OnMoveStateChanged;

    private void OnMoveStateChanged(PlayerMovement.MoveStates states)
    {
        if (states == PlayerMovement.MoveStates.Walk)
        {
            _animator.SetBool(Walk, true);
            Flip();
        }
        else
        {
            _animator.SetBool(Walk, false);
        }

        if (states == PlayerMovement.MoveStates.Jump)
            _animator.SetBool(Jump, true);
        else
            _animator.SetBool(Jump, false);
    }

    private void Flip()
    {
        if (_playerMovement.HorizontalInput >= 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;
    }
}
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Walk = nameof(Walk);

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _previousPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _animator.Play(Walk);
    }

    private void Start()
    {
        _previousPosition = transform.position;
    }

    private void Update()
    {
        FlipModel();
    }

    private void FlipModel()
    {
        Vector3 movement = transform.position - _previousPosition;

        if (movement != Vector3.zero)
        {
            if (transform.position.x > _previousPosition.x)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }

        _previousPosition = transform.position;
    }
}
using UnityEngine;

public class GroundChecker : MonoBehaviour
{    
    [SerializeField] private LayerMask _ground;
    private Collider2D _collider;

    public bool IsGrounded { get; private set; }

    private void Awake() =>
        _collider = GetComponent<Collider2D>();

    private void FixedUpdate() =>
        IsGrounded = _collider.IsTouchingLayers(_ground);
}
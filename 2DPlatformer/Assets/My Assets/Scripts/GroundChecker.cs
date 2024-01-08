using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    private Collider2D _collider;

    private bool _isGrounded;

    public bool IsGrounded =>
        _isGrounded;

    private void Awake() =>
        _collider = GetComponent<Collider2D>();

    private void Update() =>    
        _isGrounded = _collider.IsTouchingLayers(LayerMask.GetMask(Ground));    
}
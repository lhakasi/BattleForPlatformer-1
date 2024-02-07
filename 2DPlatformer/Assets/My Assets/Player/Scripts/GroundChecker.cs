using UnityEngine;

public class GroundChecker : MonoBehaviour
{    
    [SerializeField] private CharacterController _controller;

    public bool IsGrounded { get; private set; }

    private void FixedUpdate() =>
        IsGrounded = _controller.isGrounded;
}
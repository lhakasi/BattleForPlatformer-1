using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerView View { get; private set; }
    [field: SerializeField] public GroundChecker GroundChecker {  get; private set; }
    [field: SerializeField] public PlayerConfig Config { get; private set; }

    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;
    private CharacterController _characterController;

    public PlayerInput Input => _input;
    public CharacterController Controller => _characterController;

    private void Awake()
    {       
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
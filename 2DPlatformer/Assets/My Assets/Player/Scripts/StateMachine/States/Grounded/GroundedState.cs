using UnityEngine.InputSystem;

public class GroundedState : MovementState
{
    private GroundChecker _groundChecker;

    public GroundedState(IPlayerStateSwitcher stateSwitcher, PlayerStateMachineData data, Player player)
        : base(stateSwitcher, data, player) => _groundChecker = player.GroundChecker;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsGrounded == false)
            StateSwitcher.SwitchState<FallingState>();
    }

    protected override void AddInputActionsCallbacks()
    {
        base.AddInputActionsCallbacks();

        Input.Movement.Jump.performed += OnJumpKeyPressed;
        Input.Movement.Attack.performed += OnAttackKeyPressed;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Jump.performed -= OnJumpKeyPressed;
        Input.Movement.Attack.performed -= OnAttackKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
    private void OnAttackKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<AttackingState>();
}
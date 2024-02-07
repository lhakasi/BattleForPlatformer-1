using UnityEngine.InputSystem;
using AnimationStates;

public class GroundedState : MovementState
{
    private GroundChecker _groundChecker;

    public GroundedState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _groundChecker = player.GroundChecker;

    public override void Enter()
    {
        base.Enter();

        //View.StartAnimation(States.Grounded);
    }

    public override void Exit()
    {
        base.Exit();

        //View.StopAnimation(States.Grounded);
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
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Jump.performed -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<JumpingState>();
}
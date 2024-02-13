using AnimationStates;

public class IdlingState : GroundedState
{
    public IdlingState(IPlayerStateSwitcher stateSwitcher, PlayerStateMachineData data, Player player) 
        : base(stateSwitcher, data, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartAnimation(States.Idle);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitchState<WalkingState>();
    }
}
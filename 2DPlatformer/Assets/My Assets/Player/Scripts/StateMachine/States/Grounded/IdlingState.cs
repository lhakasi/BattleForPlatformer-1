using AnimationStates;

public class IdlingState : GroundedState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //View.StartAnimation(States.Idle);
    }

    public override void Exit()
    {
        base.Exit();

        //View.StopAnimation(States.Idle);
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        StateSwitcher.SwitchState<WalkingState>();
    }
}
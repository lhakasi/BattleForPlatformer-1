using AnimationStates;
public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();

        //View.StartAnimation(States.Walk);
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        //View.StopAnimation(States.Walk);
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
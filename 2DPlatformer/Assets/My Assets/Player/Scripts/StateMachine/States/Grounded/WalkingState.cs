using AnimationStates;
public class WalkingState : GroundedState
{
    private readonly WalkingStateConfig _config;

    public WalkingState(IPlayerStateSwitcher stateSwitcher, PlayerStateMachineData data, Player player) 
        : base(stateSwitcher, data, player) => _config = player.Config.WalkingStateConfig;

    public override void Enter()
    {
        base.Enter();        

        View.StartAnimation(States.Walk);

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
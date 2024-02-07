using AnimationStates;
public class JumpingState : AirborneState
{
    private readonly JumpingStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.AirborneStateConfig.JumpingStateConfig;

    public override void Enter()
    {
        base.Enter();

        //View.StartAnimation(States.Jump);

        Data.YVelocity = _config.StartYVelocity;
    }

    public override void Exit()
    {
        base.Exit();

        //View.StopAnimation(States.Jump);
    }

    public override void Update()
    {
        base.Update();

        if (Data.YVelocity <= 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}
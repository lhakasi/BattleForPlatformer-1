using UnityEngine;
using AnimationStates;

public class AirborneState : MovementState
{
    private readonly AirborneStateConfig _config;

    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Player player) : base(stateSwitcher, data, player)
        => _config = player.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        //View.StartAnimation(States.Airborne);
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();

        //View.StopAnimation(States.Airborne);
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= GetGravityMultipliyer() * Time.deltaTime;
    }

    protected virtual float GetGravityMultipliyer() => _config.BaseGravity;
}
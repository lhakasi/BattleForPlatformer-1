using UnityEngine;

public class AirborneState : MovementState
{
    private readonly AirborneStateConfig _config;

    public AirborneState(IPlayerStateSwitcher stateSwitcher, PlayerStateMachineData data, Player player)
        : base(stateSwitcher, data, player) => _config = player.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Data.YVelocity -= GetGravityMultipliyer() * Time.deltaTime;
    }

    protected virtual float GetGravityMultipliyer() => _config.BaseGravity;
}
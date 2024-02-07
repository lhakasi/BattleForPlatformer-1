using UnityEngine;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Player _player;

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Player player)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _player = player;
    }

    protected PlayerInput Input => _player.Input;
    protected CharacterController CharacterController => _player.Controller;
    protected PlayerView View => _player.View;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        Debug.Log(GetType());

        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallback();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Vector3 velocity = GetConvertedVecloity();

        CharacterController.Move(velocity * Time.deltaTime);
        _player.transform.rotation = GetRotationFrom(velocity);
    }

    protected virtual void AddInputActionsCallbacks() { }

    protected virtual void RemoveInputActionsCallback() { }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return _player.transform.rotation;
    }

    private Vector3 GetConvertedVecloity() => new Vector3(Data.XVelocity, Data.YVelocity, 0);
    private float ReadHorizontalInput() => Input.Movement.Move.ReadValue<float>();
}
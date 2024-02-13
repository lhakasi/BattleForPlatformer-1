using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine : IPlayerStateSwitcher
{
    private List<IPlayerState> _states;
    private IPlayerState _currentState;

    public PlayerStateMachine(Player player)
    {
        PlayerStateMachineData data = new PlayerStateMachineData();

        _states = new List<IPlayerState>()
        {
            new IdlingState(this, data, player),
            new WalkingState(this, data, player),
            new JumpingState(this, data, player),
            new FallingState(this, data, player),
            new AttackingState(this, data, player)
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IPlayerState
    {
        IPlayerState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
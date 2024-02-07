using System.Collections.Generic;
using System.Linq;

public class PlayerStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public PlayerStateMachine(Player player)
    {
        StateMachineData data = new StateMachineData();

        _states = new List<IState>()
        {
            new IdlingState(this, data, player),
            new WalkingState(this, data, player),
            new JumpingState(this, data, player),
            new FallingState(this, data, player),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();

    public void Update() => _currentState.Update();
}
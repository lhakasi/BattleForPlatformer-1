public interface IPlayerStateSwitcher
{
    void SwitchState<State>() where State : IPlayerState;
}

public interface IMover
{
    void StartMove();
    void StopMove();
    void Move(float deltaTime);
}
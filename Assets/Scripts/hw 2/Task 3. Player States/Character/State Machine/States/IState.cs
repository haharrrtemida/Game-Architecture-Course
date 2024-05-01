namespace hw2
{  
    public interface IState
    {
        void Enter();
        void Exit();
        void HandleInput();
        void Update();
    }
}
namespace hw2
{  
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}
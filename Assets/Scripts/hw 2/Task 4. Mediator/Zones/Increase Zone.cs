namespace hw2.task4.Mediator
{
    public class IncreaseZone : ChangeStatZone
    {
        protected override void MakeChanges(Stat stat)
        {
            stat.Increase(ChangeValue);
        }
    }
}
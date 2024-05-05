namespace hw2.task4.Mediator
{
    public class DecreaseZone : ChangeStatZone
    {
        protected override void MakeChanges(Stat stat)
        {
            stat.Decrease(ChangeValue);
        }
    }
}
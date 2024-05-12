namespace hw3.task4
{
    public interface IEnemyVisitor
    {
        void Visit(Elf elf);
        void Visit(Human human);
        void Visit(Orc orc);
    }    
}
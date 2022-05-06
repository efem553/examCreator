namespace examCreator.Models.Repository.Interface
{
    public interface IExamRepository:IRepository<Exam>
    {
        void Add(Exam exam);

        void Remove(Exam exam);

        void Save();
    }
}

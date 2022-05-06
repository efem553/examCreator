namespace examCreator.Models.Repository.Interface
{
    public interface IQuestionRepository:IRepository<Question>
    {
        void Add(Question question);

        void Remove(Question question);

        void Save();

        void AddRange(IEnumerable<Question> questions);
    }
}

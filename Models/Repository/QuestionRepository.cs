using examCreator.Models.Data;
using examCreator.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace examCreator.Models.Repository
{
    public class QuestionRepository:Repository<Question>,IQuestionRepository
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<Question> dbSet;

        public QuestionRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
            dbSet = _db.Set<Question>();
        }

        public void AddRange(IEnumerable<Question> questions)
        {
            _db.Question.AddRange(questions);
        }
    }
}

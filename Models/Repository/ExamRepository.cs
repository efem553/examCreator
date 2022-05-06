using examCreator.Models.Data;
using examCreator.Models.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace examCreator.Models.Repository
{
    public class ExamRepository:Repository<Exam>,IExamRepository
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<Exam> dbSet;

        public ExamRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
            dbSet = _db.Set<Exam>();
        }

        public void Add(Exam exam)
        {
            dbSet.Add(exam);
        }

        public void Remove(Exam exam)
        {
            dbSet.Remove(exam);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

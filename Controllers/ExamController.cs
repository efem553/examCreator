using examCreator.Models;
using examCreator.Models.Repository.Interface;
using examCreator.Models.ViewModels;
using examCreator.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace examCreator.Controllers
{
    public class ExamController : Controller
    {
        private NewsFetcher _newsFetcher;
        private IExamRepository _examRepo;
        private IQuestionRepository _questionRepo;
        public ExamController(NewsFetcher newsFetcher, IExamRepository examRepo, IQuestionRepository questionRepo)
        {
            _newsFetcher= newsFetcher;
            _examRepo=examRepo;
            _questionRepo=questionRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            return View(_examRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                ExamVM examVM = new ExamVM();
                examVM.Exam = _examRepo.Find(Id);
                List<Question> questions= _questionRepo.GetAll(x => x.ExamId == Id).ToList();
                examVM.Q1 = questions[0];
                examVM.Q2 = questions[1];
                examVM.Q3 = questions[2];
                examVM.Q4 = questions[3];
            return View("Exam",examVM);
            }
            else
                return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateExamVM createExamVM = new CreateExamVM();
            createExamVM.NewsContentList = _newsFetcher.GetLastFive();

            return View(createExamVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateExamVM createExamVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    createExamVM.Exam.CreatedDate = DateTime.Now;
                    _examRepo.Add(createExamVM.Exam);
                    _examRepo.Save();
                    createExamVM.Q1.ExamId = createExamVM.Exam.ExamId;
                    createExamVM.Q2.ExamId = createExamVM.Exam.ExamId;
                    createExamVM.Q3.ExamId = createExamVM.Exam.ExamId;
                    createExamVM.Q4.ExamId = createExamVM.Exam.ExamId;

                    _questionRepo.Add(createExamVM.Q1);
                    _questionRepo.Add(createExamVM.Q2);
                    _questionRepo.Add(createExamVM.Q3);
                    _questionRepo.Add(createExamVM.Q4);

                    _questionRepo.Save();
                }
                else
                {
                    createExamVM.NewsContentList = _newsFetcher.GetLastFive();
                    return View("Index", createExamVM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            Exam exam =  _examRepo.Find(Id);
            if(exam !=null)
            {
                _examRepo.Remove(exam);
                _examRepo.Save();
            }
            return RedirectToAction(nameof(Index));
        }


        #region API CALLS
        [HttpGet]
        public IActionResult CheckAnswers(Guid Q1,string Q1A, Guid Q2, string Q2A, Guid Q3, string Q3A, Guid Q4, string Q4A)
        {
            var x = @"{
                    'Q1':'',
                    'Q2':'',
                    'Q3':'',
                    'Q4':''
                     }";

            var jObj = JObject.Parse(x);

            CheckAnswersResponseVM response = new CheckAnswersResponseVM();
            if (Q1!=Guid.Empty && !String.IsNullOrEmpty(Q1A))
            {
                Question question = new Question();
                question = _questionRepo.Find(Q1);
                if (question.TrueOption==Q1A)
                {
                    response.Q1= true;
                }
                else
                {
                    response.Q1=false;
                }
            }

            if (Q2 != Guid.Empty && !String.IsNullOrEmpty(Q2A))
            {
                Question question = new Question();
                question = _questionRepo.Find(Q2);
                if (question.TrueOption == Q2A)
                {
                    response.Q2 = true;
                }
                else
                {
                    response.Q2 = false;
                }
            }

            if (Q3 != Guid.Empty && !String.IsNullOrEmpty(Q3A))
            {
                Question question = new Question();
                question = _questionRepo.Find(Q3);
                if (question.TrueOption == Q3A)
                {
                    response.Q3 = true;
                }
                else
                {
                    response.Q3 = false;
                }
            }


            if (Q4 != Guid.Empty && !String.IsNullOrEmpty(Q4A))
            {
                Question question = new Question();
                question = _questionRepo.Find(Q4);
                if (question.TrueOption == Q4A)
                {
                    response.Q4 = true;
                }
                else
                {
                    response.Q4 = false;
                }
            }
            return Json(new {response });
        }

        #endregion
    }
}

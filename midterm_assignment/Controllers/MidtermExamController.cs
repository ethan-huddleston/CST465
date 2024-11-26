using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
namespace Midterm;

//TODO:  Is something missing here? 
public class MidtermExamController : Controller
{
    private readonly MidtermExam _Exam;
    private readonly IConfiguration _Config;
    
    public MidtermExamController(IConfiguration conf, IOptions<MidtermExam> exam)
    {
        _Exam = exam.Value;
    }
    [Route("")]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("TakeTest")]
    [HttpGet]
    public IActionResult TakeTest()
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        return View(questionModels);
    }
    [Route("SubmitTest")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult TakeTest(List<TestQuestionModel> model)
    {
        List<TestQuestionModel> questionModels = GetQuestionModels();
        for(int index = 0; index < questionModels.Count; index ++)
        {
            if(index < model.Count)
            {
                questionModels[index].Answer = model[index].Answer;
            }
            
        }
        
        if(!ModelState.IsValid)
        {
            return View(questionModels);
        }

        //TODO: Change the below so that it loads the DisplayResults view, passing in the model
        return View("DisplayResults",questionModels);
        
    }
    private List<TestQuestionModel> GetQuestionModels()
    {
        List<TestQuestionModel> questionModels = new List<TestQuestionModel>();
        foreach(var question in _Exam.Questions)
        {
            if(question.QuestionType == "TrueFalseQuestion")
            {
                TrueFalseQuestionModel tfQuestion = new TrueFalseQuestionModel();
                tfQuestion.ID = question.ID;
                tfQuestion.Question = question.Question;
                questionModels.Add(tfQuestion);
                
            }
            else if(question.QuestionType == "LongAnswerQuestion")
            {
                LongAnswerQuestionModel longQuestion = new LongAnswerQuestionModel();
                longQuestion.ID = question.ID;
                longQuestion.Question = question.Question;
                questionModels.Add(longQuestion);
                
            }
            else if(question.QuestionType == "ShortAnswerQuestion")
            {
                ShortAnswerQuestionModel shortQuestion = new ShortAnswerQuestionModel();
                shortQuestion.ID = question.ID;
                shortQuestion.Question = question.Question;
                questionModels.Add(shortQuestion);
                
            }
             else if(question.QuestionType == "MultipleChoiceQuestion")
            {
                MultipleChoiceQuestionModel multipleQuestion = new MultipleChoiceQuestionModel();
                multipleQuestion.ID = question.ID;
                multipleQuestion.Question = question.Question;
                multipleQuestion.Choices = question.Choices;
                questionModels.Add(multipleQuestion);
                
                
            }
           
        }
        return questionModels;
    }
}
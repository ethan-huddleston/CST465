using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class ShortAnswerQuestionModel : TestQuestionModel
{
    [Required]
    [StringLength(100, ErrorMessage="The string cannot be longer than a 100 characters")]
    public override string Answer{get;set;}
}
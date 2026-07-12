using KargoYazilimi.TransportMongoDb.Services.QuestionService;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.ViewComponents.DefaultComponents
{
    public class _DefaultFrequentlyAskedQuestionsComponentPartial : ViewComponent
    {
        private readonly IQuestionService _questionService;

        public _DefaultFrequentlyAskedQuestionsComponentPartial(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _questionService.GetAllQuestionAsync());
        }
    }
}

using KargoYazilimi.TransportMongoDb.Dtos.QuestionDtos;
using KargoYazilimi.TransportMongoDb.Services.QuestionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KargoYazilimi.TransportMongoDb.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IActionResult> QuestionList()
        {
            var values = await _questionService.GetAllQuestionAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            await _questionService.CreateQuestionAsync(createQuestionDto);
            return RedirectToAction("QuestionList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(string id)
        {
            var value = await _questionService.GetQuestionByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            await _questionService.UpdateQuestionAsync(updateQuestionDto);
            return RedirectToAction("QuestionList");
        }

        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return RedirectToAction("QuestionList");
        }
    }
}

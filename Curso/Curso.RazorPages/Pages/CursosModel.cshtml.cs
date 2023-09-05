using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Feedback.RazorPages.Pages
{
    public class FeedbacksModel : PageModel
    {
            //    private readonly FeedbackService _feedbackService;

        // public FeedbacksModel(FeedbackService feedbackService)
        // {
        //     _feedbackService = feedbackService;
        // }

        // public List<FeedbackModel> FeedbackList { get; set; } = new List<FeedbackModel>();

        // public void OnGet()
        // {
        //     FeedbackList = _feedbackService.GetAllFeedbacks();
        // }

        // public IActionResult OnPost(FeedbackModel feedback)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     _feedbackService.AddFeedback(feedback);

        //     // Redirecionar para a página de feedbacks ou fazer algo mais, se necessário.
        //     return RedirectToPage("/Feedbacks");
        // }
    }
}
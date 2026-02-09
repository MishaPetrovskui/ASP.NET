using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class JobsModel : PageModel
    {
        private readonly JobService _job;

        public List<Job> Jobs => _job.GetAll();

        [BindProperty]
        public Job CurrentJob { get; set; } = new Job();

        public JobsModel(JobService jobs)
        {
            _job = jobs;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _job.Add(CurrentJob);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false });
            }
            
            _job.Update(id, CurrentJob);
            return new JsonResult(new { success = true });
        }

        public IActionResult OnPostDelete(int id)
        {
            if (!ModelState.IsValid) {
                return new JsonResult(new { success = false });
            }
            _job.Delete(id);
            return new JsonResult(new { success = true });
        }
    }
}
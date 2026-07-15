using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyReminder.Web.Pages;

public class IndexModel : PageModel
{
    public bool HasUpcomingReminders { get; private set; }

    public void OnGet()
    {
        HasUpcomingReminders = false;
    }
}

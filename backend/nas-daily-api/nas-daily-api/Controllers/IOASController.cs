using Microsoft.AspNetCore.Mvc;

namespace nas_daily_api.Controllers
{
    public interface IOASController
    {
        IActionResult GetOASByUserId(string userId);

        // Add more method signatures as per your requirements
    }
}
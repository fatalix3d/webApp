using Microsoft.AspNetCore.Mvc;

namespace webApp.Controllers.Home
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Hello unknown user";
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            if(email.Equals("test@mail.ru") && password.Equals("pass")){
                return Redirect("/api?x-api-key=your_secret_key_here");
            }

            // Если есть ошибки, отобразить форму с ошибками
            return View();
        }

    }
}

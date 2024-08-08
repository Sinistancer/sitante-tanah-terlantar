using Blazor.Client.Pages._2___PPTT;
using Blazor.Client.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Blazor.Server.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public List<string> ValidationMessages = new List<string>();

        public async Task<IActionResult> OnPost(HttpClient httpClient)
        {
            ValidationMessages.Clear();

            // Validate the form
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(Input, new ValidationContext(Input), validationResults, true);

            if (!isValid)
            {
                // Get error messages from validationResults
                foreach (var validationResult in validationResults)
                {
                    ValidationMessages.Add(validationResult.ErrorMessage);
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var data = new { UserName = Input.Username, Password = Input.Password }; // Contoh data

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Your logic here
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5260/api/AuthorizationManagement/client/login", content);

            if (response.IsSuccessStatusCode)
            {
                // Handle successful response
                var dataResponse = await response.Content.ReadAsStringAsync();

                JObject jsonResponse = JObject.Parse(dataResponse);
                var claims = JwtTokenUtility.DecodeJwtTokenUtility(jsonResponse["data"]["accessToken"].ToString());

                var identity = new ClaimsIdentity(claims, "custom");
                var user = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(user);
                return Redirect("/beranda");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }

        public class LoginInputModel
        {
            [Required(ErrorMessage = "Username is required")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using SmartCookbook.Models;
using System.ComponentModel.DataAnnotations;

namespace SmartCookbook.Views.AddRecipe
{
    public class CreateRecipeModel : PageModel
    {
        private readonly UserManager<SmartCookbookUser> _userManager;
        private readonly SignInManager<SmartCookbookUser> _signInManager;

        public CreateRecipeModel(
            UserManager<SmartCookbookUser> userManager,
            SignInManager<SmartCookbookUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public int Id { get; set; }
            public int Author { get; set; }
            public bool Private { get; set; }
            public string? Name { get; set; }

            [Display(Name = "Image Path")]
            public string? ImagePath { get; set; } = string.Empty;
            public string? Description { get; set; } = string.Empty;
            public List<(string name, string? unit, int calories, double fat, double carbs, double protein, double quantity)>? Ingredients { get; set; }
            public List<(string? description, int duration, string? unit)>? Steps { get; set; }
        }

        private async Task LoadAsync(SmartCookbookUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Id = new(),
                Author = new(),
                Private = new(),
                Name = string.Empty,
                ImagePath = string.Empty,
                Description = string.Empty,
                Ingredients = new(),
                Steps = new()
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }




            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

    }
}

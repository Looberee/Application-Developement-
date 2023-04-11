using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication123.Data;

namespace WebApplication123.Areas.Authenticated.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManger;

        // GET
        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManger = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            // taking current login user id
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // exception itself admin
            var userList = _db.ApplicationUsers.Where(u => u.Id != claims.Value);

            foreach (var user in userList)
            {
                var userTemp = await _userManager.FindByIdAsync(user.Id);
                var roleTemp = await _userManager.GetRolesAsync(userTemp);
                user.Role = roleTemp.FirstOrDefault();
            }


            // ReSharper disable once Mvc.ViewNotResolved
            return View(userList.ToList());
        }


        // lock and unlock

        [HttpGet]
        public async Task<IActionResult> LockUnlock(string id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var userNeedToLock = _db.ApplicationUsers.Where(u => u.Id == id).First();

            if (userNeedToLock.Id == claims.Value)
            {
                // hien ra loi ban dang khoa tai khoan cua chinh minh
            }

            if (userNeedToLock.LockoutEnd != null && userNeedToLock.LockoutEnd > DateTime.Now)
                userNeedToLock.LockoutEnd = DateTime.Now;
            else
                userNeedToLock.LockoutEnd = DateTime.Now.AddYears(1000);

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}

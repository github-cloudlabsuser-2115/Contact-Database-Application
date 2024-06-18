using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Return the userlist to the Index view
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Details view
            return View(user);
        }
 
      // POST: User/Create
        [HttpPost]
        public ActionResult Create()
        {
            // Add the user to the userlist
            User user = new User();
            userlist.Add(user);
                       

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
 
      // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
 
      // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Pass the user to the Edit view
            return View(user);
        }
 
      // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Retrieve the user with the specified ID from the userlist
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the user's information with the new values
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
 
      // Implement the Delete method here
        public ActionResult Delete(int id)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
 
      // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Retrieve the user with the specified ID from the userlist
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return a HttpNotFoundResult
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the userlist
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}

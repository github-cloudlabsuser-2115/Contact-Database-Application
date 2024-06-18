using NUnit.Framework;
using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class UserControllerTests
{
    private UserController controller;

    [SetUp]
    public void Setup()
    {
        // Clear and setup the static userlist before each test
        UserController.userlist.Clear();
        UserController.userlist.AddRange(new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new User { Id = 2, Name = "Jane Doe", Email = "jane@example.com" }
        });

        controller = new UserController();
    }

    [Test]
    public void Index_ReturnsCorrectViewWithModel()
    {
        var result = controller.Index() as ViewResult;
        Assert.IsNotNull(result);
        var model = result.Model as List<User>;
        Assert.IsNotNull(model);
        Assert.AreEqual(2, model.Count);
    }

    [Test]
    public void Details_ValidId_ReturnsUser()
    {
        var result = controller.Details(1) as ViewResult;
        Assert.IsNotNull(result);
        var user = result.Model as User;
        Assert.IsNotNull(user);
        Assert.AreEqual(1, user.Id);
    }

    [Test]
    public void Details_InvalidId_ReturnsHttpNotFound()
    {
        var result = controller.Details(99);
        Assert.IsInstanceOf<HttpNotFoundResult>(result);
    }

    [Test]
    public void Create_Post_AddsUser_RedirectsToIndex()
    {
        var newUser = new User { Id = 3, Name = "New User", Email = "new@example.com" };
        var result = controller.Create(newUser) as RedirectToRouteResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]);
        Assert.AreEqual(3, UserController.userlist.Count);
    }

    [Test]
    public void Edit_ValidId_UpdatesUser()
    {
        var updatedUser = new User { Name = "Updated Name", Email = "updated@example.com" };
        var result = controller.Edit(1, updatedUser) as RedirectToRouteResult;
        Assert.IsNotNull(result);
        var user = UserController.userlist.FirstOrDefault(u => u.Id == 1);
        Assert.AreEqual("Updated Name", user.Name);
    }

    [Test]
    public void Edit_InvalidId_ReturnsHttpNotFound()
    {
        var result = controller.Edit(99, new User()) as HttpNotFoundResult;
        Assert.IsNotNull(result);
    }

    [Test]
    public void Delete_ValidId_RemovesUser_RedirectsToIndex()
    {
        var result = controller.Delete(1, null) as RedirectToRouteResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.RouteValues["action"]);
        Assert.AreEqual(1, UserController.userlist.Count);
    }

    [Test]
    public void Delete_InvalidId_ReturnsHttpNotFound()
    {
        var result = controller.Delete(99, null);
        Assert.IsInstanceOf<HttpNotFoundResult>(result);
    }
}

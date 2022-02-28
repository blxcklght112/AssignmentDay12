using System;
using System.Collections.Generic;
using System.Linq;
using Day7.Controllers;
using Day7.Enum;
using Day7.Models;
using Day7.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Day7.Tests;

public class Tests
{
    private Mock<ILogger<PeopleController>> _loggerMock;
    private Mock<IRookiesService> _serviceMock;
    private PeopleController _controller;
    static List<PersonModel> _people = new List<PersonModel>{
            new PersonModel{
                ID = 1,
                FirstName = "Loc Test 1",
                LastName = "Pham Duc",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1999,01,12),
                PhoneNumber = "0343428821",
                BirthPlace = "Ha Noi",
                IsGraduated = "Yes"
                },
            new PersonModel{
                ID = 2,
                FirstName = "Loc Test 2",
                LastName = "Pham Duc",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2000,01,12),
                PhoneNumber = "0343428821",
                BirthPlace = "Ha Noi",
                IsGraduated = "No"
            }
    };

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<PeopleController>>();
        _serviceMock = new Mock<IRookiesService>();

        _controller = new PeopleController(_loggerMock.Object, _serviceMock.Object);
    }

    [Test]
    public void Index_ReturnView()
    {
        //Act
        var result = _controller.Index();

        //Assert
        Assert.IsInstanceOf<ViewResult>(result, "Invalid return type!!!");
    }

    [Test]
    public void Add_ReturnRedirectToActionIndex()
    {
        //Arrange
        var person = new PersonModel
        {
            ID = 3,
            FirstName = "Loc Test 3",
            LastName = "Pham Duc",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(2000, 01, 12),
            PhoneNumber = "0343428821",
            BirthPlace = "Ha Noi",
            IsGraduated = "No"
        };
        _serviceMock.Setup(x => x.AddPerson(person)).Callback<PersonModel>((PersonModel p) => _people.Add(p));
        var expectedCount = _people.Count + 1;

        //Act
        var result = _controller.Add(person);

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result, "Invalid return type!!!");

        Assert.AreEqual(expectedCount, _people.Count, "Not equals!!!");

        Assert.AreEqual(person, _people.Last(), "Add error!!!");
    }

    [Test]
    public void Delete_ReturnRedirectToActionDelete()
    {
        //Arrange
        var personId = _people.Last().ID;
        var person = _people.FirstOrDefault(x => x.ID == personId);
        _serviceMock.Setup(x => x.DeletePerson(personId)).Callback(() => _people.Remove(person));
        var expectedCount = _people.Count - 1;

        //Act
        var result = _controller.DeletePerson(personId);

        //Assert
        Assert.IsInstanceOf<RedirectToActionResult>(result, "Invalid return type!!!");

        Assert.AreEqual(expectedCount, _people.Count, "Delete error!!!");

        CollectionAssert.DoesNotContain(_people, person, "Delete error!!!");
    }
}

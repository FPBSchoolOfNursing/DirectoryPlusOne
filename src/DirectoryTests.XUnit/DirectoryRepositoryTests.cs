using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using DirectoryPlusOne.Services;
using DirectoryPlusOne.DAL;
using DirectoryPlusOne.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using DirectoryPlusOne.Models;

namespace DirectoryTests.XUnit
{
    public class DirectoryRepositoryTests
    {
        private IQueryable<Person> fakepeople;
        public DirectoryRepositoryTests()
        {
            fakepeople = DirectoryInitilizer.GetFakePeople.AsQueryable();
        }
      
        [Fact]
        public void Select()
        {
            //Arrange
            var mockPeople = new Mock<DbSet<Person>>();
            mockPeople.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(fakepeople.Provider);
            mockPeople.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(fakepeople.Expression);
            mockPeople.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(fakepeople.ElementType);
            mockPeople.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(fakepeople.GetEnumerator());
            
            var mockContext = new Mock<IDirectoryContext>();
            mockContext.Setup(m => m.People).Returns(mockPeople.Object);            
            var service = new DirectoryService(mockContext.Object);

            //Act
            var testperson = service.GetByCaseUserID("abc1250");
            //FirstName = "Alice3", LastName="Contera3", LastModified=DateTime.Now, PhoneNumber="216-368-3000"
            //Assert
            Assert.Equal("abc1250", testperson.CaseUserID);
            Assert.Equal("Alice3", testperson.FirstName);
            Assert.Equal("Contera3", testperson.LastName);
            Assert.NotNull(testperson.LastModified);
            Assert.Equal("216-368-3000", testperson.PhoneNumber);
            Assert.Null(testperson.Prefix);
            Assert.Null(testperson.Suffix);
            Assert.Null(testperson.Title);
            Assert.Null(testperson.HomePageURL);
            Assert.Null(testperson.ImageURL);
        }
    }
}

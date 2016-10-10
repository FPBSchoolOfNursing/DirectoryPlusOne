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
        private IQueryable<Office> fakeoffice;
        private IQueryable<Group> fakegroup;
        private Mock<IDirectoryContext> mockContext;
        private Mock<DbSet<Person>> mockPerson;
        private Mock<DbSet<Office>> mockOffice;
        private Mock<DbSet<Group>> mockGroup;

        public DirectoryRepositoryTests()
        {
            fakepeople = DirectoryInitilizer.GetFakePeople.AsQueryable();
            fakeoffice = DirectoryInitilizer.GetFakesOffices.AsQueryable();
            fakegroup = DirectoryInitilizer.GetFakeGroups.AsQueryable();
            mockContext = new Mock<IDirectoryContext>();

            mockPerson = new Mock<DbSet<Person>>();          
            mockPerson.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(fakepeople.Provider);
            mockPerson.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(fakepeople.Expression);
            mockPerson.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(fakepeople.ElementType);
            mockPerson.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(fakepeople.GetEnumerator());

            mockOffice = new Mock<DbSet<Office>>();
            mockOffice.As<IQueryable<Office>>().Setup(m => m.Provider).Returns(fakeoffice.Provider);
            mockOffice.As<IQueryable<Office>>().Setup(m => m.Expression).Returns(fakeoffice.Expression);
            mockOffice.As<IQueryable<Office>>().Setup(m => m.ElementType).Returns(fakeoffice.ElementType);
            mockOffice.As<IQueryable<Office>>().Setup(m => m.GetEnumerator()).Returns(fakeoffice.GetEnumerator());

            mockGroup = new Mock<DbSet<Group>>();
            mockGroup.As<IQueryable<Group>>().Setup(m => m.Provider).Returns(fakegroup.Provider);
            mockGroup.As<IQueryable<Group>>().Setup(m => m.Expression).Returns(fakegroup.Expression);
            mockGroup.As<IQueryable<Group>>().Setup(m => m.ElementType).Returns(fakegroup.ElementType);
            mockGroup.As<IQueryable<Group>>().Setup(m => m.GetEnumerator()).Returns(fakegroup.GetEnumerator());
        }
      
        [Fact]
        public void DirectoryServiceShouldReturnAPerson()
        {
            //Arrange   
            mockContext.Setup(m => m.People).Returns(mockPerson.Object);            
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

        [Fact]
        public void DirectoryServiceShouldReturnAnOffice()
        {
            //Arrage
            mockContext.Setup(m => m.Offices).Returns(mockOffice.Object);
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");

        }

        [Fact]
        public void DirectoryServiceShouldReturnAGroup()
        {
            //Arrage
            mockContext.Setup(m => m.Groups).Returns(mockGroup.Object);
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }


        [Fact]
        public void DirectoryServiceShouldReturnAPersonInAnOffice()
        {
            //Arrage
            mockContext.Setup(m => m.People).Returns(mockPerson.Object);
            mockContext.Setup(m => m.Offices).Returns(mockOffice.Object);
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }

        [Fact]
        public void DirectoryServiceShouldReturnAPersonInAGroup()
        {
            //Arrage
            mockContext.Setup(m => m.People).Returns(mockPerson.Object);
            mockContext.Setup(m => m.Groups).Returns(mockGroup.Object);
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }
    }
}

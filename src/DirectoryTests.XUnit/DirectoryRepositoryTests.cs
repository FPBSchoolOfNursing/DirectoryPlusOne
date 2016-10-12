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
using DirectoryTests.XUnit.FakeData;

namespace DirectoryTests.XUnit
{
    public class DirectoryRepositoryTests : DirectoryTestSetup
    {
       
        [Fact]
        public void DirectoryServiceShouldReturnAPerson()
        {
            //Arrange   
                    
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
           
            var service = new DirectoryService(mockContext.Object);

            //Act
            //var office = service.GetOffice();
            //Assert.NotNull(office);
        }

        [Fact]
        public void DirectoryServiceShouldReturnAGroup()
        {
            //Arrage           
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }


        [Fact]
        public void DirectoryServiceShouldReturnAPersonInAnOffice()
        {
            //Arrage            
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }

        [Fact]
        public void DirectoryServiceShouldReturnAPersonInAGroup()
        {
            //Arrage           
            var service = new DirectoryService(mockContext.Object);

            //Act
            throw new NotImplementedException("Test not implemented yet");
        }
    }
}

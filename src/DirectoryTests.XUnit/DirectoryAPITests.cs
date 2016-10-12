using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DirectoryPlusOne.Controllers.API;
using DirectoryPlusOne.Models;

namespace DirectoryTests.XUnit
{
    public class DirectoryAPITests : DirectoryTestSetup
    {
        [Fact]
        public void DirectoryGroupAPIHTTPGetShouldReturnADirectoryObject()
        {
            //Arrage                   
            //Act
            var api = new DirectoryAPIController(mockContext.Object);
            var directory = api.Get("utech");
            DirectoryReturn firstresult = directory.FirstOrDefault();
            //Assert
            Assert.True(directory.Count() > 0);
            Assert.Equal("abc123@case.edu", firstresult.Email);            
        }
    }
}

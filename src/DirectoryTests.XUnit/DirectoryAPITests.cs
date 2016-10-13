using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DirectoryPlusOne.Controllers.API;
using DirectoryPlusOne.Models;
using Microsoft.AspNetCore.Mvc;

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
            ObjectResult directory = api.Get("utech") as ObjectResult;           
            DirectoryReturn[] results = directory.Value as DirectoryReturn[];

            //Assert    
            Assert.NotNull(results);
            Assert.True(results.Count() > 0);

            var firstresult = results.First();
            Assert.Equal("abc123@case.edu", firstresult.Email);            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using DirectoryPlusOne.Models;
using DirectoryTests.XUnit.FakeData;
using DirectoryPlusOne.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DirectoryTests.XUnit
{
    public class DirectoryTestSetup
    {
        private IQueryable<Person> fakepeople;
        private IQueryable<Office> fakeoffice;
        private IQueryable<Group> fakegroup;
        private IQueryable<PersonGroup> fakepersongroup;
        private IQueryable<PersonOffice> fakepersonoffice;

        protected Mock<IDirectoryContext> mockContext;
        protected Mock<DbSet<Person>> mockPerson;
        protected Mock<DbSet<Office>> mockOffice;
        protected Mock<DbSet<Group>> mockGroup;
        protected Mock<DbSet<PersonGroup>> mockPersonGroup;
        protected Mock<DbSet<PersonOffice>> mockPersonOffice;

        public DirectoryTestSetup()
        {
            fakepeople = Fakes.GetFakePeople.AsQueryable();
            fakeoffice = Fakes.GetFakesOffices.AsQueryable();
            fakegroup = Fakes.GetFakeGroups.AsQueryable();
            fakepersongroup = Fakes.GetFakePersonGroups.AsQueryable();
            fakepersonoffice = Fakes.GetFakePersonOffices.AsQueryable();

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

            mockPersonGroup = new Mock<DbSet<PersonGroup>>();
            mockPersonGroup.As<IQueryable<PersonGroup>>().Setup(m => m.Provider).Returns(fakepersongroup.Provider);
            mockPersonGroup.As<IQueryable<PersonGroup>>().Setup(m => m.Expression).Returns(fakepersongroup.Expression);
            mockPersonGroup.As<IQueryable<PersonGroup>>().Setup(m => m.ElementType).Returns(fakepersongroup.ElementType);
            mockPersonGroup.As<IQueryable<PersonGroup>>().Setup(m => m.GetEnumerator()).Returns(fakepersongroup.GetEnumerator());

            mockPersonOffice = new Mock<DbSet<PersonOffice>>();
            mockPersonOffice.As<IQueryable<PersonOffice>>().Setup(m => m.Provider).Returns(fakepersonoffice.Provider);
            mockPersonOffice.As<IQueryable<PersonOffice>>().Setup(m => m.Expression).Returns(fakepersonoffice.Expression);
            mockPersonOffice.As<IQueryable<PersonOffice>>().Setup(m => m.ElementType).Returns(fakepersonoffice.ElementType);
            mockPersonOffice.As<IQueryable<PersonOffice>>().Setup(m => m.GetEnumerator()).Returns(fakepersonoffice.GetEnumerator());

            
            mockContext.Setup(m => m.People).Returns(mockPerson.Object);
            mockContext.Setup(m => m.Offices).Returns(mockOffice.Object);
            mockContext.Setup(m => m.Groups).Returns(mockGroup.Object);
            mockContext.Setup(m => m.PersonGroup).Returns(mockPersonGroup.Object);
            mockContext.Setup(m => m.PersonOffice).Returns(mockPersonOffice.Object);
        }
    }
}

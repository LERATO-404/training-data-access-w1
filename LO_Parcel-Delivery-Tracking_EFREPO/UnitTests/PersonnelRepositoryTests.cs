using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using NUnit.Framework;
using EFCodeFirstModelsLib;
using EFCodeFirstModelsLib.Models;
using EFCodeFirstRepoLib.Repositories;
using Moq;
using System.Data.Entity;
using static NUnit.Framework.Constraints.Tolerance;

namespace UnitTests
{
    [TestFixture]
    public class PersonnelRepositoryTests
    {
        private PersonnelRepository _personnelRepository;
        private Mock<ParcelDeliveryTrackingDBEntities> _mockContext;
        public Mock<PersonnelRepository> _mockRepo;
        private Mock<DbSet<Personnel>> _mockPersonnelSet;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<ParcelDeliveryTrackingDBEntities>();     
            _mockPersonnelSet= new Mock<DbSet<Personnel>>();

            _mockContext.Setup(c => c.personnel).Returns(_mockPersonnelSet.Object);
            _personnelRepository = new PersonnelRepository();
            _mockRepo = new Mock<PersonnelRepository>();

        }

        [Test]
        public void Init()
        {
            Assert.That(_mockRepo = new Mock<PersonnelRepository>(), Is.InstanceOf<Mock<PersonnelRepository>>());
        }


        [TearDown]
        public void TearDown()
        {
            _mockContext = null;
            _mockRepo= null;
            _mockPersonnelSet= null;
        }
    }
}

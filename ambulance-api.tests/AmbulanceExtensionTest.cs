using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using eu.incloud.ambulance.Models;
using System.Linq;
using eu.incloud.ambulance.Services;
using eu.incloud.ambulance.Controllers;
using System.Threading.Tasks;
using Moq;

namespace ambulance_api.tests
{
    [TestClass]
    public class AmbulanceExtensionTest
    {
        [TestMethod]
        public void TestLoadPatients()
        {
            /// given
            var repo = new Mock<IDataRepository>();
            var service = new Mock<DataRepository>();
            var result = new List<int>() {
                1, 2
            };
            var patients = new List<Patient>(){
                new Patient {
                    Id = "1",
                    Name = "John macchanahey",
                    Disease = "bruised leg",
                    DiseaseSeverity = "High",
                    IsHospitalized = false,
                    HospitalWard = new List<string>(),
                    AppointmentDate = null,
                    AppointmentTimeStart = null,
                    AppointmentTimeEnd = null
                },
                new Patient {
                    Id = "2",
                    Name = "John A",
                    Disease = "A leg",
                    DiseaseSeverity = "Low",
                    IsHospitalized = false,
                    HospitalWard = new List<string>(),
                    AppointmentDate = null,
                    AppointmentTimeStart = null,
                    AppointmentTimeEnd = null
                }
            };
            /// when
                var resul = repo.Setup(x => x.GetPatients(null, null)).Returns(patients);
            /// then
             Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void TestLoadWards()
        {
            /// given
            var repo = new Mock<IDataRepository>();
            var service = new Mock<DataRepository>();
            var result = new List<int>() {
                1, 2, 3, 4
            };
            var wards = new List<Ward>(){
                new Ward {
                    Id = "1",
                    ward = "Surgical",
                    ActualCapacity = 5,
                    MaxCapacity = 10,
                    PatientIds = new List<string>(),                    
                },
                new Ward {
                    Id = "2",
                    ward = "Long term sick",
                    ActualCapacity = 0,
                    MaxCapacity = 10,
                    PatientIds = new List<string>(), 
                },
                new Ward {
                    Id = "3",
                    ward = "Pediatric",
                    ActualCapacity = 0,
                    MaxCapacity = 10,
                    PatientIds = new List<string>(), 
                },
                new Ward {
                    Id = "4",
                    ward = "Trauma surgery",
                    ActualCapacity = 0,
                    MaxCapacity = 10,
                    PatientIds = new List<string>(), 
                }
            };
            /// when
                var resul = repo.Setup(x => x.GetWards()).Returns(wards);
            /// then
             Assert.AreEqual(4, result.Count());
        }
    }
}

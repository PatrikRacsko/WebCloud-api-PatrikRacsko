using System.IO;
using eu.incloud.ambulance.Models;
using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;
namespace eu.incloud.ambulance.Services
{
    class DataRepository : IDataRepository
    {
        private readonly LiteDatabase liteDb;
        private static readonly string PATIENTS_COLLECTION = "patients";
        private static readonly string WARDS_COLLECTION = "wards";

        public DataRepository(
            IWebHostEnvironment environment, IConfiguration configuration)
        {
            string dbPath = configuration["DATA_REPOSITORY_DB"];
            if (dbPath == null || dbPath.Length == 0)
            {
                dbPath = Path.Combine(
                    environment.ContentRootPath, "data-repository.litedb");
            }
            this.liteDb = new LiteDatabase(dbPath);
        }

        public IEnumerable<Patient> GetPatients(string severity, string department) {
            var collection = this.liteDb.GetCollection<Patient>(PATIENTS_COLLECTION);
            var allPatients = collection.FindAll();
            if(severity == null && department == null) {
                return allPatients;
            } else if(severity == null) {
                string[] departments = department.Split(',');
                return allPatients.Where(patient => patient.HospitalWard.Any(x => departments.Contains(x)));
            } else if(department == null) {
                string[] severities = severity.Split(',').Select(n => n.ToLower()).ToArray();
                return allPatients.Where(patient => severities.Contains(patient.DiseaseSeverity.ToLower()));
            } else {
                string[] severities = severity.Split(',');
                string[] departments = department.Split(',');
                var deps = allPatients.Where(patient => patient.HospitalWard.Any(x => departments.Contains(x)));
                var sevs = allPatients.Where(patient => severities.Contains(patient.DiseaseSeverity));
                return deps.Union(sevs).ToArray();
            }
        }

        public Patient GetPatientDetails (string patientId) {
            var collection = this.liteDb.GetCollection<Patient>(PATIENTS_COLLECTION);
            var patient = collection.FindById(patientId);
            if (patient != null) {
                return patient;
            } else {
                return null;
            }
        }

        public string UpsertPatient(Patient patient)
        {
            var collection = this.liteDb.GetCollection<Patient>(PATIENTS_COLLECTION);
            if (patient.Id == "-1" || patient.Id == null) {
                var patients = collection.FindAll();
                patient.Id = (patients.Count()+1).ToString();
            }
            var existing = collection.FindById(patient.Id);
            if (existing == null)
            {
                patient.Id = collection.Insert(patient);
            }
            else
            {
                collection.Update(patient);
            }
            return patient.Id;
        }

        public string DeletePatient(string patientId)
        {
            var collection = this.liteDb.GetCollection<Patient>(PATIENTS_COLLECTION);
            collection.Delete(patientId);
            return patientId;
        }

        public void DeleteWard(string wardId) {
            var collection = this.liteDb.GetCollection<Ward>(WARDS_COLLECTION);
            collection.Delete(wardId);
        }

        public string UpsertWard(Ward ward)
        {
            var collection = this.liteDb.GetCollection<Ward>(WARDS_COLLECTION);
            var patientCollection = this.liteDb.GetCollection<Patient>(PATIENTS_COLLECTION);
            var existing = collection.FindById(ward.Id);
            if (existing == null)
            {
                ward.Id = collection.Insert(ward);
            }
            else
            {
                collection.Update(ward);
            }
        
            //update patient model as well
            if(ward.PatientIds.Count > 0) {
                var patientId = ward.PatientIds[ward.PatientIds.Count-1];
                //remove from other wards
                var wards = collection.FindAll();
                foreach(var localWard in wards) {
                    if(localWard.PatientIds.Contains(patientId) && localWard.Id != ward.Id) {
                        localWard.PatientIds.RemoveAll(id => id == patientId);
                        collection.Update(localWard);
                    }
                }
                var foundPatient = patientCollection.FindById(patientId);
                List<string> wardList = new List<string> { ward.Id }; 
                foundPatient.HospitalWard = wardList;
                UpsertPatient(foundPatient);
            }
            return ward.Id;
        }
        public IEnumerable<Ward> GetWards() {
            var collection = this.liteDb.GetCollection<Ward>(WARDS_COLLECTION);
            return collection.FindAll();
        }

        public Ward GetExactWard(string wardId) {
            var collection = this.liteDb.GetCollection<Ward>(WARDS_COLLECTION);
            var ward = collection.FindById(wardId);
            if (ward != null) {
                return ward;
            } else {
                return null;
            }
        }
    }
}
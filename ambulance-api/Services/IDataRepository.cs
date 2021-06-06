using eu.incloud.ambulance.Models;
using System.Collections.Generic;

namespace eu.incloud.ambulance.Services
{
    /// <summary>
    /// Abstraction of the data repository keeping data model persistent
    ///
    /// Responsibilities:
    ///     * CRUD operations over data maodel
    ///     * Searching and filtering durring data retrieval
    /// </summary>
    public interface IDataRepository
    {
        /// <summary>
        /// Provides patients list which arent assigned to any ward
        /// </summary>
        /// <returns>patient list</returns>
        IEnumerable<Patient> GetPatients(string severity, string department);
    
        /// <summary>
        /// Inserts if doesn't exist, updates if exists
        /// </summary>
        /// <returns>patient id</returns>
        string UpsertPatient(Patient patient);

        /// <summary>
        /// Deletes patient
        /// </summary>
        /// <param name="patientId">id of the patient</param>
        string DeletePatient(string patientId);

        /// <summary>
        /// Loads exact patient details
        /// </summary>
        /// <param name="patientId">id of the patient</param>
        /// <returns>patient</returns>
        Patient GetPatientDetails(string patientId);

        /// <summary>
        /// Inserts if doesn't exist, updates if exists
        /// </summary>
        /// <param name="ward">ward</param>
        /// <returns>ward id</returns>
        string UpsertWard(Ward ward);

        /// <summary>
        /// Deletes ward
        /// </summary>
        /// <param name="wardId">id of the ward</param>
        void DeleteWard(string wardId);


        /// <summary>
        /// Loads exact Ward
        /// </summary>
        /// <param name="wardId">id of the patient</param>
        Ward GetExactWard(string wardId);

        /// <summary>
        /// Load Wards
        /// </summary>
        IEnumerable<Ward> GetWards();
    }
}
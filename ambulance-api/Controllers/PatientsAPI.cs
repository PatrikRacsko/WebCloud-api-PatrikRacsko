/*
 * Waiting List [API](/_glossary?id=api)
 *
 * Ambulance Waiting List managegement for Web In [Cloud](/_glossary?id=cloud) system
 *
 * OpenAPI spec version: 3.0.0
 * Contact: aa@bb.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using eu.incloud.ambulance.Attributes;

using Microsoft.AspNetCore.Authorization;
using eu.incloud.ambulance.Models;
using System.Linq;
using eu.incloud.ambulance.Services;

namespace eu.incloud.ambulance.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]

    public class PatientsApiController : ControllerBase
    { 
        private readonly IDataRepository repository;
        /// <summary/>

        public PatientsApiController(IDataRepository repository)
                => this.repository = repository;

        /// Create patient entry
        /// <remarks>Use this method to create patients.</remarks>
        /// <response code="200">Returned patient Id</response>
        [HttpPost]
        [Route("api/ambulance/upsertPatient")]
        [SwaggerOperation("UpsertPatient")]
        public virtual ActionResult CreatePatients(
            [FromBody] Patient body
        ) {
            var patientId = this.repository.UpsertPatient(body);
            return new OkObjectResult(patientId);
        }

        /// Delete patient entry
        /// <remarks>Use this method to delete patients.</remarks>
        /// <response code="200">Returs Ok</response>
        [HttpDelete]
        [Route("api/ambulance/deletePatient/{patientId}")]
        [SwaggerOperation("DeletePatient")]
        public virtual ActionResult DeletePatient(
            [FromRoute][Required] string patientId
        ) {
            var patientIdDeleted = this.repository.DeletePatient(patientId);
            return new OkObjectResult(patientIdDeleted);
        }

        /// Returns exact patient
        /// <remarks>Use this method to return exact patient by id.</remarks>
        /// <response code="200">Returned patient</response>
        /// <response code="404">No patient found</response>
        [HttpGet]
        [Route("api/ambulance/getExactPatient/{patientId}")]
        [SwaggerOperation("LoadExactPatient")]
        public virtual ActionResult<Patient> LoadPatient(
            [FromRoute] string patientId
        ) {
            var patient = this.repository.GetPatientDetails(patientId);
            if (patient != null) {
                return patient;
            } else {
                return new NotFoundResult();
            }
        }

        /// Returns patients
        /// <remarks>Use this method to return patients.</remarks>
        /// <response code="200">Returned patients</response>
        /// <response code="404">No patients found</response>
        [HttpGet()]
        [Route("api/ambulance/getPatients")]
        [SwaggerOperation("LoadPatients")]
        public virtual ActionResult<IEnumerable<Patient>> LoadPatients(
            [FromQuery(Name = "severity")] string severity,
            [FromQuery(Name = "department")] string department
            ) {
            var patients = this.repository.GetPatients(severity, department);
            if (patients != null) {
                return new ObjectResult(patients);
            } else {
                return new NotFoundResult();
            }
        }
    }
}

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

    public class WardApiController : ControllerBase
    { 
        private readonly IDataRepository repository;
        /// <summary/>

        public WardApiController(IDataRepository repository)
                => this.repository = repository;

        /// Create ward entry
        /// <remarks>Use this method to create wards.</remarks>
        /// <response code="200">Returned ward Id</response>
        [HttpPost]
        [Route("api/ambulance/upsertWard")]
        [SwaggerOperation("upsertWard")]
        public virtual ActionResult CreateWard(
            [FromBody] Ward body
        ) {
            var wardId = this.repository.UpsertWard(body);
            return new OkObjectResult(wardId);
        }

        /// Delete ward entry
        /// <remarks>Use this method to delete wards.</remarks>
        /// <response code="200">Returs Ok</response>
        [HttpDelete]
        [Route("api/ambulance/deleteWard/{wardId}")]
        [SwaggerOperation("DeleteWard")]
        public virtual ActionResult DeleteWard(
            [FromRoute][Required] string wardId
        ) {
            this.repository.DeleteWard(wardId);
            return new OkObjectResult(wardId);
        }

        /// Returns exact ward
        /// <remarks>Use this method to return exact ward by id.</remarks>
        /// <response code="200">Returned ward</response>
        /// <response code="404">No ward found</response>
        [HttpGet]
        [Route("api/ambulance/getExactWard/{wardId}")]
        [SwaggerOperation("LoadExactWard")]
        public virtual ActionResult<Ward> LoadExactWard(
            [FromRoute] string wardId
        ) {
            var ward = this.repository.GetExactWard(wardId);
            if (ward != null) {
                return ward;
            } else {
                return new NotFoundResult();
            }
        }

        /// Returns wards
        /// <remarks>Use this method to return wards.</remarks>
        /// <response code="200">Returned wards</response>
        /// <response code="404">No wards found</response>
        [HttpGet]
        [Route("api/ambulance/getWards")]
        [SwaggerOperation("LoadWards")]
        public virtual ActionResult<IEnumerable<Ward>> LoadWards() {
            var patients = this.repository.GetWards();
            if (patients != null) {
                return new ObjectResult(patients);
            } else {
                return new NotFoundResult();
            }
        }
    }
}

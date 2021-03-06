/*
 * Simple Inventory API
 *
 * This is a simple API
 *
 * OpenAPI spec version: 3.0.0
 * Contact: you@your-company.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace eu.incloud.ambulance.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Patient : IEquatable<Patient>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]
        [DataMember(Name="id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Disease
        /// </summary>
        [Required]
        [DataMember(Name="disease")]
        public string Disease { get; set; }

        /// <summary>
        /// Gets or Sets DiseaseSeverity
        /// </summary>
        [Required]
        [DataMember(Name="diseaseSeverity")]
        public string DiseaseSeverity { get; set; }

        /// <summary>
        /// Gets or Sets IsHospitalized
        /// </summary>
        [Required]
        [DataMember(Name="isHospitalized")]
        public bool? IsHospitalized { get; set; }

        /// <summary>
        /// Gets or Sets HospitalWard
        /// </summary>
        [Required]
        [DataMember(Name="hospitalWard")]
        public List<string> HospitalWard { get; set; }

        /// <summary>
        /// Gets or Sets AppointmentDate
        /// </summary>
        [DataMember(Name="appointmentDate")]
        public string AppointmentDate { get; set; }

        /// <summary>
        /// Gets or Sets AppointmentTimeStart
        /// </summary>
        [DataMember(Name="appointmentTimeStart")]
        public string AppointmentTimeStart { get; set; }

        /// <summary>
        /// Gets or Sets AppointmentTimeEnd
        /// </summary>
        [DataMember(Name="appointmentTimeEnd")]
        public string AppointmentTimeEnd { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Patient {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Disease: ").Append(Disease).Append("\n");
            sb.Append("  DiseaseSeverity: ").Append(DiseaseSeverity).Append("\n");
            sb.Append("  IsHospitalized: ").Append(IsHospitalized).Append("\n");
            sb.Append("  HospitalWard: ").Append(HospitalWard).Append("\n");
            sb.Append("  AppointmentDate: ").Append(AppointmentDate).Append("\n");
            sb.Append("  AppointmentTimeStart: ").Append(AppointmentTimeStart).Append("\n");
            sb.Append("  AppointmentTimeEnd: ").Append(AppointmentTimeEnd).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Patient)obj);
        }

        /// <summary>
        /// Returns true if Patient instances are equal
        /// </summary>
        /// <param name="other">Instance of Patient to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Patient other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Disease == other.Disease ||
                    Disease != null &&
                    Disease.Equals(other.Disease)
                ) && 
                (
                    DiseaseSeverity == other.DiseaseSeverity ||
                    DiseaseSeverity != null &&
                    DiseaseSeverity.Equals(other.DiseaseSeverity)
                ) && 
                (
                    IsHospitalized == other.IsHospitalized ||
                    IsHospitalized != null &&
                    IsHospitalized.Equals(other.IsHospitalized)
                ) && 
                (
                    HospitalWard == other.HospitalWard ||
                    HospitalWard != null &&
                    HospitalWard.Equals(other.HospitalWard)
                ) && 
                (
                    AppointmentDate == other.AppointmentDate ||
                    AppointmentDate != null &&
                    AppointmentDate.Equals(other.AppointmentDate)
                ) && 
                (
                    AppointmentTimeStart == other.AppointmentTimeStart ||
                    AppointmentTimeStart != null &&
                    AppointmentTimeStart.Equals(other.AppointmentTimeStart)
                ) && 
                (
                    AppointmentTimeEnd == other.AppointmentTimeEnd ||
                    AppointmentTimeEnd != null &&
                    AppointmentTimeEnd.Equals(other.AppointmentTimeEnd)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Disease != null)
                    hashCode = hashCode * 59 + Disease.GetHashCode();
                    if (DiseaseSeverity != null)
                    hashCode = hashCode * 59 + DiseaseSeverity.GetHashCode();
                    if (IsHospitalized != null)
                    hashCode = hashCode * 59 + IsHospitalized.GetHashCode();
                    if (HospitalWard != null)
                    hashCode = hashCode * 59 + HospitalWard.GetHashCode();
                    if (AppointmentDate != null)
                    hashCode = hashCode * 59 + AppointmentDate.GetHashCode();
                    if (AppointmentTimeStart != null)
                    hashCode = hashCode * 59 + AppointmentTimeStart.GetHashCode();
                    if (AppointmentTimeEnd != null)
                    hashCode = hashCode * 59 + AppointmentTimeEnd.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Patient left, Patient right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Patient left, Patient right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}

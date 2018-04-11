using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class Person: PersonBase
    {
        public string Salutation { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public int? EthnicityId { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Instagram { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public StateProvince State { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public int UserId { get; set; }
        public string MotherGuardianName { get; set; }
        public string MGHomePhone { get; set; }
        public string MGMobilePhone { get; set; }
        public string MGWorkPhone { get; set; }
        public string MGEmail { get; set; }
        public bool? MGEmergencyContact { get; set; }
        public string FatherGuardianName { get; set; }
        public string FGHomePhone { get; set; }
        public string FGMobilePhone { get; set; }
        public string FGWorkPhone { get; set; }
        public string FGEmail { get; set; }
        public bool? FGEmergencyContact { get; set; }
        public string MaritalStatus { get; set; }
        public int? ChildrenNumber { get; set; }
        public int? ChildrenLiveWithPerson { get; set; }
        public string MedicationTypes { get; set; }
        public string AllergyTypes { get; set; }
        public List<PersonPhoto> Photos { get; set; }
        public List<Personality> PersonalityTraits { get; set; }
        public int? SchoolId { get; set; }
        public int? CompanyId { get; set; }
        public string CurrentGradeYear { get; set; }
        public string TeacherCounselor { get; set; }
        public string TeacherCounselorPhone { get; set; }
        public int? SchoolCredits { get; set; }
        public int? EducationPlanId { get; set; }
        public int? EducationLevelId { get; set; }
        public string ActivityName { get; set; }
        public string ClubName { get; set; }
        public string CoachTeacher { get; set; }
        public string CoachTeacherPhone { get; set; }
        public string WorkPlaceName { get; set; }
        public string WorkPlaceAddress { get; set; }
        public int? RateFutureOutlook { get; set; }
        public int? RateFriend { get; set; }
        public int? RateOpportunities { get; set; }
        public int? RateProblems { get; set; }
        public int? RateCommunity { get; set; }
        public int? RateJob { get; set; }
        public int? RateLive { get; set; }
        public int? RateFuturePlans { get; set; }

        public bool IsEmailConfirmed { get; set; }
        
    }
}
using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Services
{

    public class UserService : IUserService
    {
        private IDataProvider _prov;

        public UserService(IDataProvider prov)
        {
            _prov = prov;
        }
        //public int LoginUser(LoginRequest model)
        //{
        //    int Id = 0;
        //    _prov.ExecuteNonQuery("dbo.Users_Insert",
        //        inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //        {
        //            paramCollection.AddWithValue("@Email", model.Email);
        //            paramCollection.AddWithValue("@Password", model.Password);
        //            SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int);
        //            idParam.Direction = ParameterDirection.Output;
        //            paramCollection.Add(idParam);
        //        }, returnParameters: delegate (SqlParameterCollection param)
        //    {
        //        Int32.TryParse(param["@Id"].Value.ToString(), out Id);
        //    }
        //    );
        //    return Id;

        //}

        public User GetUserById(int id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnString"].ConnectionString))
            {
                User u = new User();
                _prov.ExecuteCmd("dbo.User_SelectById",
                    inputParamMapper: delegate (SqlParameterCollection paramCollection)
                    {
                        paramCollection.AddWithValue("@Id", id);
                    },

               singleRecordMapper: delegate (IDataReader rdr, short set)
                    {
                        switch (set)
                        {
                            case 0:
                                int ord = 0;

                                u.Id = rdr.GetSafeInt32(ord++);
                                u.FirstName = rdr.GetSafeString(ord++);
                                u.LastName = rdr.GetSafeString(ord++);
                                u.DBO = rdr.GetSafeDateTime(ord++);
                                u.Age = rdr.GetSafeInt32(ord++);
                                u.Sex = rdr.GetSafeString(ord++);
                                u.Email = rdr.GetSafeString(ord++);
                                //-------------------Job-------------
                                u.Job = new Job();
                                u.Job.Id = rdr.GetSafeInt32(ord++);
                                u.Job.JobStatus = rdr.GetSafeString(ord++);
                                u.Job.JobTitle = rdr.GetSafeString(ord++);
                                u.Job.Industry = rdr.GetSafeString(ord++);
                                u.Job.YearsExperience = rdr.GetSafeInt32(ord++);
                                //-------------------Personality------------
                                u.Personality = new Personality();
                                u.Personality.Id = rdr.GetSafeInt32(ord++);
                                u.Personality.MBTI = rdr.GetSafeString(ord++);
                                u.Personality.Role = rdr.GetSafeString(ord++);
                                u.Personality.Strategy = rdr.GetSafeString(ord++);
                                //-------------------LoveLife-------------
                                u.LoveLife = new LoveLife();
                                u.LoveLife.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.UserId = rdr.GetSafeInt32(ord++);
                                //-------------------Relationship Status
                                u.LoveLife.RelationshipStatus = new RelationshipStatus();
                                u.LoveLife.RelationshipStatus.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.RelationshipStatus.Status = rdr.GetSafeString(ord++);
                                u.LoveLife.LengthOfStatus = rdr.GetSafeInt32(ord++);

                                //------------------Love Making Preference---------
                                u.LoveLife.LoveMakingPreference = new LoveMakingPreference();
                                u.LoveLife.LoveMakingPreference.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.LoveMakingPreference.Preference = rdr.GetSafeString(ord++);
                                u.LoveLife.LoveMakingPreference.Description = rdr.GetSafeString(ord++);


                                //-------------------LoveLife Partner-------------
                                u.LoveLife.Partner = new Partner();
                                u.LoveLife.Partner.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Age = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Sex = rdr.GetSafeString(ord++);
                                //-------------------LoveLife Partner Job-------------
                                u.LoveLife.Partner.Job = new Job();
                                u.LoveLife.Partner.Job.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Job.JobStatus = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.JobTitle = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.Industry = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.YearsExperience = rdr.GetSafeInt32(ord++);
                                //-------------------LoveLife Partner Personality-------------
                                u.LoveLife.Partner.Personality = new Personality();
                                u.LoveLife.Partner.Personality.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Personality.MBTI = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Personality.Role = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Personality.Strategy = rdr.GetSafeString(ord++);

                                break;
                            default:
                                break;
                        }
                    });
                return u;
            }

        }
        public int UpdateUser(int id, UpdateUserRequest user)
        {
            _prov.ExecuteNonQuery("dbo.User_Update",
                inputParamMapper: delegate (SqlParameterCollection parameterCollection)
                {
                    parameterCollection.AddWithValue("@Id", id);
                    parameterCollection.AddWithValue("@FirstName", user.FirstName);
                    parameterCollection.AddWithValue("@LastName", user.LastName);
                    parameterCollection.AddWithValue("@Age", user.Age);
                    parameterCollection.AddWithValue("@Sex", user.Sex);
                    parameterCollection.AddWithValue("@DBO", user.DBO);
                    parameterCollection.AddWithValue("@Email", user.Email);
                    parameterCollection.AddWithValue("@Password", user.Password);

                    parameterCollection.AddWithValue("@UserPersonalityId", user.Personality.Id);

                    parameterCollection.AddWithValue("@UserJobId", user.Job.Id);
                    parameterCollection.AddWithValue("@UserJobStatus", user.Job.JobStatus);
                    parameterCollection.AddWithValue("@UserJobTitle", user.Job.JobTitle);
                    parameterCollection.AddWithValue("@UserJobIndustry", user.Job.Industry);
                    parameterCollection.AddWithValue("@UserJobYearsExperience", user.Job.YearsExperience);


                    parameterCollection.AddWithValue("@LoveLifeId", user.LoveLife.Id);
                    parameterCollection.AddWithValue("@LoveLifeLengthOfStatus", user.LoveLife.LengthOfStatus);
                    parameterCollection.AddWithValue("@LoveLifeRelationshipStatusId", user.LoveLife.RelationshipStatus.Id);
                    parameterCollection.AddWithValue("@LoveLifeRelationshipStatus", user.LoveLife.RelationshipStatus.Status);


                    //-------------------LoveLife Partner-------------
                    parameterCollection.AddWithValue("@PartnerId", user.LoveLife.Partner.Id);
                    parameterCollection.AddWithValue("@PartnerAge", user.LoveLife.Partner.Age);
                    parameterCollection.AddWithValue("@PartnerSex", user.LoveLife.Partner.Sex);

                    //-------------------LoveLife Partner Job-------------


                    parameterCollection.AddWithValue("@PartnerJobId", user.LoveLife.Partner.Job.Id);

                    parameterCollection.AddWithValue("@PartnerJobStatus", user.LoveLife.Partner.Job.JobStatus);
                    parameterCollection.AddWithValue("@PartnerJobTitle", user.LoveLife.Partner.Job.JobTitle);
                    parameterCollection.AddWithValue("@PartnerJobIndustry", user.LoveLife.Partner.Job.Industry);
                    parameterCollection.AddWithValue("@PartnerJobYearsExperience", user.LoveLife.Partner.Job.YearsExperience);

                    //-------------------LoveLife Partner Personality-------------
                    parameterCollection.AddWithValue("@PartnerPersonalityId", user.LoveLife.Partner.Personality.Id);


                    //------------------Love Making Preference-----------------

                    parameterCollection.AddWithValue("@LoveMakingPreferenceId", user.LoveLife.LoveMakingPreference.Id);

                    parameterCollection.AddWithValue("@LoveMakingPreference", user.LoveLife.LoveMakingPreference.Preference);
                    parameterCollection.AddWithValue("@LoveMakingPreferenceDescription", user.LoveLife.LoveMakingPreference.Description);


                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    Int32.TryParse(param["@Id"].Value.ToString(), out id);
                }
            );
            return id;
        }

        public List<User> GetUsers()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnString"].ConnectionString))
            {
                List<User> listOfUsers = new List<User>();
                _prov.ExecuteCmd("dbo.Users_SelectAll",
                    inputParamMapper: null,
                    singleRecordMapper: delegate (IDataReader rdr, short set)
                    {
                        switch (set)
                        {
                            case 0:
                                int ord = 0;

                                User u = new User();
                                u.Id = rdr.GetSafeInt32(ord++);
                                u.FirstName = rdr.GetSafeString(ord++);
                                u.LastName = rdr.GetSafeString(ord++);
                                u.DBO = rdr.GetSafeDateTime(ord++);
                                u.Age = rdr.GetSafeInt32(ord++);
                                u.Sex = rdr.GetSafeString(ord++);
                                u.Email = rdr.GetSafeString(ord++);
                                //-------------------Job-------------
                                u.Job = new Job();
                                u.Job.Id = rdr.GetSafeInt32(ord++);
                                u.Job.JobStatus = rdr.GetSafeString(ord++);
                                u.Job.JobTitle = rdr.GetSafeString(ord++);
                                u.Job.Industry = rdr.GetSafeString(ord++);
                                u.Job.YearsExperience = rdr.GetSafeInt32(ord++);
                                //-------------------Personality------------
                                u.Personality = new Personality();
                                u.Personality.Id = rdr.GetSafeInt32(ord++);
                                u.Personality.MBTI = rdr.GetSafeString(ord++);
                                u.Personality.Role = rdr.GetSafeString(ord++);
                                u.Personality.Strategy = rdr.GetSafeString(ord++);
                                //-------------------LoveLife-------------
                                u.LoveLife = new LoveLife();
                                u.LoveLife.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.UserId = rdr.GetSafeInt32(ord++);
                                //-------------------Relationship Status
                                u.LoveLife.RelationshipStatus = new RelationshipStatus();
                                u.LoveLife.RelationshipStatus.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.RelationshipStatus.Status = rdr.GetSafeString(ord++);
                                u.LoveLife.LengthOfStatus = rdr.GetSafeInt32(ord++);
                                //-------------------LoveLife Partner-------------
                                u.LoveLife.Partner = new Partner();
                                u.LoveLife.Partner.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Age = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Sex = rdr.GetSafeString(ord++);
                                //-------------------LoveLife Partner Job-------------
                                u.LoveLife.Partner.Job = new Job();
                                u.LoveLife.Partner.Job.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Job.JobStatus = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.JobTitle = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.Industry = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Job.YearsExperience = rdr.GetSafeInt32(ord++);
                                //-------------------LoveLife Partner Personality-------------
                                u.LoveLife.Partner.Personality = new Personality();
                                u.LoveLife.Partner.Personality.Id = rdr.GetSafeInt32(ord++);
                                u.LoveLife.Partner.Personality.MBTI = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Personality.Role = rdr.GetSafeString(ord++);
                                u.LoveLife.Partner.Personality.Strategy = rdr.GetSafeString(ord++);
                                listOfUsers.Add(u);

                                break;
                            default:
                                break;
                        }
                    });
                return listOfUsers;



                //List<User> l = null;
                //SqlCommand comm = new SqlCommand("dbo.Users_SelectAll", con);
                //comm.CommandType = System.Data.CommandType.StoredProcedure;
                //con.Open();
                ////comm.ExecuteNonQuery();
                //var reader = comm.ExecuteReader();
                //List<User> listOfUsers = new List<User>();
                //User u;
                //while (reader.Read())
                //{
                //    u = new User();
                //    u.Id = (int)reader["Id"];
                //    u.FirstName = (string)reader["FirstName"];
                //    u.LastName = (string)reader["LastName"];
                //    u.DBO = (DateTime)reader["DBO"];
                //    u.Age = (int)reader["Age"];
                //    u.Sex = (string)reader["Sex"];
                //    u.JobId = (Job)reader["JobId"];
                //    u.LoveLifeId = (LoveLife)reader["LoveLifeId"];
                //    u.Personality = (string)reader["Personality"];
                //    listOfUsers.Add(u);
            }



        }
    }

}

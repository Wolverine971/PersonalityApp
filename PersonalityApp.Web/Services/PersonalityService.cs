using PersonalityApp.Web.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Services
{
    public class PersonalityService: IPersonalityService
    {
        public void SetPersonality(int UserId, string Personality)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                con.Open();

                SqlCommand comm = new SqlCommand("SetPersonality", con);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@UserId", UserId);
                comm.Parameters.AddWithValue("@Personality", Personality);
                comm.ExecuteNonQuery();

            }
        }
        public User GetPersonality(int UserId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
            {
                con.Open();

                User u = null;
                SqlCommand comm = new SqlCommand("GetPersonality", con);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@UserId", UserId);
                comm.ExecuteNonQuery();
                using (var reader = comm.ExecuteReader())
                {
                    u = new User();
                    u.Personality = (Personality)reader["Personality"];
                }

                return u;


            }

        }
    }
}
using PersonalityApp.Web.Domain;

namespace PersonalityApp.Web.Services
{
    public interface IPersonalityService
    {
        void SetPersonality(int UserId, string Personality);
        User GetPersonality(int UserId);
    }
}
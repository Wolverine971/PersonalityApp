using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityApp.Web.Services
{
    public class SecurityTokenService
    {
        private IDataProvider _prov;

        public SecurityTokenService(IDataProvider provider)
        {
            _prov = provider;
        }
        //Insert
        public Guid Insert(SecurityTokenAddRequest model)
        {
            Guid id = Guid.NewGuid();

            _prov.ExecuteNonQuery("dbo.SecurityToken_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@GUID", id);
                    paramCollection.AddWithValue("@UserEmail", model.UserEmail);
                    paramCollection.AddWithValue("@TokenTypeId", model.TokenTypeId);
                }
                );
            return id;
        }
        //SelectById
        public SecurityToken SelectById(Guid id)
        {
            SecurityToken singleItem = null;

            _prov.ExecuteCmd("dbo.SecurityToken_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@GUID", id);
                }
                , singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    singleItem = MapEquipment(reader);
                }
                );
            return singleItem;
        }
        //Update
        public void UpdateLinkStatus(SecurityTokenUpdateRequest model)
        {
            _prov.ExecuteNonQuery("dbo.SecurityToken_UpdateLinkStatus"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@GUID", model.GUID);
                });
        }
        //Helpers
        private static SecurityToken MapEquipment(IDataReader reader)
        {
            SecurityToken singleItem = new SecurityToken();
            int startingIndex = 0;

            singleItem.GUID = reader.GetGuid(startingIndex++);
            singleItem.UserEmail = reader.GetSafeString(startingIndex++);
            singleItem.TokenTypeId = reader.GetSafeInt32(startingIndex++);
            singleItem.DateCreated = reader.GetSafeUtcDateTime(startingIndex++);
            singleItem.LinkStatus = reader.GetSafeString(startingIndex++);
            return singleItem;
        }
    }
}

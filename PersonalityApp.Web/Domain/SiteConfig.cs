using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace PersonalityApp.Web.Domain
{
    public class SiteConfig
    {
        #region Properties

        public static string Environment
        {
            get { return GetFromConfig("Environment"); }
        }

        public static string SiteDomain
        {
            get { return GetFromConfig("SiteDomain"); }
        }

        public static string BaseUrl
        {
            get { return GetFromConfig("BaseURL"); }
        }

        public static string SiteAdminEmailAddress
        {
            get { return GetFromConfig("SiteAdminEmailAddress"); }
        }

        public static string SiteAdminSmsNumber
        {
            get { return GetFromConfig("SiteAdminSmsNumber"); }
        }

        public static string BrandName
        {
            get { return GetFromConfig("BrandName"); }
        }

        public static string BrandTagline
        {
            get { return GetFromConfig("BrandTagline"); }
        }

        public static string BrandLogo
        {
            get { return GetFromConfig("BrandLogo"); }
        }

        public static string BrandThumbnail
        {
            get { return GetFromConfig("BrandThumbnail"); }
        }

        public static string BrandDescription
        {
            get { return GetFromConfig("BrandDescription"); }
        }

        public static string AwsAccessKey
        {
            get { return GetFromConfig("AwsAccessKey"); }
        }

        public static string AwsSecretKey
        {
            get { return GetFromConfig("AwsSecretKey"); }
        }





        public static string AwsBucket
        {
            get { return GetFromConfig("AWSBucket"); }
        }

        public static string AwsBaseUrl
        {
            get { return GetFromConfig("AWSBaseUrl"); }
        }

        public static string AwsFolder
        {
            get { return GetFromConfig("AWSFolder"); }
        }

        public static string DefaultProfileFileKey
        {
            get { return GetFromConfig("DefaultProfileFileKey"); }
        }

        public static string AwsPrefix
        {
            get
            {
                return "//"
              + AwsBucket + "." + AwsBaseUrl + "/" + AwsFolder + "/";
            }
        }

        public static string GoogleMapsApiKey
        {
            get { return GetFromConfig("GoogleMapsApiKey"); }
        }

        public static string SendGridApiKey
        {
            get { return GetFromConfig("SendGridApiKey"); }
        }

        public static string TwilioAccountSid
        {
            get { return GetFromConfig("TwilioAccountSid"); }
        }

        public static string TwilioAuthToken
        {
            get { return GetFromConfig("TwilioAuthToken"); }
        }

        public static string TwilioPhoneNumber
        {
            get { return GetFromConfig("TwilioPhoneNumber"); }
        }

        public static string GetUrlForFile(string fileName)
        {
            return AwsPrefix + fileName;
        }

        #endregion

        #region Helper functions 

        private static string GetFromConfig(string key)
        {
            return WebConfigurationManager.AppSettings[key];
        }

        #endregion



    }
}
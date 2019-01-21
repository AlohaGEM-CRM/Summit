using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace SummitShopApp.Utility
{
    public class Description : Attribute
    {
        public string Text;
        public Description(string text)
        {
            Text = text;
        }
    }

    public class EnumUtility
    {
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);
                if (attrs != null && attrs.Length > 0)
                    return ((Description)attrs[0]).Text;
            }
            return en.ToString();
        }
    }

    public enum FromAppSection
    {
        [Description("Communication List")]
        CommunicationList = 1,
        [Description("Repair Opportunity List")]
        RepairOpportunity,
        [Description("New Repair Prospect")]
        NewRepairProspect,
        [Description("In Process")]
        Inprocess,
        [Description("Email Marketing")]
        EmailMarketing,
        [Description("Text Marketing")]
        TextMarketing,
        [Description("Customer Review and Ratings")]
        CustomerReviewNRating,
        [Description("Survey Comments")]
        SurveyComments
    }

    public enum phoneIdentifier
    {
        [Description("1")]
        Android = 1,
        [Description("2")]
        BlackBerry,
        [Description("3")]
        iPhone
    }
}

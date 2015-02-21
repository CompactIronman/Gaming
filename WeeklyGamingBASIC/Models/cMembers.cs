using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WeeklyGamingBASIC.Models
{
    [MetadataType(typeof(MembersMetaData))]
    public partial class Members
    {
         [Display(Name = "Players Name")]
        public string strFullName
        {
            get
            {
                return strFirstName + " " + strLastName;
            }
        }
    }
    public class MembersMetaData
    {
       
       
        [Display(Name = "First Name")]
        public string strFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string strLastName { get; set; }
    }
}
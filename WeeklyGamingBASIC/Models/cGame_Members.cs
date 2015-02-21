using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeeklyGamingBASIC.Models
{
    [MetadataType(typeof(Game_MembersMetaData))]
    public partial class Game_Members
    {

    }
    public class Game_MembersMetaData
    {
        [Display(Name = "Own this Game?")]
        public bool bitOwnGame { get; set; }
    }
}
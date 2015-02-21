using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeeklyGamingBASIC.Models
{
    [MetadataType(typeof(GamesMetaData))]
    public partial class Game
    {

    }
    public class GamesMetaData
    {
        [Display(Name = "Game Name")]
        public string strGameName { get; set; }
    }
}
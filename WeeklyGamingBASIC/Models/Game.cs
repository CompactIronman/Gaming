//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeeklyGamingBASIC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        public Game()
        {
            this.Game_Members = new HashSet<Game_Members>();
        }
    
        public int intGameID { get; set; }
        public string strGameName { get; set; }
        public int intProviderID { get; set; }
    
        public virtual ICollection<Game_Members> Game_Members { get; set; }
        public virtual Game_Providers Game_Providers { get; set; }
    }
}

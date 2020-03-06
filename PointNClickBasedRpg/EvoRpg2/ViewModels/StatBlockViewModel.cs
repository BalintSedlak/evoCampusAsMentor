using EvoRpg2.Models.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvoRpg2.ViewModels
{
    public class StatBlockViewModel
    {
        
        public PlayerStats PlayerStats { get; set; }
        public StatBlockViewModel(PlayerStats playerStats)
        {
            PlayerStats = playerStats;
        }
    }
}

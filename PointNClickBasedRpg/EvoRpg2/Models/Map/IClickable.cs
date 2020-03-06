using EvoRpg2.Services;
using EvoRpg2.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvoRpg2.Models.Map
{
    public interface IClickable
    {
        double ClickZoneStartX { get; set; }
        double ClickZoneStartY { get; set; }
        double ClickZoneEndX { get; set; }
        double ClickZoneEndY { get; set; }

        void DoWhenClicked(InGameButton inGameButton,GameCoreServices gameCoreServices);

    }
}

using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Text;
using System.Windows.Media;
using EvoRpg2.Models.Interfaces;

namespace EvoRpg2.Models.Map
{
    public class Location : IEntity
    {
        public string LocationName { get; set; }
        public ImageBrush Background { get; set; } = new ImageBrush();

        public List<IClickable> clickables = new List<IClickable>();

        public Location(BitmapImage bitmapimage,string locationName)
        {
            Background.ImageSource = bitmapimage;
            LocationName = locationName;
        }
    }
}

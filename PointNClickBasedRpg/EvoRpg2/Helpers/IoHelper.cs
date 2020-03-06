using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace EvoRpg2.Helpers
{
    public class IoHelper
    {
        /// <summary>
        /// Maps the <see cref="ImageLocation"/> enum to a realative path
        /// </summary>
        private Dictionary<ImageLocation, string> _imageLocationMap;

        public IoHelper()
        {
            _imageLocationMap = new Dictionary<ImageLocation, string>()
            {
                { ImageLocation.Inventory, "Resources/Images/Inventory" },
                { ImageLocation.Keyring, "Resources/Images/Inventory" },
                { ImageLocation.Sword, "Resources/Images/Inventory" },
                { ImageLocation.Key, "Resources/Images" },
                { ImageLocation.SilverKey, "Resources/Images" }
            };
        }

        /// <summary>
        /// Finds the given image file in the given location and returns it as a <see cref="BitmapImage"/>.
        /// </summary>
        /// <param name="imageLocation">Where is the image.</param>
        /// <param name="imageName">Image name without file extension.</param>
        /// <returns>Return with a <see cref="BitmapImage"/></returns>
        public BitmapImage GetBitmapImageByName(ImageLocation imageLocation, string imageName)
        {
            string imagePath = GetAbsoluteImagePath(_imageLocationMap[imageLocation], imageName);

            return new BitmapImage(new Uri(@$"pack://application:,,,/{imagePath}", UriKind.Absolute));
        }

        /// <summary>
        /// Performs a search in the given directory for the given file name.
        /// </summary>
        /// <param name="directoryPath">The directory where the search will be performed.</param>
        /// <param name="imageNameFilter">This parameter is used in the search pattern as a filter for the file name. Use this without the file extension.</param>
        /// <returns>Returns with the found file's absolute path.</returns>
        private string GetAbsoluteImagePath(string directoryPath, string imageNameFilter)
        {
            return Directory.GetFiles(directoryPath, $"{imageNameFilter}.*", SearchOption.TopDirectoryOnly)[0];
        }
    }
}

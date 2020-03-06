using System;
using System.Collections.Generic;
using EvoRpg2.Models.Interfaces;

namespace EvoRpg2.Helpers.DataAccess
{
    public class ContextHelper : IContextHelper
    {
        public List<T> LoadDataType<T>() where T : IEntity
        {
            //Load from file
            throw new NotImplementedException();
        }

        public void SaveDataType<T>(List<T> entities) where T : IEntity
        {
            //Save to file
            throw new NotImplementedException();
        }
    }
}

using EvoRpg2.Models.Interfaces;
using System.Collections.Generic;

namespace EvoRpg2.Helpers.DataAccess
{
    public interface IContextHelper
    {
        List<T> LoadDataType<T>() where T : IEntity;
        void SaveDataType<T>(List<T> entities) where T : IEntity;
    }
}

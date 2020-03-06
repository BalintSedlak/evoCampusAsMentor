using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EvoRpg2.Models.Items
{
    public class KeyRing
    {
        public List<String> Keys;

        public KeyRing()
        {
            Keys = new List<String>();
            
        }

        public void AddKey(String keyName)
        {
            Keys.Add(keyName);
            
        }
        public bool CheckKey(String keyName)
        {
            foreach (var key in Keys)
            {
                if (key==keyName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

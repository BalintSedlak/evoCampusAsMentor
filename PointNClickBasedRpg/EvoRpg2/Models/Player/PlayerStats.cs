using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;
using EvoRpg2.Models.Map;
using log4net;
using log4net.Config;

namespace EvoRpg2.Models.Player
{
    public class PlayerStats : INotifyPropertyChanged
    {
        public Location CurrentLocation { get; set; }
        private double health = 100;

        public double Health
        {
            get { return health; }
            set { health = value; NotifyPropertyChanged("DisplayHealth"); }
        }
        private double money=0;

        public double Money
        {
            get { return money; }
            set { money += value; NotifyPropertyChanged("DisplayMoney"); }
        }
        private double attackDamage=25;

        public double AttackDamage
        {
            get { return attackDamage; }
            set { attackDamage += value; NotifyPropertyChanged("DisplayAttackDamage"); }
        }
        private double armour=0;

        public double Armour
        {
            get { return armour; }
            set { armour += value; NotifyPropertyChanged("DisplayArmour"); }
        }


        public string DisplayHealth { get { return $"Health: {Health}";}}
        public string DisplayMoney { get { return $"Money: {Money}"; } }
        public string DisplayAttackDamage { get { return $"Damage: {AttackDamage}"; } }
        public string DisplayArmour { get { return $"Armour: {Armour}"; } }

        public PlayerStats()
        {

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

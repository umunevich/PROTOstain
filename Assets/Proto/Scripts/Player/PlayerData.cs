using UnityEngine;

namespace Proto.Scripts.Player
{
    using Tank;
    
    public class PlayerData
    {
        public class Config
        {
            public float Health;
            public float Money;
            public float MaxTankVolume;
        }
        
        public PlayerData(Config config)
        {
            _health = config.Health;
            _money = config.Money;
            _tank = new Tank(config.MaxTankVolume);
        }
        
        
        
        private float _health;
        private float _money;
        private Tank _tank;
    }
}

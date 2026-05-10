using System;
using Proto.Scripts.Item;
using UnityEngine;

namespace Proto.Scripts.Player
{
    using Item;
    
    public interface IPlayerAction
    {
        void Perform();
    }
    
    public class InteractPlayerAction : IPlayerAction
    {
        public class Config
        {
            public Transform CamTransform;
            public float Range;
            public Action Action;
        }
        
        public InteractPlayerAction(Config config) {
            _camTransform = config.CamTransform;
            _range = config.Range;
            _action = config.Action;
        }
        
        public void Perform()
        {
            Ray ray = new Ray(_camTransform.position, _camTransform.forward);
        
            if (Physics.Raycast(ray, out RaycastHit hit, _range))
            {
                if (hit.collider.TryGetComponent(out IPickable pickable))
                {
                    _action();
                    
                    pickable.OnPickUp();
                }
            }
        }
        
        private readonly Transform _camTransform;
        private readonly float _range;
        private readonly Action _action;
    }

}

using System;
using StarterAssets;
using UnityEngine;

namespace Proto.Scripts.Player
{
    [RequireComponent(typeof(StarterAssetsInputs))]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private Camera cam;
    
        private StarterAssetsInputs _input;
        private InteractPlayerAction _interactAction;

        private void Awake()
        {
            if (cam == null)
            {
                cam = Camera.main;
            }
            _input = GetComponent<StarterAssetsInputs>();
            _interactAction = new InteractPlayerAction(new InteractPlayerAction.Config()
            {
                CamTransform =  cam.transform,
                Range = range,
                Action = new Action(() =>  Debug.Log("Picked up"))
            });
            
            
        }

        public void Update()
        {
            if (_input.interact)
            {
                _interactAction.Perform();
                _input.interact = false;
            }
        }
    }
}
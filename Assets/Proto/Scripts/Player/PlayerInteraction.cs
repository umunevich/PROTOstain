using StarterAssets;
using UnityEngine;

namespace Proto.Scripts.Player
{
    [RequireComponent(typeof(StarterAssetsInputs),  typeof(Inventory))]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private Camera cam;
    
        private StarterAssetsInputs _input;

        private void Awake()
        {
            _input = GetComponent<StarterAssetsInputs>();
        
            if (cam == null)
            {
                cam = Camera.main;
            }
        }

        public void Update()
        {
            if (_input.interact)
            {
                TryInteract();
                _input.interact = false;
            }
        }

        private void TryInteract()
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                if (hit.collider.TryGetComponent(out Pickable pickable))
                {
                    //pickable.PickUp(_inventory);
                }
            }
        }
    }
}
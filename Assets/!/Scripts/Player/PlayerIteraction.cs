using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIteraction : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private Camera cam;
    
    private StarterAssetsInputs _input;
    private Inventory _inventory;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _inventory = GetComponent<Inventory>();
        
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
                pickable.PickUp(_inventory);
            }
        }
    }
}

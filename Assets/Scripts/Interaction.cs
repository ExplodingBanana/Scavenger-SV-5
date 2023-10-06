using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private Vector3 rayOrigin;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask interactionLayer;
    private Interactable currentInteractable = null;

    void Update()
    {
        if (Physics.Raycast(Camera.main.ViewportPointToRay(rayOrigin), out RaycastHit hit, distance))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interaction") && (currentInteractable == null || hit.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID())) // i hate this line
            {
                hit.collider.TryGetComponent<Interactable>(out currentInteractable);
                if (currentInteractable)
                {
                    currentInteractable.OnFocus();
                }                
            }
        }
        else if (currentInteractable)
        {
            currentInteractable.OnUnfocus();
            currentInteractable = null;
        }
        if (Input.GetMouseButtonDown(0) && currentInteractable) // dont forget to abstract controls!
        {
            currentInteractable.OnInteract();
        }
    }
}

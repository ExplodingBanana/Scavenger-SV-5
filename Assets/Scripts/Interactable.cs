using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Interaction"); // foolproofing
    }
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnUnfocus();
}

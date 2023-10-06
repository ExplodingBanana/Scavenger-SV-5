using UnityEngine;

public class ButtonInteractable : Interactable
{
	[SerializeField] private GameObject doorParent;
	[SerializeField] private bool open;
	[SerializeField] private Material focusMaterial;
	private Renderer rend;
	private Material baseMaterial;
	private int doorParentID;

    private void Start()
    {
        rend = GetComponent<Renderer>();
		baseMaterial = rend.material; // storing inactive material
		doorParentID = doorParent.gameObject.GetInstanceID();
    }

    // TODO: remake with shaders
    public override void OnFocus()
	{
		rend.material = focusMaterial;
    }

	public override void OnInteract()
	{
		if (open)
		{
            DoorEventSystem.instance.OnDoorOpen(doorParentID);
		}
		else
		{
            DoorEventSystem.instance.OnDoorClose(doorParentID);
		}
	}

	public override void OnUnfocus()
	{
		rend.material = baseMaterial; // hacky, doesn't always work
    }
}

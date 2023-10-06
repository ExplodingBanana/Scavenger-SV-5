using UnityEngine;

public class IsDoorOpen : MonoBehaviour
{
	private bool isOpen = false;
	[SerializeField] private Animator _animator;
	private int _instanceId;

	public bool IsOpen { get => isOpen; set => isOpen = value; } // might be useful for later

	private void Start()
	{
		_instanceId = transform.gameObject.GetInstanceID();

		// Registering events
		DoorEventSystem.instance.DoorOpen += OpenDoor;
		DoorEventSystem.instance.DoorClose += CloseDoor;
	}

	private void OpenDoor(int id)
	{
		if (id != _instanceId || isOpen) // if it's a wrong door or it's already open, don't open
		{
			return;
		}

		_animator.SetTrigger("open"); // why yes, moving doors with animations
        isOpen = true;
	}
	private void CloseDoor(int id)
	{
		if (id != _instanceId || !isOpen) // see above
		{
			return;
		}

		_animator.SetTrigger("close"); // i mean it works fine
        isOpen = false;
	}
}

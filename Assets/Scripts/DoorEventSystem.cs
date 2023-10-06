using System;
using UnityEngine;

public class DoorEventSystem : MonoBehaviour
{
	public static DoorEventSystem instance;

	private void Awake()
	{
		instance = this;
	}

	public event Action<int> DoorOpen;
	public event Action<int> DoorClose;

	public void OnDoorOpen(int instanceId)
	{
		DoorOpen?.Invoke(instanceId);
	}

	public void OnDoorClose(int instanceId)
	{
		DoorClose?.Invoke(instanceId);
	}
}

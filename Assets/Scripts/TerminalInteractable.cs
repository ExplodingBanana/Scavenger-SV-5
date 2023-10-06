using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerminalInteractable : Interactable
{
    [SerializeField] private Transform viewpoint;
    [SerializeField] private Rigidbody player;
    [SerializeField] private float duration;

    private float timeElapsed;
    

    // nah, doing shaders
    public override void OnFocus()
    {
    }

    // why?
    IEnumerator MoveToViewPoint()
    {
        float timeElapsed = 0;
        Vector3 startPosition = player.position;
        Quaternion startRotation = player.rotation;
        Quaternion cameraRotation = Camera.main.transform.rotation;
        while (timeElapsed < duration)
        {
            player.position = Vector3.Lerp(startPosition, viewpoint.position, timeElapsed / duration);
            player.rotation = Quaternion.Lerp(startRotation, viewpoint.rotation, timeElapsed / duration);
            Camera.main.transform.rotation = Quaternion.Lerp(cameraRotation, viewpoint.rotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        // to be sure
        player.position = viewpoint.position;
        player.rotation = viewpoint.rotation;
        Camera.main.transform.rotation = viewpoint.rotation;
    }

    public override void OnInteract()
    {
        KeyboardInput input = player.GetComponent<KeyboardInput>();
        MouseInput mouseInput = player.GetComponent<MouseInput>();
        // stripping player of control
        input.enabled = false;
        mouseInput.enabled = false; 
        StartCoroutine(MoveToViewPoint()); // because it's not in the Update and there is no Time.delta

        // UI interaction
        // ???
        // PROFIT
    }

    public override void OnUnfocus()
    {
        
    }
}

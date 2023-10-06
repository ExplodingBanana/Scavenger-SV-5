using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 0.06f;

    public void Move(Vector3 direction)
    {
        Vector3 offset = direction * _speed;

        _rigidBody.MovePosition((_rigidBody.position + offset)); // as simple as that
    }
}

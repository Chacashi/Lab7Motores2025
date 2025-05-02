using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody _compRigidbody;
    [SerializeField] private float speed;
    private Vector2 directionPlayer;
    

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        _compRigidbody.linearVelocity = new Vector3(directionPlayer.x*speed, _compRigidbody.linearVelocity.y, directionPlayer.y * speed);
    }


    private void OnEnable()
    {
        InputReader.OnPlayerMovement += SetDirection;
    }

    private void OnDisable()
    {
        InputReader.OnPlayerMovement -= SetDirection;
    }


    void SetDirection(Vector2 direction)
    {
        directionPlayer = new Vector2(direction.x, direction.y);
    }

   



}




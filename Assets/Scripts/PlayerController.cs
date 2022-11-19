using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private Camera _followCamera;
    public float movespeed = 5f;
    public float gravity = -20;
    public float rotationSpeed = 5;

    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movementDirection = input.normalized;

        if(movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
        movementDirection.y += gravity * Time.deltaTime;
        _controller.Move(movementDirection * movespeed * Time.deltaTime);
    }

    
}

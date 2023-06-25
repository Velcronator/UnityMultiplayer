using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    [SerializeField] InputReader inputReader;

    void Start()
    {
        inputReader.MoveEvent += HandleOnMove;
        inputReader.PrimaryFireEvent += HandleOnFire;
    }

    private void OnDestroy()
    {
        inputReader.MoveEvent -= HandleOnMove;
        inputReader.PrimaryFireEvent -= HandleOnFire;
    }

    private void HandleOnFire(bool fire)
    {
        Debug.Log(fire);
    }

    private void HandleOnMove(Vector2 movement)
    {
        Debug.Log(movement);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Aerith thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    void Start() {
        thePlayer = FindObjectOfType<Aerith>();
        lastPlayerPosition = thePlayer.transform.position;
        
    }
    

    void Update() {

        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = thePlayer.transform.position;
    }
}

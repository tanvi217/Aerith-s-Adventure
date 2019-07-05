﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;
    
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomGhostThreshold;
    public ObjectPooler ghostPool;

    private float screenWidth;

    void Start() {
        platformWidths = new float[theObjectPools.Length];

        for(int i = 0; i < theObjectPools.Length; i++) {

            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }
    

    void Update() {
        if(transform.position.x < generationPoint.position.x) {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 100f) < randomCoinThreshold) {
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomGhostThreshold)
            {
                GameObject newGhost = ghostPool.GetPooledObject();

                float ghostXPosition = Random.Range( -platformWidths[platformSelector] / 2, platformWidths[platformSelector] / 2);

                float ghostYPosition = Random.Range(-1.5f, 1.5f);

                Vector3 ghostPosition = new Vector3(ghostXPosition, ghostYPosition, 0f);

                newGhost.transform.position = transform.position + ghostPosition;
                newGhost.transform.rotation = transform.rotation;
                newGhost.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, transform.position.y, transform.position.z);

        }
        
    }
}

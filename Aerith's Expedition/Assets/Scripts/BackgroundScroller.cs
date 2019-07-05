using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour{

    public float speed;
    Vector3 startPosition;
    Vector3 direction = new Vector3(-1, 0, 0);

    void Start(){

        startPosition = transform.position;

    }

    
    void Update(){

        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x <= -24.25)
        {
            transform.position = startPosition;

        }
    }

    /*private GameManagerScript gameManager;
    private MeshRenderer meshRenderer;
    private Material backgroundMaterial;
    private Vector2 offset;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
        meshRenderer = this.GetComponent<MeshRenderer>();
        backgroundMaterial = meshRenderer.material;
    }

    private void FixedUpdate()
    {
        if (gameManager.gameRunning)
        {
            offset = backgroundMaterial.mainTextureOffset;

            if (gameManager.boost)
            {
                offset.y += Time.deltaTime / 1.5f;
            }
            else
            {
                offset.y += Time.deltaTime / 10f;
            }

            backgroundMaterial.mainTextureOffset = offset;
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBackground : MonoBehaviour
{
    public Vector3 startPos;
    private moveCharacter playerControllerScript;
    private float speed;
    public float repeatWidth;
    void Start()
    {
        this.speed = 10;
        startPos = transform.position;
        playerControllerScript = GameObject.Find("player").GetComponent<moveCharacter>();
        //Calculamos el punto medio del background
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    void Update()
    {
        if (!playerControllerScript.gameOver && !(transform.position.x > startPos.x + repeatWidth))
        {
            if (Input.GetKey(KeyCode.F))
            {
                this.speed = 20;
            }
            else
            {
                this.speed = 10;
            }
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //Cuando llegamos al punto medio, desplazamos
        else if (transform.position.x > startPos.x + repeatWidth)
        {
            transform.position = startPos;
        }
    }
}

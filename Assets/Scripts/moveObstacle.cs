using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float speed;
    private moveCharacter playerControllerScript;
    void Start()
    {
        this.speed = 10;
        playerControllerScript = GameObject.Find("player").GetComponent<moveCharacter>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver && obstaclePrefab.transform.position.x < 25){
            if(Input.GetKey(KeyCode.F)){
                this.speed = 20;
            }else{
                this.speed = 10;
            }
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (obstaclePrefab.transform.position.x > 25){
            Destroy(obstaclePrefab);
        }
    }
}

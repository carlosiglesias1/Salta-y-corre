using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(0, 0, 2.88f);
    private float startDelay = 2f;
    private float repeatRate = 2f;
    private moveCharacter playerControllerScript;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        System.Random random = new System.Random();
        int obstacleIndex = random.Next(obstaclePrefab.Length);
        Debug.Log(obstaclePrefab.Length);
        Debug.Log(obstacleIndex);
        Instantiate<GameObject>(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        playerControllerScript = GameObject.Find("player").GetComponent<moveCharacter>();
    }
    void SpawnObstacle()
    {
        int obstacleIndex;
        if (!playerControllerScript.gameOver)
        {
            System.Random random = new System.Random();
            obstacleIndex = random.Next(obstaclePrefab.Length);
            Debug.Log(obstacleIndex);
            if (obstacleIndex == 4)
                spawnPos = new Vector3(0f, +1.550001f, 2.88f);
            Instantiate<GameObject>(obstaclePrefab[obstacleIndex], spawnPos, obstaclePrefab[obstacleIndex].transform.rotation);
        }
    }
}

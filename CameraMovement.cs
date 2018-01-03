using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    Vector3 playerPos;
    Vector3 cameraStartPos;
    float xDistance;
    float yDistance;
    float zDistance;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float xMoveToPlayer;
    [SerializeField]
    float yMoveToPlayer;
    [SerializeField]
    float zMoveToPlayer;
    [SerializeField]
    float xMoveToEnemy;
    [SerializeField]
    float yMoveToEnemy;
    [SerializeField]
    float zMoveToEnemy;
    [SerializeField]
    float xMoveToStart;
    [SerializeField]
    float yMoveToStart;
    [SerializeField]
    float zMoveToStart;
    bool move;
    bool player;
    bool enemy;
    bool start;

    void Start () {
        cameraStartPos = transform.position;
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        move = false;
        player = true;
        enemy = false;
        start = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            move = !move;
            Debug.Log(move);
        }

        if (move)
        {
            MoveCamera();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = cameraStartPos;
            player = true;
            enemy = false;
            start = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player)
            {
                player = false;
                enemy = true;
                start = false;
            }
            else if (enemy)
            {
                player = false;
                enemy = false;
                start = true;
            }
            else if (start)
            {
                player = true;
                enemy = false;
                start = false;
            }
        }
    }

    void MoveCamera()
    {
        if (player)
        {
            transform.position = new Vector3(transform.position.x + (xMoveToPlayer * Time.deltaTime * moveSpeed), transform.position.y + (yMoveToPlayer * Time.deltaTime * moveSpeed), transform.position.z + (zMoveToPlayer * Time.deltaTime * moveSpeed));
        }
        
        if (enemy)
        {
            transform.position = new Vector3(transform.position.x + (xMoveToEnemy * Time.deltaTime * moveSpeed), transform.position.y + (yMoveToEnemy * Time.deltaTime * moveSpeed), transform.position.z + (zMoveToEnemy * Time.deltaTime * moveSpeed));
        }

        if (start)
        {
            transform.position = new Vector3(transform.position.x + (xMoveToStart * Time.deltaTime * moveSpeed), transform.position.y + (yMoveToStart * Time.deltaTime * moveSpeed), transform.position.z + (zMoveToStart * Time.deltaTime * moveSpeed));
        }
    }
}

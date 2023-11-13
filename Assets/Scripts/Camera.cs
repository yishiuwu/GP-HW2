using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    float playerPosZ;
    Vector3 pos;

    public float y_bias = 8.0f;
    public float z_bias = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerPosZ = player.transform.position.z;
        pos = new Vector3(player.transform.position.x, player.transform.position.y + y_bias, player.transform.position.z + z_bias);
        transform.position = pos;
        // transform.rotation = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        playerPosZ = player.transform.position.z;
        pos = new Vector3(transform.position.x, transform.position.y, playerPosZ + z_bias);
        transform.position = pos;

        Debug.Log(playerPosZ);
        Debug.Log(pos);
    }
}

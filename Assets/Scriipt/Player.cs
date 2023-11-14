using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    public float moveSpeed = 5f;
    public float forwardSpeed = 10.0f;
    public float backwardSpeed = 10.0f;
    public float rotateSpeed = 2.0f;
    private Rigidbody rb;

    private int idleState;
    private int runState;
    private int attackState;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        

        // Get Input using the new Input System
        float v = Keyboard.current.wKey.isPressed ? 1.0f : (Keyboard.current.sKey.isPressed ? -1.0f : 0.0f);
        float h = Keyboard.current.aKey.isPressed ? -1.0f : (Keyboard.current.dKey.isPressed ? 1.0f : 0.0f);

        

        Vector3 velocity = new Vector3(0.0f, 0.0f, v);

        // Transform
        gameObject.transform.Rotate(0, h * rotateSpeed, 0);

        if (v < -0.1)
        {
            //gameObject.transform.Translate(velocity * backwardSpeed * Time.fixedDeltaTime);
        }
        else if (v > 0.1)
        {
            gameObject.transform.Translate(velocity * forwardSpeed * Time.fixedDeltaTime);
        }

        
    }
}
//-------------------------------------------------
//Origin code in Update(){}
//  // 獲取方向輸入
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");

//         // 計算移動方向
//         Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

//         // 計算移動量並應用到玩家位置
//         Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;
//         transform.Translate(moveAmount);

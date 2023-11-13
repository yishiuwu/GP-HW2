using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerOWO : MonoBehaviour
{
    public int moveSpeed = 8;
    public int LRSpeed = 3;

    float x = 0.0f;
    float y = 0.0f;
    Vector3 direction;
    GameObject man;
    Rigidbody rb;
    Vector3 iniPos;
    Quaternion iniRotation;
    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        iniPos = transform.position;
        iniRotation = transform.rotation;
        man = gameObject;
        // animator = man.GetComponent<Animator>();
        rb = man.GetComponent<Rigidbody>();
        
        Vector3 angle;
        angle = transform.eulerAngles;
        x = angle.y;
        y = angle.x;
    }

    // Update is called once per frame
    void Update()
    {
        x += Input.GetAxis("Mouse X") * 4;

        Quaternion rotation = Quaternion.Euler(y, x, 0.0f);

        transform.rotation = rotation;


        // if(Input.GetKeyDown(KeyCode.Space)){
        //     print(rb.velocity);
        //     if(Mathf.Abs(rb.velocity.y) < 0.01f){
        //         print("jump");
        //         rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 300);
        //     }
        // }
    }

    void FixedUpdate(){
        bool isWalking = false;

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
            isWalking = true;
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * LRSpeed * Time.fixedDeltaTime);
            isWalking = true;
        }
            
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * LRSpeed * Time.fixedDeltaTime);
            isWalking = true;
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * LRSpeed * Time.fixedDeltaTime);
            isWalking = true;
        }
            
        // animator.SetBool("Walking", isWalking);
    }

    void OnCollisionEnter(Collision CollisionObject){
        Debug.Log("C " + gameObject.name + " : " + CollisionObject.gameObject.name);
        if(CollisionObject.gameObject.tag == "Trap"){
            print("GG");
            reStart();
        }
    }

    void OnTriggerEnter(Collider TriggerObject){
        print("T " + gameObject.name + " : " + TriggerObject.gameObject.name);
        if(TriggerObject.gameObject.tag == "Trap"){
            print("GG");
            reStart();
        }
    }

    void reStart(){
        StartCoroutine(DelayedTeleport(3.0f));
    }

    // 協程，延遲一定時間後執行傳送
    IEnumerator DelayedTeleport(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        // 在延遲之後執行的傳送操作
        Teleport();
    }

    void Teleport()
    {
        transform.position = iniPos;
        transform.rotation = iniRotation;
    }
}

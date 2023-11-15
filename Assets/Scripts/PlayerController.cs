using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    // public float rotateSpeed = 2.0f;
    private Animator animator;
    private Rigidbody rb;

    private int idleState;
    private int runState;
    private int attackState;
    public AudioClip HurtSound;
    private AudioSource myAudioSource;
    public GameObject blood;
    public GameObject bomb;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        idleState = Animator.StringToHash("Base Layer.Idle");
        runState = Animator.StringToHash("Base Layer.Run");
        attackState = Animator.StringToHash("Base Layer.Attack");
        myAudioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        // Get Input using the new Input System
        float v = Keyboard.current.wKey.isPressed ? 1.0f * speed : (Keyboard.current.sKey.isPressed ? -1.0f * speed : 0.0f);
        float h = Keyboard.current.aKey.isPressed ? -1.0f * speed : (Keyboard.current.dKey.isPressed ? 1.0f * speed : 0.0f);


        Vector3 velocity = new Vector3(h, 0.0f, v);
        animator.SetFloat("Speed", velocity.magnitude);

        // Transform
        // gameObject.transform.Rotate(0, h * rotateSpeed, 0);
        // transform.Translate(velocity * Time.fixedDeltaTime);
        rb.velocity = velocity;
        Quaternion rotate = velocity.magnitude==0 ? transform.rotation : Quaternion.LookRotation(velocity);
        transform.SetPositionAndRotation(transform.position, rotate);

        if (state.fullPathHash == runState)
        {
            if (Keyboard.current.spaceKey.isPressed)
            {
                animator.SetBool("Attack", true);
                GameObject obj = Instantiate(bomb,transform.position,transform.rotation);
                Destroy(obj,5f);
                // Check for nearby enemies and destroy them
                DestroyNearbyEnemies();
            }
        }
        else if (state.fullPathHash == attackState)
        {
            animator.SetBool("Attack", false);
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Enemy"){
            //Booming = true;
            //GetComponent<Animator>().SetTrigger("attack01");
            myAudioSource.PlayOneShot(HurtSound);
            GameObject obj = Instantiate(blood,transform.position,transform.rotation);
            Destroy(obj,5f);
            //StartCoroutine(SelfDestroy());
        }

    }

    void DestroyNearbyEnemies()
{
    // Define the attack range
    float attackRange = 3.0f;

    // Find all colliders within the attack range
    Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);

    foreach (Collider col in colliders)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // Destroy the enemy
            Destroy(col.gameObject);

            // Play a sound or perform other actions if needed
            // For example, you can instantiate a blood effect
            // GameObject bloodObj = Instantiate(blood, col.transform.position, col.transform.rotation);
            // Destroy(bloodObj, 5f);
        }
    }
}
}

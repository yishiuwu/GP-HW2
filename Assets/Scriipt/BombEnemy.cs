using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : MonoBehaviour
{
    public GameObject player;
    public float detectRadius = 10f;
    public float cdTime = 3f;
    public float moveSpeed = 5f;
    public AudioClip BombSound;
    private AudioSource myAudioSource;
    private bool isDashing = false;
    private Vector3 moveDirection;
    private bool Booming = false;
    
    public float subHP = -15;
    public event System.Action hurtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.zero;
        myAudioSource = GetComponent<AudioSource>();
        hurtPlayer += () => {player.GetComponent<PlayerController>().Hurt();};
        hurtPlayer += () => {PlayerStateControl.AddPlayerHP(subHP);};
    }

    // Update is called once per frame
    void Update()
    {
        DetectAndDash();

        if(isDashing){
            moveDirection = (player.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = targetRotation;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime,Space.World);//沒有space.world就會在某方向上遠離player
            if(!Booming)GetComponent<Animator>().SetBool("walk", true);
        }
        if(!isDashing || Booming) GetComponent<Animator>().SetBool("walk", false);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer > 30f) isDashing = false;

        
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){
            Booming = true;
            moveSpeed = 6f;
            GetComponent<Animator>().SetTrigger("attack01");
            AudioSystem.PlaySE(BombSound);
            StartCoroutine(SelfDestroy());
        }

    }
    private void DetectAndDash(){
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < detectRadius){
            // Debug.Log("Detected player");
            if(!isDashing){
                // Vector3 temp = new Vector3(player.transform.position.x - transform.position.x, 0f, player.transform.position.z - transform.position.z);
                // moveDirection = temp.normalized;

                // moveDirection = (player.transform.position - transform.position).normalized;
                // dashDestination = transform.position + directionToPlayer * dashDistance;
                isDashing = true;
                // Debug.Log("start Move Direction is:");
                // Debug.Log(moveDirection);
                StartCoroutine( WaitForCD()); 
            }
               
        }
    }
    
    private IEnumerator WaitForCD()
    {
        yield return new WaitForSeconds(cdTime);
        isDashing = false;
    }
    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        hurtPlayer?.Invoke();
    }
}

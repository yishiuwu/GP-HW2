using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    [SerializeField] float walktime = 5f;
    public float detectRadius = 5f;
    public AudioClip AttackSound;
    private AudioSource myAudioSource;
    private Vector3 moveDirection;
    private bool isDashing = false;
    private float direction = 1f;
    private float distance = 0f;
    public GameObject blood;

    public float subHP = -10;
    public event System.Action hurtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        GetComponent<Animator>().SetBool("walk", true);
        hurtPlayer += () => {player.GetComponent<PlayerController>().Hurt();};
        hurtPlayer += () => {PlayerStateControl.AddPlayerHP(subHP);};
    }

    // Update is called once per frame
    void Update()
    {
        
        DetectAndDash();
        if(isDashing){
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = targetRotation;
            transform.Translate(moveDirection * 5 * moveSpeed * Time.deltaTime,Space.World);
            
        }else{
            distance+=Time.deltaTime;
            transform.Translate(0,0,moveSpeed*Time.deltaTime);
            if(distance > walktime){
                distance = 0;
                if(direction==1f){
                    direction = -1f;
                    gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                }else{
                    direction = 1f;
                    gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                }
            }
        }
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){
            // GetComponent<Animator>().SetBool("attack02",true);
            // Debug.Log("Slime Attack!!");
            AudioSystem.PlaySE(AttackSound);
            StartCoroutine(WaitForCD(1.5f));
            GameObject obj = Instantiate(blood,transform.position,transform.rotation);
            Destroy(obj,5f);
            hurtPlayer?.Invoke();
        }
    }
    private void DetectAndDash(){
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < detectRadius){
            // Debug.Log("Detected player");
            if(!isDashing){
                isDashing = true;
                moveDirection = (player.transform.position - transform.position).normalized;
                StartCoroutine( WaitForCD(1.5f)); 
            }
               
        }
    }
    private IEnumerator WaitForCD(float cdTime)
    {
        yield return new WaitForSeconds(cdTime);
        isDashing = false;
    }
}

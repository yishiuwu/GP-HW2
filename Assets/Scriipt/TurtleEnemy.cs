using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float walktime = 5f;
    public GameObject player;
    public float detectRadius = 5f;
    public AudioClip AttackSound;
    private AudioSource myAudioSource;
    private float direction = 1f;
    private float distance = 0f;
    private bool attacking = false;
    private bool isCoolDown = false;
    public GameObject blood;

    public float subHP = -20;
    public event System.Action hurtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        hurtPlayer += () => {player.GetComponent<PlayerController>().Hurt();};
        hurtPlayer += () => {PlayerStateControl.AddPlayerHP(subHP);};
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        distance+=Time.deltaTime;
        if(attacking){
            distance = 0;
            Vector3 faceDirection = (player.transform.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(faceDirection);
            transform.rotation = targetRotation;
            GetComponent<Animator>().SetBool("walk", false);
            GetComponent<Animator>().SetBool("attack01", true);
            if(!isCoolDown)PlayAttackSound();
        }else{
            GetComponent<Animator>().SetBool("walk", true);
            transform.Translate(0,0,moveSpeed*Time.deltaTime);
        }
        
        if(distance > walktime && !attacking){
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
    private void PlayAttackSound(){
        AudioSystem.PlaySE(AttackSound);
        Debug.Log("attacking");
        hurtPlayer?.Invoke();
        isCoolDown = true;
        StartCoroutine(WaitForCoolDown(2f));
    }
    private void DetectPlayer(){
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer < detectRadius){
            attacking = true;
        }else{
            attacking = false;
            GetComponent<Animator>().SetBool("attack01", false);
        }
    }
    private IEnumerator WaitForCoolDown(float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        isCoolDown = false;
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){
            //Booming = true;
            //GetComponent<Animator>().SetTrigger("attack01");
            //myAudioSource.PlayOneShot(HurtSound);
            GameObject obj = Instantiate(blood,transform.position,transform.rotation);
            Destroy(obj,5f);
            //StartCoroutine(SelfDestroy());
        }

    }
}

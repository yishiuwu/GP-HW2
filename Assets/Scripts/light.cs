using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    //
    public float speed = 5f;

    //
    public Material sky1;
    public Material sky2;
    private float cur_rotate = 0.0f;
    private float compute = 0.0f;
    //
    private Vector3 start_pos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("hihi");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle: Time.deltaTime * speed, yAngle: 0, zAngle: 0);
        cur_rotate += Time.deltaTime * speed;

        if(cur_rotate >= 45.0f && cur_rotate <= 280.0f){
            RenderSettings.skybox = sky2;
            //RenderSettings.skybox.SetFloat("_Exposure", )
            if(cur_rotate <= 162.0f){
                compute = 2.1f - ((1.3f * (cur_rotate - 45.0f)) / 117.0f);
            }
            else{
                compute = 0.8f + ((1.3f * (cur_rotate - 162.0f))/117.0f);
            }
            RenderSettings.skybox.SetFloat("_Exposure", compute);
        }
        else{
            RenderSettings.skybox = sky1;
            
            if(cur_rotate <= 342.5f && cur_rotate >= 45.0f){
                compute = 0.7f + ((2.0f * (cur_rotate - 280.0f))/62.5f); 
            }
            else if(cur_rotate >= 342.5f){
                compute = 2.7f - ((2.0f * (cur_rotate - 342.5f))/62.5f);
            }
            else{
                compute = 2.7f - ((2.0f * (cur_rotate + 17.5f))/62.5f);
            }
            RenderSettings.skybox.SetFloat("_Exposure", compute);
        }

        if(cur_rotate >= 360.0f){
            cur_rotate = 0.0f;
        }
    }
}

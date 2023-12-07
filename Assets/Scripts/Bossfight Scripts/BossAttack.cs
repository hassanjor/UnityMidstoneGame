using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //all spikes
    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject spike4;
    public GameObject spike5;

    //darker images of spikes for indication that they will spawn 
    public GameObject darkSpike1;
    public GameObject darkSpike2;
    public GameObject darkSpike3;
    public GameObject darkSpike4;
    public GameObject darkSpike5;

    //lazer protecting the boss 
    public GameObject Lazer; 

    float Timer; 
    
    // Start is called before the first frame update
    void Start()
    {
        //everything is not active except lazer 

        spike1.SetActive(false);
        spike2.SetActive(false);
        spike3.SetActive(false);
        spike4.SetActive(false);
        spike5.SetActive(false);


        darkSpike1.SetActive(false);
        darkSpike2.SetActive(false);
        darkSpike3.SetActive(false);
        darkSpike4.SetActive(false);
        darkSpike5.SetActive(false);

        Lazer.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        //this might not be the best way, im using a timer and kind of hardcoding exactly when to showcase those images
        // for our case this works since its pretty simple 
        Timer += Time.deltaTime; 

        if(Timer >= 5.0f && Timer <= 6.0f)
        {
            darkSpike1.SetActive(true);
            darkSpike2.SetActive(true);
            darkSpike3.SetActive(true);
            darkSpike4.SetActive(true);
            darkSpike5.SetActive(true);

        }

        if (Timer >= 6.0f && Timer <= 7.0f)
        {
            darkSpike1.SetActive(false);
            darkSpike2.SetActive(false);
            darkSpike3.SetActive(false);
            darkSpike4.SetActive(false);
            darkSpike5.SetActive(false);
        }

        if (Timer >= 7.0f && Timer <= 8.0f)
        {
            darkSpike1.SetActive(true);
            darkSpike2.SetActive(true);
            darkSpike3.SetActive(true);
            darkSpike4.SetActive(true);
            darkSpike5.SetActive(true);

        }

        if (Timer >= 8.0f && Timer <= 9.0f )
        {
            darkSpike1.SetActive(false);
            darkSpike2.SetActive(false);
            darkSpike3.SetActive(false);
            darkSpike4.SetActive(false);
            darkSpike5.SetActive(false);
        }

        if (Timer >= 9.0f && Timer <= 10.0f)
        {
            spike1.SetActive(true);
            spike2.SetActive(true);
            spike3.SetActive(true);
            spike4.SetActive(true);
            spike5.SetActive(true);


        }

        //finally when the entire attack is done, hide the lazer so the player can go and kill the boss 
        if(Timer >= 12.0f)
        {
            Lazer.SetActive(false); 

        }
    }
}

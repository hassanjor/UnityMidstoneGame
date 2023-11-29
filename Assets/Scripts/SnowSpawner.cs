using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    //Screen border min and max values 
    private float minX, maxX, minY, maxY;
    //position of spawn
    private Vector2 pos;
    //the snow objects we want to Instantiate 
    public GameObject Snow;
    public GameObject redSnow;
    public GameObject yellowSnow; 

    //timer to control the spawning
    float timer = 0;
    float redTimer = 0; 
    float yellowTimer = 0;

    //make sure we dont spawn forever
    //adjust these values from the spawner game object in the scene for it to change 
    public int maxSpawnLimit = 50; 
    public int maxRedSpawnLimit = 10; 
    public int maxYellowSpawnLimit = 5;

    void SetMinAndMax()
    {
        //get the min and max values from the camera 
        Vector2 Bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //set the camera values to our variables 
        minX = -Bounds.x;
        maxX = Bounds.x;
        minY = -Bounds.y;
        maxY = Bounds.y;
    }

    void SpawnRegularSnow()
    {
        //spawn the object by instansiating from the snow gameobject(prefab in project browser),
        //and at a random location in our camera borders 

        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject obj = Instantiate(Snow, pos, Quaternion.identity);
        obj.transform.parent = transform;
    }

    void SpawnRedSnow()
    {
            pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            GameObject obj = Instantiate(redSnow, pos, Quaternion.identity);
            obj.transform.parent = transform;
    }

    void SpawnYellowSnow()
    {
        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject obj = Instantiate(yellowSnow, pos, Quaternion.identity);
        obj.transform.parent = transform;
    }


    void Start()
    {
        SetMinAndMax();
    }


    void Update()
    {
        //increase the timer every second
        timer += Time.deltaTime;
        redTimer += Time.deltaTime;
        yellowTimer += Time.deltaTime;

        //every 1 second spawn a snow pile and reset the timer 
        if (timer >= 1 && maxSpawnLimit > 0)
        {
            SpawnRegularSnow();
            //decrease 1 every time a snow pile is spawned
            //this also gets increased whenever a snow pile is destroyed (in snow collisions script)
            maxSpawnLimit--;
            timer = 0.0f;           
        }

        //spawn Red snow every 5 seconds 
        if(redTimer >= 5.0f && maxRedSpawnLimit > 0 && BuyItems.redSnowBought == true) 
        {
            SpawnRedSnow();
            maxRedSpawnLimit--;
            redTimer = 0.0f;
            
        }

        //spawn yellow snow every 10 seconds 
        if(yellowTimer >= 10.0f && maxYellowSpawnLimit > 0 && BuyItems.yellowSnowBought == true)
        {
            SpawnYellowSnow();
            maxYellowSpawnLimit--;
            yellowTimer = 0.0f;
        }

    }
}

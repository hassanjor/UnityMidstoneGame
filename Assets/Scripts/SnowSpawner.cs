using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    //Screen border min and max values 
    private float minX, maxX, minY, maxY;
    //position of spawn
    private Vector2 pos;
    //the snow object we want to Instantiate 
    public GameObject Snow;
    //timer to control the spawning
    float timer = 0;
    //make sure we dont spawn forever
    public int maxSpawnLimit = 30; //adjust this from the spawner game object in the scene

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

    void SpawnObject()
    {
        //spawn the object by instansiating from the snow gameobject(prefab in project browser),
        //and at a random location in our camera borders 

        pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GameObject obj = Instantiate(Snow, pos, Quaternion.identity);
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
        //every 1 second spawn a snow pile and reset the timer 
        if (timer >= 1 && maxSpawnLimit > 0)
        {
            SpawnObject();
            //decrease 1 every time a snow pile is spawned
            //this also gets increased whenever a snow pile is destroyed (in snow collisions script)
            maxSpawnLimit--;
            timer = 0;           
        }

    }
}

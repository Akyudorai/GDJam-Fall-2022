using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public float leftX_value;
    public float rightX_value;
    public float upperY = 4.5f;
    public float lowerY = -4f;
    public Vector2 spawnPosition;
    public List<GameObject> vehicles;

    float currentTime = 0f;
    public float spawnTime = 1f;

    public float minSpeed = 5f;
    public float maxSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= spawnTime)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            SpawnTraffic();
            currentTime = 0f;
        }

        
    }

    public void SpawnTraffic()
    {
        float objectSpeed;
        leftX_value = GameObject.FindGameObjectWithTag("Player").transform.position.x + Camera.main.orthographicSize * 2f;
        rightX_value = GameObject.FindGameObjectWithTag("Player").transform.position.x - Camera.main.orthographicSize * 2f;
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").name);
        this.gameObject.transform.position = new Vector3(rightX_value, 0f, 0f);

        int side = Random.Range(0, 2); //0 = left side and 1 = right side
        if (side == 0)
        {
            spawnPosition = new Vector2(leftX_value, Random.Range(lowerY, upperY));
            objectSpeed = Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            spawnPosition = new Vector2(rightX_value, Random.Range(lowerY, upperY));
            objectSpeed = Random.Range(minSpeed, maxSpeed);
        }
        int objectSelection = Random.Range(0, vehicles.Count - 1);
        GameObject trafficObject = Object.Instantiate(vehicles[objectSelection], spawnPosition, Quaternion.identity);
        if(side == 0)
        {
            trafficObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-objectSpeed, 0f);
        }
        else
        {
            trafficObject.GetComponent<Rigidbody2D>().velocity = new Vector2(objectSpeed, 0f);
        }
        


    }
}

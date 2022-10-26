using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsTrigger : MonoBehaviour
{
    public GameObject destroyedBuilding;
    public int pointsValue = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball") || collision.gameObject.CompareTag("Player"))
        {
            Points.points.AddPoints(pointsValue);
            Instantiate(destroyedBuilding, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

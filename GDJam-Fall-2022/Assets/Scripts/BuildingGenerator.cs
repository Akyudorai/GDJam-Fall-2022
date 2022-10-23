using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject buildingPrefab;

    // The range of distance between each building
    public Vector2 distanceRange;
    public int numberOfBuildings;

    // Where the buildings will begin.
    public Transform origin;
    public List<GameObject> buildings = new List<GameObject>();

    private void Start() 
    {
        GenerateBuildings();
    }

    public void GenerateBuildings()
    {
        for (int i = 0; i < numberOfBuildings; i++) 
        {
            float r = Random.Range(distanceRange.x, distanceRange.y);
            GameObject newBuilding = Instantiate(buildingPrefab, Vector3.zero, Quaternion.identity);            
            newBuilding.transform.SetParent(this.transform);
            if (i == 0) { 
                newBuilding.transform.localPosition = Vector3.zero;
            } else {
                // Set position to randomly generated X plus last buildings position
                newBuilding.transform.localPosition = buildings[i-1].transform.localPosition + new Vector3(r, 0, 0);
            }
            
            buildings.Add(newBuilding);
        }
    }
}

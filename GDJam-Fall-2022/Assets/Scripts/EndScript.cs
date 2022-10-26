using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public Text pointsTotal;

    public void Start()
    {
        pointsTotal.text = Points.points.GetPoints().ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

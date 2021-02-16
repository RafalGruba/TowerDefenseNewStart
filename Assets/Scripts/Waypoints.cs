using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    public GameObject PathYellow;
    [SerializeField]
    public GameObject PathRed;
    [SerializeField]
    public GameObject PathBlue;

    public static Transform[] pointsYellow;
    public static Transform[] pointsRed;
    public static Transform[] pointsBlue;

    private void Awake()
    {
        //Debug.Log(PathYellow.transform.childCount); //6
        //Debug.Log(PathRed.transform.childCount); //10
        //Debug.Log(PathBlue.transform.childCount); //10


        pointsYellow = new Transform[PathYellow.transform.childCount];
        //Debug.Log(pointsYellow.Length);
        for (int i = 0; i < pointsYellow.Length; i++)
        {
            pointsYellow[i] = PathYellow.transform.GetChild(i);
        }

        pointsRed = new Transform[PathRed.transform.childCount];
        for (int i = 0; i < pointsRed.Length; i++)
        {
            pointsRed[i] = PathRed.transform.GetChild(i);
        }

        pointsBlue = new Transform[PathBlue.transform.childCount];
        
        for (int i = 0; i < pointsBlue.Length; i++)
        {
            pointsBlue[i] = PathBlue.transform.GetChild(i);
        }
        //Debug.Log(pointsRed);
    }
}

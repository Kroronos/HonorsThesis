using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static List<Transform[]> paths;
    void Awake() {
        paths = new List<Transform[]>();

        for (int i = 0; i < transform.childCount; ++i) {
            Transform[] waypointsPath = new Transform[transform.GetChild(i).childCount];

            for (int j = 0; j < transform.GetChild(i).childCount; ++j) {
                waypointsPath[j] = transform.GetChild(i).GetChild(j);
            }

            paths.Add(waypointsPath);
        }     
    }

}

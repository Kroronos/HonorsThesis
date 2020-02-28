using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public ExitDirection enter;
    public ExitDirection exit;

    public List<Transform> GetPathWaypoints() {
        List<Transform> waypoints = new List<Transform>();

        for(int i = 0; i < transform.childCount; ++i) {
            waypoints.Add(transform.GetChild(i));
        }

        return waypoints;
    }
 }

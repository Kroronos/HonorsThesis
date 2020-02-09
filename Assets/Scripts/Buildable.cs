using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public List<GameObject> buildableOn;

    public bool IsBuildableOn(System.Type target) {

        foreach(GameObject obj in buildableOn) {
            if (obj.GetType() == target) return true;
        }

        return false;
    }

}

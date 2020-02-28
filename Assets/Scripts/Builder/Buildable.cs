using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public List<GameObject> buildableOn;

    public bool IsBuildableOn(GameObject targ) {

        foreach(GameObject obj in buildableOn) {
            if (targ.GetComponent<Placement>() != null &&
                targ.GetComponent<Placement>().GetType() == obj.GetComponent<Placement>().GetType() &&
                !obj.GetComponent<Placement>().BuiltOn()) {
                return true;
            }
        }

        return false;
    }
}

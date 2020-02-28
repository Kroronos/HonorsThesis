using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Placement : MonoBehaviour {

    public abstract Transform PlaceBuildable(Buildable building);

    public abstract void RotateBuildable(float rotationSpeed);
    public abstract void RemoveBuildable();
    public abstract void ResetColor();
    public abstract void SetColorToSelection();
    public abstract void SetColorToInProgress();
    public abstract bool BuiltOn();
}

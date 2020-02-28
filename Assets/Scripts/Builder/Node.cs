using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : Placement {
    private Renderer rend;

    private Turret builtTurret;

    private Color defaultColor;
    private Color selectColor = Color.blue;
    private Color inProgressColor = Color.magenta;

    void Start() { 

        builtTurret = null;

        rend = GetComponent<Renderer>();

        defaultColor = rend.material.GetColor("_Color");

    }

    public override Transform PlaceBuildable(Buildable building) {
        //probably want to do some redundant error checks here 

        Transform c = Instantiate(building.transform, transform.position, transform.rotation);
        c.SetParent(transform, true);

        builtTurret = c.GetComponent<Turret>();
        builtTurret.DrawRange();

        return c;
    }

    public override void RotateBuildable(float rotationSpeed) {
        builtTurret.PlacementRotate(rotationSpeed);
    }

    public override void RemoveBuildable() {
        Destroy(builtTurret.gameObject);

        builtTurret = null;
    }

    public override void ResetColor() {
        rend.material.color = defaultColor;
    }
    public override void SetColorToSelection() {
        rend.material.color = selectColor;
    }
    public override void SetColorToInProgress() {
        rend.material.color = inProgressColor;
    }

    public override bool BuiltOn() {
        return (builtTurret != null);
    }
}

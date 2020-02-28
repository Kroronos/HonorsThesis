using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretCard", menuName = "TurretCard")]
public class TurretCard : Card {
    public Turret turret;

    public override bool IsBuildable() {
        return true;
    }

    public override Buildable GetBuildable() {
        return turret;
    }
}

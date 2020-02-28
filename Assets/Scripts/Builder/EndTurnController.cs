using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnController : MonoBehaviour
{

    private Switch switchMode;

    private void Start()
    {
        switchMode = GetComponent<Switch>();
    }

    public void EndTurn() {
        //CardController.cardController.EndTurn();
        //SpawnPointController.spawnPointController.NextWave();
        switchMode.SwitchMode(true);
    }
}

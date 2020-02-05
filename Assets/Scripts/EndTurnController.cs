using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnController : MonoBehaviour
{
    public void EndTurn() {
        CardController.cardController.EndTurn();

        SpawnPointController.spawnPointController.NextWave();

    }
}

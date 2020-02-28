using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerClass", menuName = "PlayerClass")]
public class PlayerClass : ScriptableObject {
    public Card[] startingCards;
}


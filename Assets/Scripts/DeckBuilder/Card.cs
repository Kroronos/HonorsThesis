using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public abstract class Card : ScriptableObject {
    public string cardName;
    public string description;
    public Sprite art;
    public int cost;

    public abstract bool IsBuildable();

    public abstract Buildable GetBuildable();
}

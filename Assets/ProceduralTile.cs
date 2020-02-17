using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ExitDirection {
    UP, //0
    RIGHT, //1
    DOWN, //2
    LEFT //3
}

static class ExitDirectionOperations {
    public static ExitDirection GetNext(ExitDirection targ) {

        switch(targ) {
            case ExitDirection.UP:
                return ExitDirection.RIGHT;
            case ExitDirection.RIGHT:
                return ExitDirection.DOWN;
            case ExitDirection.DOWN:
                return ExitDirection.LEFT;
            case ExitDirection.LEFT:
                return ExitDirection.UP;
            default: //empty
                Debug.LogError("ExitDirection getNext called on empty enum");
                return ExitDirection.UP;
        }
    }
}
public class ProceduralTile : MonoBehaviour {

    Dictionary<ExitDirection, Transform> exits;

    public List<ExitDirection> exitDirs;
    public List<Transform> exitPostions;

    void Awake() {
        if(exitDirs.Count != exitPostions.Count) {
            Debug.LogError("Exit postions and directions not equal.");
        }
         
        exits = new Dictionary<ExitDirection, Transform>();

        for(int i = 0; i < exitDirs.Count || i < exitPostions.Count; ++i) {
            exits.Add(exitDirs[i], exitPostions[i]);
        }
    }

    public void OrientExits(HashSet<ExitDirection> desiredExits) { 
        //tile must be rotatable to new orientation

        while(!desiredExits.All(k => exitDirs.Contains(k))) { //@TODO very brute force

            for(int i = 0; i < exitDirs.Count; ++i) {
                exitDirs[i] = ExitDirectionOperations.GetNext(exitDirs[i]);
            }

            transform.Rotate(transform.up, 90);
        }

        exits.Clear();

        for (int i = 0; i < exitDirs.Count || i < exitPostions.Count; ++i) {
            exits.Add(exitDirs[i], exitPostions[i]);
        }


    }

    public bool IsCorner() {
        if((exits.ContainsKey(ExitDirection.LEFT) || exits.ContainsKey(ExitDirection.RIGHT)) &&
            (exits.ContainsKey(ExitDirection.UP) || exits.ContainsKey(ExitDirection.DOWN))) {
            return true;
        }
        return false; 
    }

    public int GetExitNumber() {
        return exits.Count;
    }

    public Vector3 getPositionOfExit(ExitDirection dir) {
        return exits[dir].position;  
    }
}

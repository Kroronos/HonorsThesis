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
    private Path[] paths; 

    void Awake() {
        if(exitDirs.Count != exitPostions.Count) {
            Debug.LogError("Exit postions and directions not equal.");
        }
         
        exits = new Dictionary<ExitDirection, Transform>();

        for(int i = 0; i < exitDirs.Count || i < exitPostions.Count; ++i) {
            exits.Add(exitDirs[i], exitPostions[i]);
        }

        paths = GetComponentsInChildren<Path>();

        if(paths.Length == 0) { Debug.Log("Tile does not have valid paths."); };
    }

    public void OrientExits(HashSet<ExitDirection> desiredExits) { 
        //tile must be rotatable to new orientation

        while(!desiredExits.All(k => exitDirs.Contains(k))) { //@TODO very brute force

            for(int i = 0; i < exitDirs.Count; ++i) {
                exitDirs[i] = ExitDirectionOperations.GetNext(exitDirs[i]);
            }

            transform.Rotate(transform.up, 90);

            for (int i = 0; i < paths.Length; ++i) {
                paths[i].enter = ExitDirectionOperations.GetNext(paths[i].enter);
                paths[i].exit = ExitDirectionOperations.GetNext(paths[i].exit);

            }

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

    public static ExitDirection GetOppositeDirection(ExitDirection exit) {
        if(exit == ExitDirection.DOWN) {
            return ExitDirection.UP;
        }
        else if (exit == ExitDirection.LEFT) {
            return ExitDirection.RIGHT;
        }
        else if (exit == ExitDirection.RIGHT) {
            return ExitDirection.LEFT;
        }
        else {
            return ExitDirection.DOWN;
        }
    }

    public List<List<Transform>> GetPaths(ExitDirection enter, ExitDirection exit) {
        List<List<Transform>> listOfPaths = new List<List<Transform>>();
        foreach(Path p in paths) {
            if(p.enter == enter && p.exit == exit)
                listOfPaths.Add(p.GetPathWaypoints());
            else if(p.enter == exit && p.exit == enter) {
                List<Transform> reversedPath = p.GetPathWaypoints();
                reversedPath.Reverse();
                listOfPaths.Add(reversedPath);
            }
        }

        if (listOfPaths.Count == 0) {
            Debug.Log("Retrieved path with given enterance and exit is empty.");
        }

        return listOfPaths;
    }

    public List<List<Transform>> GetPaths(ExitDirection enter) {
        List<List<Transform>> listOfPaths = new List<List<Transform>>();

        foreach (Path p in paths) {
            if(p.enter == enter)
                listOfPaths.Add(p.GetPathWaypoints());
            else if(p.exit == enter) {
                List<Transform> reversedPath = p.GetPathWaypoints();
                reversedPath.Reverse();
                listOfPaths.Add(reversedPath);
            }
        }

        if(listOfPaths.Count == 0) {
            Debug.Log("Retrieved path with given enterance is empty.");
        }

        return listOfPaths;
    }

    public int GetExitNumber() {
        return exits.Count;
    }

    public Vector3 getPositionOfExit(ExitDirection dir) {
        return exits[dir].position;  
    }
}

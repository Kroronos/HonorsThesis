using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    private Dictionary<Transform, List<Transform[]>> paths;

    public static Waypoints waypoints;
    public void Awake() {
        if(waypoints == null) {
            paths = new Dictionary<Transform, List<Transform[]>>();
            waypoints = this;
        }
        else {
            Debug.LogError("More than one waypoint system active.");
        }
    }

    public void GeneratePaths(MapGenerator map) {
        System.Tuple<int, int> start = map.startCoord;
        foreach(System.Tuple<System.Tuple<Transform, ExitDirection>, System.Tuple<int, int>> dest in map.spawnCoords) {
            GeneratePaths(dest, start, map);
        }
    }

    public void GeneratePaths(System.Tuple<System.Tuple<Transform, ExitDirection>, System.Tuple<int, int>> dest,
        System.Tuple<int, int> start, MapGenerator map) {
        
        Queue<List<System.Tuple<int, int>>> open = new Queue<List<System.Tuple<int, int>>>();

        open.Enqueue(new List<System.Tuple<int, int>>() { dest.Item2 });

        while(open.Count != 0) {
            List<System.Tuple<int, int>>  currPath = open.Dequeue();
            
            if(currPath[currPath.Count-1].Equals(start)) { //end of curr path is start
                //get path of transforms 

                List<List<List<Transform>>> paths = new List<List<List<Transform>>>();
                for(int i = 0; i < currPath.Count; ++i) {
                    if(i == 0) { //need to get path from spawn to exit
                        paths.Add(map.tiles[dest.Item2.Item1, dest.Item2.Item2].tile.GetPaths(dest.Item1.Item2));
                    }
                    else if( i == currPath.Count -1) { //just need source
                        paths.Add(map.tiles[currPath[i].Item1, currPath[i].Item2].tile.GetPaths(
                            map.GetSourceDirection(currPath[i-1].Item1, currPath[i-1].Item2,
                            currPath[i].Item1, currPath[i].Item2)));
                    }
                    else {  //need to get path from previous to exit
                        paths.Add(map.tiles[currPath[i].Item1, currPath[i].Item2].tile.GetPaths(
                            map.GetSourceDirection(currPath[i-1].Item1, currPath[i-1].Item2,
                            currPath[i].Item1, currPath[i].Item2), 
                            map.GetExitDirection(currPath[i].Item1, currPath[i].Item2,
                            currPath[i+1].Item1, currPath[i+1].Item2)));
                    }
                }

                //add to global path dest
                UnpackPaths(dest.Item1.Item1, new List<Transform>(), paths);
                
            }
            else {
                foreach (System.Tuple<int, int> adj in map.GetAdjacent(currPath[currPath.Count - 1])) {
                    if (!currPath.Contains(adj)) {
                        List<System.Tuple<int, int>> temp = new List<System.Tuple<int, int>>();
                        temp.AddRange(currPath);
                        temp.Add(adj);
                        open.Enqueue(temp);
                    }
                }
            }

        }
    }

    public void AddPath(Transform source, Transform[] path) {
        if(paths.ContainsKey(source)) {
            paths[source].Add(path);
        }
        else {
            paths[source] = new List<Transform[]>() { path };
        }
    }
    public void UnpackPaths(Transform source, List<Transform> existingWaypoints,
       List<List<List<Transform>>> remaining) {

        if (remaining.Count == 0) {
            AddPath(source, existingWaypoints.ToArray());
            return;
        }

        List<List<Transform>> toBeAdded = remaining[0];

        remaining.RemoveAt(0);

        foreach (List<Transform> a in toBeAdded) {
            List<Transform> oldE = new List<Transform>(); 
            oldE.AddRange(existingWaypoints);
            existingWaypoints.AddRange(a);

            UnpackPaths(source, existingWaypoints, remaining);

            existingWaypoints = oldE;

        }

    }

    public Transform[] GetPathFromSource(Transform source) { //returns random path from source
        List<Transform[]> path;
        bool hasValue = paths.TryGetValue(source, out path);
        if (hasValue)
            return path[Random.Range(0, path.Count)];
        else
            throw new System.Exception("No paths found from source provided to GetPathFromSource");
    }

}

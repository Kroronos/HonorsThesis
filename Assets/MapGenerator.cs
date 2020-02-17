using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int mapDimensions = 15;
    private string proceduralPath = "Procedural";


    enum GenerationState {
        EMPTY, //no neighboring exit
        EXPECTED, //neighboring exit
        GENERATED //tile already generated
    }

    class GenerationInfo {
        public ProceduralTile tile;
        public GenerationState state;
        public HashSet<ExitDirection> expectedExits;

        public GenerationInfo() {
            expectedExits = new HashSet<ExitDirection>();
        }
    }

    GenerationInfo[,] tiles;
    Object[] starts;
    Object[] oneExits;
    Object[] twoExitsS;
    Object[] twoExitsC;
    Object[] threeExits;
    Object[] fourExits;

    public void Awake() {
        tiles = new GenerationInfo[mapDimensions, mapDimensions];

        GenerateMap(mapDimensions/2 + 1, mapDimensions/2 + 1);
    }

    public void GenerateMap(int startX, int startY) {
        //select start position
        starts = Resources.LoadAll(proceduralPath + "/Starts");
        oneExits = Resources.LoadAll(proceduralPath + "/One");
        twoExitsS = Resources.LoadAll(proceduralPath + "/Two/Straight");
        twoExitsC = Resources.LoadAll(proceduralPath + "/Two/Corner");
        threeExits = Resources.LoadAll(proceduralPath + "/Three");
        fourExits = Resources.LoadAll(proceduralPath + "/Four");

        //update map
        for (int i = 0; i < mapDimensions; ++i) {
            for (int j = 0; j < mapDimensions; ++j) {
                tiles[i, j] = new GenerationInfo();
            }
        }
        
        tiles[startX, startY].tile = ((GameObject)starts[Random.Range(0, starts.Length)]).GetComponent<ProceduralTile>();
        tiles[startX, startY].state = GenerationState.GENERATED;
        AdjacentOperations(startX, startY, tiles, (t, d) => { t.state = GenerationState.EXPECTED; t.expectedExits.Add(d);});

        //init transform of starting tile
        Transform start = Instantiate(tiles[startX, startY].tile.transform);
        start.SetParent(transform, false);

        Transform[] genPoints = tiles[startX,startY].tile.exitPostions.ToArray();
        ExitDirection[] exitDirs = tiles[startX, startY].tile.exitDirs.ToArray();

        for(int i = 0; i < genPoints.Length; ++i) {
            bool isValisd = IsValidPosition(startX, startY, exitDirs[i]);
            if (IsValidPosition(startX, startY, exitDirs[i])) {
                GenerateTile(GetNewX(startX, startY, exitDirs[i]), GetNewY(startX, startY, exitDirs[i]), genPoints[i]);
            }
        }
    }

    void GenerateTile(int x, int y, Transform loc) {
        //count unassigned
        int unassignedCount = CountAdjEmpty(x, y);


        //select prefab to match (min connects = 1 || expectedConnects, max = expectedConnects + unassignedCount
        int exitSelected = Random.Range(Mathf.Max(2, tiles[x, y].expectedExits.Count),
            tiles[x, y].expectedExits.Count + unassignedCount + 1);


        switch (exitSelected) {
            case 1:
                tiles[x, y].tile =
                    ((GameObject)oneExits[Random.Range(0, oneExits.Length)]).GetComponent<ProceduralTile>();
                break;
            case 2:
                if ((tiles[x, y].expectedExits.Contains(ExitDirection.LEFT) || tiles[x, y].expectedExits.Contains(ExitDirection.RIGHT)) &&
                     (tiles[x, y].expectedExits.Contains(ExitDirection.UP) || tiles[x, y].expectedExits.Contains(ExitDirection.DOWN))) {
                    tiles[x, y].tile =
                        ((GameObject)twoExitsC[Random.Range(0, twoExitsC.Length)]).GetComponent<ProceduralTile>();
                } //corner
                else {
                    tiles[x, y].tile =
                       ((GameObject)twoExitsS[Random.Range(0, twoExitsS.Length)]).GetComponent<ProceduralTile>();
                } //straight
                break;
            case 3:
                tiles[x, y].tile =
                ((GameObject)threeExits[Random.Range(0, threeExits.Length)]).GetComponent<ProceduralTile>();
                break;
            case 4:
                tiles[x, y].tile =
                ((GameObject)fourExits[Random.Range(0, fourExits.Length)]).GetComponent<ProceduralTile>();
                break;
            default:
                Debug.LogError("More than 4 exits desired in map generation.");
                break;
        } //end switch

        tiles[x, y].state = GenerationState.GENERATED;

        AdjacentOperations(x, y, tiles, (t, d) => { if (t.state != GenerationState.GENERATED) { t.state = GenerationState.EXPECTED; t.expectedExits.Add(d); } });

        //init transform of starting tile
       Transform gen = Instantiate(tiles[x, y].tile.transform, new Vector3(loc.position.x, 0, loc.position.z),
           tiles[x, y].tile.transform.rotation);
       gen.SetParent(transform, false);

        //rotate generation to line up exits
        gen.transform.gameObject.GetComponent<ProceduralTile>().OrientExits(tiles[x, y].expectedExits);

        ExitDirection[] exitDirs = gen.GetComponent<ProceduralTile>().exitDirs.ToArray();
        Transform[] genPoints = gen.GetComponent<ProceduralTile>().exitPostions.ToArray();

        for (int i = 0; i < genPoints.Length; ++i) {
            if (IsValidPosition(x, y, exitDirs[i])) {
                int newX = GetNewX(x, y, exitDirs[i]);
                int newY = GetNewY(x, y, exitDirs[i]);

                if (tiles[newX, newY].state != GenerationState.GENERATED) {
                    GenerateTile(newX, newY, genPoints[i]);
                }
            }
        }
    }

    int GetNewX(int x, int y, ExitDirection relDir) {

        if (relDir == ExitDirection.RIGHT) {
            return x+1;
        }
        else if (relDir == ExitDirection.LEFT) {
            return x-1;
        }
        else {
            return x;
        }
    }

    int GetNewY(int x, int y, ExitDirection relDir) {

        if (relDir == ExitDirection.UP) {
            return y+1;
        }
        else if (relDir == ExitDirection.DOWN) {
            return y-1;
        }
        else {
            return y;
        }

    }

    bool IsValidPosition(int x, int y, ExitDirection relDir) {
        
        if(relDir == ExitDirection.RIGHT && x + 1 < mapDimensions) {
            return true;
        }
        else if(relDir == ExitDirection.LEFT && x - 1 >= 0) {
            return true;
        }
        else if(relDir == ExitDirection.UP && y + 1 < mapDimensions) {
            return true;
        }
        else if(relDir == ExitDirection.DOWN && y - 1 >= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    public int CountAdjEmpty(int x, int y) {
        int empty  = 0;

        if (x + 1 < mapDimensions) { //go right
            if(tiles[x+1, y].state.Equals(GenerationState.EMPTY)) ++empty;
        }

        if (x - 1 >= 0) { //go left
            if (tiles[x-1, y].state.Equals(GenerationState.EMPTY)) ++empty;
        }


        if (y + 1 < mapDimensions) { //go up
            if (tiles[x, y+1].state.Equals(GenerationState.EMPTY)) ++empty;
        }

        if (y - 1 >= 0) { //go down
            if (tiles[x, y - 1].state.Equals(GenerationState.EMPTY)) ++empty;
        }

        return empty;
    }

    public void AdjacentOperations<T>(int x, int y, T[,] arr, System.Action<T, ExitDirection> f) {
        if (x + 1 < mapDimensions) { //go right
            f(arr[x + 1, y], ExitDirection.LEFT); //second param is src direction
        }

        if (x - 1 >= 0) { //go left
            f(arr[x - 1, y], ExitDirection.RIGHT);
        }


        if (y + 1 < mapDimensions) { //go up
            f(arr[x, y + 1], ExitDirection.DOWN);
        }

        if (y - 1 >= 0) { //go down
            f(arr[x, y - 1], ExitDirection.UP);
        }
    }
}

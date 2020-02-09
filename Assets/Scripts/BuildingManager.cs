using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    public static BuildingManager buildingManager;
    public Buildable building;
    public Transform display;
    public Transform target;

    public float rotationSpeed = 10f;

    [SerializeField]
    private KeyCode leftRotationHotkey = KeyCode.Q;

    [SerializeField]
    private KeyCode rightRotationHotkey = KeyCode.E;


    private bool inProgress = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (buildingManager == null) {
            buildingManager = this;
        }
        else {
            Debug.LogError("More than one building manager in application.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentBuilding();

        if (inProgress) {
            RotateCheck();
            BuildCheck();
            CancelCheck();
        }
        else {
            if (building != null && !inProgress) {
                PlacementCheck();
            }
        }


    }

    public void UpdateCurrentBuilding() {

        Card card = CardController.cardController.GetSelectedCard();

        if(card != null && card.IsBuildable()) {
            building = card.GetBuildable();
        }
    }

    public void PlacementCheck() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo)) { //are we over anything, @TODO accurate mostly except when over UI

            if (building.IsBuildableOn(hitInfo.collider.gameObject.GetType())) { //is that thing a valid placement

                if (Input.GetMouseButtonDown(0)) { //left mouse click
                    Debug.Log("Beginning build progress...");

                    display = Instantiate(building.transform, hitInfo.collider.transform.position, hitInfo.collider.transform.rotation);
                    display.SetParent(hitInfo.collider.transform, true);
                    inProgress = true;
                }
            }
        }
    }

    public void RotateCheck() {
        if(Input.GetKeyDown(leftRotationHotkey)) {
            display.transform.Rotate(Vector3.up, rotationSpeed);
        }
        else if(Input.GetKeyDown(rightRotationHotkey)) {
            display.transform.Rotate(Vector3.up, -rotationSpeed);

        }
    }

    public void BuildCheck() {
        if (Input.GetMouseButtonDown(0)) { //finalize build
            
            //reset vars
            inProgress = false;
            building = null;
            display = null;

            //use card
            CardController.cardController.UseCard(); //release indicator etc,

        }
    }

    public void CancelCheck() {
        if(inProgress) { //check again to see if building has already been placed;
            if (Input.GetMouseButtonDown(1)) { //right mouse down
                Debug.Log("Cancelling build");
                building = null;

                Destroy(display.gameObject);
                display = null;

                inProgress = false;
            }
        }
    }

    public bool InProgress() {
        return inProgress;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject player, playmat;
    private GameObject topCamera;

    private void Start()
    {
        topCamera = transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// Switch the current mode of gameplay
    /// </summary>
    /// <param name="startFPS"></param>
    public void SwitchMode (bool startFPS)
    {
        ChangeActive(topCamera);
        ChangeActive(playmat);

        if (startFPS)
        {
            ActivatePlayer();
        }
    }

    /// <summary>
    /// Spawn the player in the origin of the map
    /// </summary>
    private void ActivatePlayer ()
    {
        player.SetActive(true);
    }

    /// <summary>
    /// Change Active Camera
    /// </summary>
    private void ChangeActive (GameObject obj)
    {
        obj.SetActive((topCamera.activeSelf == true) ? false : true);
    }
}

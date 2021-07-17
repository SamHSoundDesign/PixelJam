using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController
{
    private GameObject camera;
    private GameObject player;
    public CameraController(GameObject camera , GameObject player)
    {
        this.camera = camera;
        this.player = player;
    }

    public void Updates()
    {
        camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAndRot
{
    public Vector2 pos;
    public Quaternion rot;

    public PosAndRot(Vector2 pos , Quaternion rot)
    {
        this.pos = pos;
        this.rot = rot;
    }
}

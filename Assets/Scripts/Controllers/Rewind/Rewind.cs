using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    private List<PosAndRot> posAndRots = new List<PosAndRot>();

    private int posAndRotsLimit = 500;
  


    public void SavePosRot()
    {
        posAndRots.Insert(0, new PosAndRot(transform.position, transform.rotation));
        
        if(posAndRots.Count > posAndRotsLimit)
        {
            posAndRots.RemoveAt(posAndRotsLimit - 1);
        }


    }

    public void RewindObject(RewindController rewindController)
    {
        if(posAndRots.Count <= 0)
        {
          
            rewindController.SetRewinding(false);
            return;
        }

        transform.position = posAndRots[0].pos;
        transform.rotation = posAndRots[0].rot;

        posAndRots.RemoveAt(0);

    }
}

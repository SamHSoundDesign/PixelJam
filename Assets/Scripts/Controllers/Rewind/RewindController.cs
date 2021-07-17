using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindController
{
    private int remainingRewinds;

    private List<Rewind> allRewinds;
    private bool isRewinding;


    public RewindController(Rewind[] allRewindArray)
    {
        allRewinds = new List<Rewind>();
        isRewinding = false;
        foreach (Rewind rewind in allRewindArray)
        {
            allRewinds.Add(rewind);
        }
    }

    public void FixedUpdates()
    {

        if(isRewinding)
        {
            foreach (Rewind rewind in allRewinds)
            {
                rewind.RewindObject(this);

                if(isRewinding == false)
                {
                    return;
                }
            }
        }
        else
        {
            foreach (Rewind rewind in allRewinds)
            {
                rewind.SavePosRot();
            }
        }
       
    }

    public void SetRewinding(bool isRewinding)
    {
        this.isRewinding = isRewinding;
    }

    



}

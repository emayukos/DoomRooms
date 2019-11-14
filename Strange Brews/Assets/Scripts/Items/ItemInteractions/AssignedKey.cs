﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedKey : MonoBehaviour
{
    //holds unlocking variable(s) for locked objects

    string keyName;
    string unlockDescription;


    public string getKeyName()
    {
        return keyName;
    }

    public void setKeyName(string name)
    {
        keyName = name;
    }

    public string getUnlockDescription()
    {
        return unlockDescription;
    }

    public void setUnlockDescription(string unlockDesc)
    {
        unlockDescription = unlockDesc;
    }

}

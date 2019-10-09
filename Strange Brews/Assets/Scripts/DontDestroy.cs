using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// attach to all objects you want to keep in next scene (player, canvas with text, etc.)
public class DontDestroy : MonoBehaviour
{
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameCont : MonoBehaviour
{
    [SerializeField]
    private InputField input;

    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void GetInput(string guess)
    {
        Debug.Log(guess);
        input.text = "";
    }
}

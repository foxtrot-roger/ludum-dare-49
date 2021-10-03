using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDebugger : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var debug = "";
        for (int i = 0; i < (int)KeyCode.Menu; i++)
        {
            if (Input.GetKey((KeyCode)i))
                debug += (KeyCode)i + "\n";
        }

        text.text = debug;
    }
}

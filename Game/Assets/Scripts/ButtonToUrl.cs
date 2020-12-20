using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToUrl : MonoBehaviour
{
    // Start is called before the first frame update
    public string url;
    public void open()
    {
        Application.OpenURL(url);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSets : MonoBehaviour
{
    public string[] Row1;
    public string[] Row2;
    public string[] Row3;
    // Start is called before the first frame update
    void Start()
    {
        Row1 = new string[10] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
        Row2 = new string[10] { "A", "S", "D", "F", "G", "H", "J", "K", "L", "M" };
        Row3 = new string[10] { "Z", "X", "C", "V", "B", "N", "!", ",", ".", "?"  };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

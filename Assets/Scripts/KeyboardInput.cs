using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyboardInput : MonoBehaviour
{
    
    String key;
    Event e;
    public string letter;
    Button button;
    public GameObject obj;
    
    public GameObject LetterSetsOBJ;
    LetterSets LS;
    int idNum;
    public enum rowstates
    {
        Row1, Row2, Row3
    }
    public rowstates state = rowstates.Row2;
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Button");
        button = obj.GetComponent<Button>();
        letter = button.GetComponentInChildren<TMP_Text>().text;
        idNum = Int32.Parse(letter);
        LetterSetsOBJ = GameObject.Find("Letter_Sets");
        LS = LetterSetsOBJ.GetComponent<LetterSets>();
        
        StartCoroutine(LoadCoroutine());
        letter = LS.Row2[idNum - 1];
        button.GetComponentInChildren<TMP_Text>().text = letter;
    }

    private void OnGUI()
    {
        //called on every frame
        e = Event.current;
        key = Event.current.keyCode.ToString();
        switch(e.keyCode) // correcting for specific keyboard layout
        {
            case KeyCode.Comma:
                key = ",";
                break;
            case KeyCode.Period:
                key = ".";
                break;
            case KeyCode.Slash:
                key = "?";
                break;
            case KeyCode.Semicolon:
                key = "M";
                break;
            case KeyCode.M:
                key = "!";
                break;

        }
        

        //if (e.keyCode != KeyCode.None) Debug.Log(key);
        if (e.type == EventType.KeyUp && e.keyCode != KeyCode.None && key.Equals(letter))
        {
            
            StartCoroutine(WaitCoroutine());
            //StartCoroutine(LS.RandomLetterCoroutine());
        }
      
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.UpArrow) )
       {
            switch(state)
            {
                case rowstates.Row1:
                    break; 
                case rowstates.Row2:
                    {
                        state--;
                        letter = LS.Row1[idNum - 1];
                        button.GetComponentInChildren<TMP_Text>().text = letter;
                    }
                    break;
                case rowstates.Row3:
                    {
                        state--;
                        letter = LS.Row2[idNum - 1];
                        button.GetComponentInChildren<TMP_Text>().text = letter;
                    }
                    break;
            }
       }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (state)
            {
                case rowstates.Row1:
                    {
                        state++;
                        letter = LS.Row2[idNum - 1];
                        button.GetComponentInChildren<TMP_Text>().text = letter;
                    }
                    break;
                case rowstates.Row2:
                    {
                        state++;
                        letter = LS.Row3[idNum - 1];
                        button.GetComponentInChildren<TMP_Text>().text = letter;
                    }
                    break;
                case rowstates.Row3:
                    break;
            }
        }

    }

    IEnumerator WaitCoroutine()
    {
        
        button.GetComponent<Image>().color = Color.green;
        key = "";
        e.keyCode = KeyCode.None;
        yield return new WaitForSeconds(0.2f);
        button.GetComponent<Image>().color = Color.white;
    }
    IEnumerator LoadCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
}

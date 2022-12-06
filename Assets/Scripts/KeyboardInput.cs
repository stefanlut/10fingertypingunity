using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyboardInput : MonoBehaviour
{
    
    public String key;
    public Event e;
    public string letter;
    public Button button;
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.Find("Button");
        button = obj.GetComponent<Button>();
        letter = button.GetComponentInChildren<TMP_Text>().text;
        
        
    }
    private void OnGUI()
    {
        e = Event.current;
        key = Event.current.keyCode.ToString();
        if(e.isKey && e.keyCode != KeyCode.None && key.Equals(letter))
        {
            
            
            Debug.Log(key);
            button.GetComponent<Image>().color = Color.green;
            StartCoroutine(WaitCoroutine());
            key = "";
            e.keyCode = KeyCode.None;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        button.GetComponent<Image>().color = Color.white;
    }
}

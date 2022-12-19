using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LetterSets : MonoBehaviour
{
    public string[] Row1;
    public string[] Row2;
    public string[] Row3;
    public GameObject keyButton;
    public GameObject randButton;
    KeyboardInput KI;
    System.Random rnd;
    
    // Start is called before the first frame update
    void Start()
    {
        Row1 = new string[10] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" };
        Row2 = new string[10] { "A", "S", "D", "F", "G", "H", "J", "K", "L", "M" };
        Row3 = new string[10] { "Z", "X", "C", "V", "B", "N", "!", ",", ".", "?"  };
        KI = keyButton.GetComponent<KeyboardInput>();
        rnd = new System.Random();
        StartCoroutine(RandomLetterCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator RandomLetterCoroutine()
    {
        int randomInt = rnd.Next(1, 11);

        string name = "But" + randomInt.ToString();
        randButton = GameObject.Find(name);
        randButton.GetComponent<Image>().color = Color.yellow;

        yield return new WaitForSeconds(1.5f);
        randButton.GetComponent<Image>().color = Color.white;
        
        StartCoroutine(RandomLetterCoroutine());
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalLetterDisplayer : MonoBehaviour
{
    public TextMeshProUGUI paragraph1;
    public TextMeshProUGUI paragraph2;
    public TextMeshProUGUI paragraph3;
    public TextMeshProUGUI paragraph4;

    public GameObject letterSaveObj;
    
    // Start is called before the first frame update
    void Start()
    {
        letterSaveObj = GameObject.Find("LetterSaveState");
        
        paragraph1.text = letterSaveObj.GetComponent<LetterSaveScript>().paragraph1;
        paragraph2.text = letterSaveObj.GetComponent<LetterSaveScript>().paragraph2;
        paragraph3.text = letterSaveObj.GetComponent<LetterSaveScript>().paragraph3;
        paragraph4.text = letterSaveObj.GetComponent<LetterSaveScript>().paragraph4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

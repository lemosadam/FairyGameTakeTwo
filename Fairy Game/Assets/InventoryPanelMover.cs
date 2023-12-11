using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelMover : MonoBehaviour
{
    public GameObject InventoryOffScreen;
    public GameObject InventoryOnScreen;
    //private bool onScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        //onScreen = false;
        gameObject.transform.position = InventoryOffScreen.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenInventory()
    {
        gameObject.transform.position = InventoryOnScreen.transform.position;
         
    }

    public void CloseInventory()
    {
        gameObject.transform.position = InventoryOffScreen.transform.position;
    }
}

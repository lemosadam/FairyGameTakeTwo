using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceptShopListener : MonoBehaviour
{
    public GameObject conceptShopChild;
    // Start is called before the first frame update
    void Start()
    {
        DoorScript.UseDoor += CloseShop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseShop()
    {
        if (conceptShopChild != null)
        {
            conceptShopChild.SetActive(false);
        }
        
    }
}

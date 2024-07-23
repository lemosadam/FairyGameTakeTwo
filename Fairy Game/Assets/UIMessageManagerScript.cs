using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMessageManagerScript : MonoBehaviour
{

    public TMP_Text panelText;
    public GameObject uiPanel;
    //public float panelTime = 6f;
    // Start is called before the first frame update

    void Awake()
    {
        uiPanel = GameObject.Find("UIHintPanel");
    }
    void Start()
    {

        ConceptCollectionNotifier.OnConceptCollected += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptPurchased += ConceptAddedToInventory;
        ConceptCollectionNotifier.OnConceptSold += ConceptRemovedFromInventory;
        BackTeleporter.OnMagicDoorBlocked += MagicDoorBlocked;
        DoorScript.DoorBlocked += DoorBlocked;

        

        ShowPanel();
        //Invoke("HidePanel", panelTime);
        panelText.text = "You wake up in a strange place. You feel empty. You feel lost. You feel like you are missing something. (Use A to move left, D to move right. Press F to interact)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConceptAddedToInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "jump")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "You have found memories of your Childhood Laughter. You feel lighter. (Press space to jump)";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "dash")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "You recall charging headfirst into an obstacle with Unfounded Optimism, no matter the risk. (Press X to dash)";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "double jump")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "Your Hope for the Future carries you to new heights. (Double jump unlocked)";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "inverse jump")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "Heavy memories of a Crushing Heartbreak drag you down.";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "see color")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "Fond memories of a Whirlwind Romance shows you rosy hues where none were before.";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "shrink")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "The feeling of Inferority overwhelms you.";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "switch foreground")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "You recall a time when an obstacle was revealed to be not as it seemed.";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "walk background")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "Bittersweet Longing lets you reach for things in the distance.";
        }

        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "walk background")
        {
            ShowPanel();
            //Invoke("HidePanel", panelTime);
            panelText.text = "Bittersweet Longing lets you reach for things in the distance.";
        }
    }

    void ConceptRemovedFromInventory(GameObject concept)
    {
        if (concept.GetComponent<ConceptCollectionNotifier>().conceptMechanic == "switch foreground")
        {
            
        }
    }

    public void ShowPanel()
    {
        if (uiPanel != null)
        {
            uiPanel.transform.position = GetComponentInParent<Transform>().position;
        }
        
    }

    public void HidePanel()
    {
        uiPanel.transform.position = new Vector2(1000, 1000);
    }

    public void DoorBlocked()
    {
        ShowPanel();
        //Invoke("HidePanel", panelTime);
        panelText.text = "Locked. Perhaps that strange creature knows how to proceed.";
    }

    public void MagicDoorBlocked()
    {
        ShowPanel();
        panelText.text = "To traverse trough this doorway requires, you must be longing for what is out of reach.";
    }
}

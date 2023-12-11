using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;
using Articy.Fairygamedialogue;
using Articy.Fairygamedialogue.GlobalVariables;
using System;

//using static UnityEngine.EventSystems.EventTrigger;

public class DialogueManager : MonoBehaviour, IArticyFlowPlayerCallbacks
{
    [Header("UI")]
    // Reference to Dialog UI
    [SerializeField]
    GameObject dialogueWidget;
    // Reference to dialogue text
    [SerializeField]
    Text dialogueText;
    // Reference to speaker
    [SerializeField]
    Text dialogueSpeaker;
    [SerializeField]
    RectTransform branchLayoutPanel;
    [SerializeField]
    GameObject branchPrefab;
    [SerializeField]
    GameObject closePrefab;
        

    // To check if we are currently showing the dialog ui interface
    public bool DialogueActive { get; set; }

    public GameObject conceptShop;
    public GameObject letterButtonObj;

    private ArticyFlowPlayer flowPlayer;

    public static event Action OnLetterActive;
    void Start()
    {
        ArticyGlobalVariables.Default.FeyDialogue.ShopOpen = false;
        ArticyGlobalVariables.Default.FeyDialogue.HasFullLetter = false;
        ArticyGlobalVariables.Default.FeyDialogue.HasLetter = false;
        ArticyGlobalVariables.Default.FeyDialogue.Introduced = false;

        flowPlayer = GetComponent<ArticyFlowPlayer>();
        InventoryManagerWithEvents.OnLetterCompleted += TriggerLetterCompleted;
        
    }

    public void StartDialogue(IArticyObject aObject)
    {
        
        DialogueActive = true;
        dialogueWidget.SetActive(DialogueActive);
        flowPlayer.StartOn = aObject;

    }

    public void CloseDialogueBox()
    {
        DialogueActive = false;
        dialogueWidget.SetActive(DialogueActive);
        flowPlayer.FinishCurrentPausedObject();

        if (ArticyGlobalVariables.Default.FeyDialogue.ShopOpen == true)
        {
            conceptShop.SetActive(true);
            
        }
    }

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        dialogueText.text = string.Empty;
        dialogueSpeaker.text = string.Empty;

        var ObjectWithText = aObject as IObjectWithText;
        if (ObjectWithText != null)
        {
            dialogueText.text = ObjectWithText.Text;
        }

        var objectWithSpeaker = aObject as IObjectWithSpeaker;
        if (objectWithSpeaker != null)
        {
            var speakerEntity = objectWithSpeaker.Speaker as Entity;
            if (speakerEntity != null)
            {
                dialogueSpeaker.text = speakerEntity.DisplayName;
            }
        }

        if (ArticyGlobalVariables.Default.FeyDialogue.HasLetter == true)
        {
            letterButtonObj.SetActive(true);
            OnLetterActive();
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        ClearAllBranches();

        bool dialogueIsFinished = true;
        foreach (var branch in aBranches)
        {
            if (branch.Target is IDialogueFragment)
            {
                dialogueIsFinished = false;
            }
        }

        if (!dialogueIsFinished)
        {
            foreach (var branch in aBranches)
            {
                GameObject btn = Instantiate(branchPrefab, branchLayoutPanel);
                btn.GetComponent<BranchChoice>().AssignBranch(flowPlayer, branch);
            }
        }
        else
        {
            GameObject btn = Instantiate(closePrefab, branchLayoutPanel);
            var btnComp = btn.GetComponent<Button>();
            btnComp.onClick.AddListener(CloseDialogueBox);
        }

        void ClearAllBranches()
        {
            foreach (Transform child in branchLayoutPanel)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void TriggerLetterCompleted()
    {
        ArticyGlobalVariables.Default.FeyDialogue.HasFullLetter = true;
    }
}

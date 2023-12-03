using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;

public class PlayerDialogueManager : MonoBehaviour
{
    private ArticyObject articyObject;

    private DialogueManager dialogueManager;
    public ArticyObject availableDialogue;

    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInteraction();
    }

    void PlayerInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F) && availableDialogue)
        {
            Debug.Log("Player Started Dialogue");
            dialogueManager.StartDialogue(availableDialogue);
        }

        // Key option to abort dialogue
        if (dialogueManager.DialogueActive && Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.CloseDialogueBox();
        }
    }

    // Trigger Enter/Exit used to determine if interaction with NPC is possible
    void OnTriggerEnter2D(Collider2D aOther)
    {
        Debug.Log("Player near NPC");
        var articyReferenceComp = aOther.GetComponent<ArticyReference>();
        if (articyReferenceComp)
        {
            availableDialogue = articyReferenceComp.reference.GetObject();
        }

    }

    void OnTriggerExit2D(Collider2D aOther)
    {
        if (aOther.GetComponent<ArticyReference>() != null)
        {
            availableDialogue = null;
        }
    }
}

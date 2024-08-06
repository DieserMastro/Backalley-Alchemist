using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    [SerializeField]
    protected Canvas canvas;

    [SerializeField]
    protected GameObject npc;
    [SerializeField]
    protected GameObject nextSceneButton;
    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    public Animator animator;
    //private CanvasController canvasController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //canvasController = GetComponent<CanvasController>();
        isDialogueActive = true;
        //canvasController.ShowCanvas();
        //animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }
    public void AssignNPC(GameObject npc)
    {
        if (npc == null)
        {
            Debug.Log("Null Exception");
            return;
        }
        this.npc = npc;
    }
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

       // characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        lines.Clear();
        //CanvasController cc = GetComponent<CanvasController>();
        /*if (canvasController != null)
        {
            canvasController.HideCanvas();
            Debug.Log("Canvas is Hidden");
        }
        
        NPC_Controller npcController = this.npc.GetComponent<NPC_Controller>();
        Debug.Log(npcController.ToString());
        if (npcController != null)
        {
            Debug.Log("npcController != null");
            npcController.SetDialogueOver();

        }
        nextSceneButton.SetActive(true);
        //animator.Play("hide");*/
    }
}
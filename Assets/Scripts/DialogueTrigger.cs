using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private GameObject npc;
    private DialogueManager dm;
   

    public void Start()
    {
        
        npc = this.gameObject;
        Debug.Log(npc.name);
        dm = FindObjectOfType<DialogueManager>();
    }
    public void TriggerDialogue()
    {
        
        dm.AssignNPC(npc);
        DialogueManager.Instance.StartDialogue(dialogue);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("DialogueTrigger"))
        {
            Debug.Log("Collided with Trigger");
            

            // Debug.Log(npc.name + "this is the collision object")
            if (dm != null)
            {
                TriggerDialogue();
            }
        }
    }
}
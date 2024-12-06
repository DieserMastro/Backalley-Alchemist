using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public Game_Controller()
    {

    }

    public int currentGameState;
    protected int days_Passed;

    [SerializeField]
    protected GameObject dialogueTrigger;
    [SerializeField]
    private GameObject npc;
    private Vector2 dialogueTriggerPos;

    private int getCounter = 0;
    public enum gameState
    {
        MAIN_MENU,
        PAUSE,
        BAR,
        LAPTOP,
        LAB,
        ON_MISSION,
        COMBAT,
        PUZZLE
    }
    
    private Scene currentScene;
        
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentGameState = currentScene.buildIndex;
        dialogueTriggerPos = dialogueTrigger.transform.position;
        npc.SetActive(true);
    }

    

    public void newScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    public Vector2 GetDTriggerPos()
    {
        getCounter++;
        Debug.Log(dialogueTriggerPos.ToString() + "here! at: " + getCounter);
        return dialogueTriggerPos;
    }
    public void TriggerDialogue()
    {
        Debug.Log("Dialogue Triggered!");
    }
    public void TestReference()
    {
        Debug.Log("call is valid :D");
    }
}

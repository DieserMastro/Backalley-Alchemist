using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    /*public int currentGameState;
    public enum gameState
    {
        MAIN_MENU,
        PAUSE,
        BAR,
        LAB,
        ON_MISSION,
        COMBAT,
        PUZZLE
    }*/
    [SerializeField]
    private GameObject dialogueTrigger;
    private Vector2 dialogueTriggerPos;
    private Scene currentScene;
        
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        dialogueTriggerPos = dialogueTrigger.transform.position;
    }

    

    public void newScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public Vector2 getDialogueTriggerPos()
    {
        return dialogueTriggerPos;
    }
}

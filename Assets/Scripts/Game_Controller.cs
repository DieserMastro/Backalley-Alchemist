using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public int currentGameState;
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
    [SerializeField]
    private List<Scene> connectedScenes;
    private Scene currentScene;
        
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentGameState = currentScene.buildIndex;
    }

    

    public void newScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    public void moveScene(int sceneIndex)
    {
        SceneManager.SetActiveScene(connectedScenes[sceneIndex]);
    }
    public void preloadHubArea()
    {
        foreach (Scene scene in connectedScenes)
        {
            SceneManager.LoadSceneAsync(scene.buildIndex);
        }
    }
}

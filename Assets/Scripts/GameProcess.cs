using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartInterface()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(1);
    }
}

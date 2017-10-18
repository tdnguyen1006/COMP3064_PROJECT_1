using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour {
    
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name); //Switch scenes
    }
}

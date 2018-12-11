using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void SceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public string sceneName = "cafe_terrace";
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

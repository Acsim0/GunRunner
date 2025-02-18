using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainscreen_script : MonoBehaviour
{
    public void PlayedGame()
    {
        SceneManager.LoadScene("Play");
    }
}

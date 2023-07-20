using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    //public static bool GameIsEnd = false;

    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu");
    }
}

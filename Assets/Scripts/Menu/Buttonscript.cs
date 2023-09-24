using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonscript : MonoBehaviour
{
    public int scenenumber;
    public void Quitgame()
    {
        Application.Quit();   
    }


    public void changemenuscene()
    {
        SceneManager.LoadScene(scenenumber);

    }



}

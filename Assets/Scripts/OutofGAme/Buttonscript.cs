using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonscript : MonoBehaviour
{
    public int scenenumber;
    [SerializeField] Transform BgImage;
    [SerializeField] Transform start;
    [SerializeField] Transform quit;
    [SerializeField] Transform options;
    [SerializeField] Transform quitthegame;

    [SerializeField] GameObject CloseMenu;
    [SerializeField] GameObject clicktocontinue;

    public void Awake()
    {
        start.transform.LeanScale(new Vector2(0, 0), 0.1f);
        quit.transform.LeanScale(new Vector2(0, 0), 0.1f);
        options.transform.LeanScale(new Vector2(0, 0), 0.1f);
    }
    public void Quitgame()
    {
        Application.Quit();   
    }


    public void changemenuscene()
    {
        SceneManager.LoadScene(scenenumber);

    }


    public void ZoomIn()
    {
        clicktocontinue.SetActive(false);
        BgImage.transform.LeanMoveLocal(new Vector2(-914, -170),1);
        BgImage.transform.LeanScale(new Vector2(2.5f, 2.5f), 1);
        quitthegame.transform.LeanScale(new Vector2(0, 0), 0.3f);
        StartCoroutine(Waittstard());
    }


    public void ZoomOut()
    {
        BgImage.transform.LeanMoveLocal(new Vector2(0, 0), 1);
        BgImage.transform.LeanScale(new Vector2(1f, 1f), 1);
        quitthegame.transform.LeanScale(new Vector2(0.4f, 0.4f), 0.3f);
        ButtonpopCLOSE();
    }

  

    public IEnumerator Waittstard()
    {
        yield return new WaitForSeconds(1f);

        ButtonpopOPEN();
    }
    public void ButtonpopOPEN()
    {

        start.transform.LeanScale(new Vector2(0.4f, 0.4f), 0.3f);
        quit.transform.LeanScale(new Vector2(0.4f, 0.4f), 0.3f);
        options.transform.LeanScale(new Vector2(0.4f, 0.4f), 0.3f);
    }

    public void ButtonpopCLOSE()
    {
        clicktocontinue.SetActive(true);
        start.transform.LeanScale(new Vector2(0, 0), 0.3f);
        quit.transform.LeanScale(new Vector2(0, 0), 0.3f);
        options.transform.LeanScale(new Vector2(0, 0), 0.3f);
    }


    public void OpenCloseMenu()
    {
        CloseMenu.SetActive(true);
        
    }
    public void CloseCloseMenu()
    {
        CloseMenu.SetActive(false);

    }
}

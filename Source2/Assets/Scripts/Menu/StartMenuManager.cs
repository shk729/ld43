using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {
    public GameObject creditsPanel;



    public void OnStartPress() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");

    }

    public void OnCreditPress()
    {
        creditsPanel.SetActive(true);

    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

    public void onCreditClose()
    {
        creditsPanel.SetActive(false);
    }
}

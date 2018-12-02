using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {




    public void OnStartPress() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");

    }

    public void OnCreditPress()
    {

    }

    public void OnQuitPress()
    {

    }
}

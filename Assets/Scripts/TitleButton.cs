using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton: MonoBehaviour
{
    public void aqua3dBtn()
    {
        SceneManager.LoadScene("aqua3d");
    }
    public void fukushimaBtn()
    {
        SceneManager.LoadScene("fukushima");
    }
    public void okuyamaBtn()
    {
        SceneManager.LoadScene("okuyama");
    }
    public void yamamotoBtn()
    {
        SceneManager.LoadScene("yamamoto");
    }
    public void TitleBtn()
    {
        SceneManager.LoadScene("StartGameScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager_Buttons : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("end");
        Application.Quit();
    }

    public void Reload()
    {
        Debug.Log("reload");
       SceneManager.LoadScene("Scene_1");
    }
}

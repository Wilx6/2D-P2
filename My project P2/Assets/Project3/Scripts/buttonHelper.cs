using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHelper : MonoBehaviour
{

    public textGameManager myMgr;

    public void Start()
    {
        myMgr = FindObjectOfType<textGameManager>();
    }

    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed the button!");
        SceneManager.LoadScene(sceneName);
    }

    public void AddToInventory(string item)
    {
        myMgr.myInventory.Add(item);
    }

    public void EnableObject(GameObject target)
    {
        target.SetActive(true);
    }

    public void SetName(string name)
    {
        myMgr.name = name;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHelper : MonoBehaviour
{

    

    public void Start()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        Debug.Log("Pressed the button!");
        SceneManager.LoadScene(sceneName);
    }

    public void AddToInventory(string item)
    {
        
    }

    public void EnableObject(GameObject target)
    {
        target.SetActive(true);
    }

    public void SetName(string name)
    {
        
    }

}

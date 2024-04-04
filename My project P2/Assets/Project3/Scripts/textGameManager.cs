using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class textGameManager : MonoBehaviour
{

    private static textGameManager _MgrInstance;

    public static textGameManager myInstance
    {
        get
        { 
            if(_MgrInstance == null)
            {
                GameObject myGO = new GameObject("GameManager");
                myGO.AddComponent<textGameManager>();
                DontDestroyOnLoad(myGO);
            }
            return _MgrInstance;
        }

        
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializeManager()
    {
        textGameManager newMgr = textGameManager.myInstance;
    }

    public List<string> myInventory;

    public TMP_InputField myInput;
    public string playerName;

    public GameObject inputField;
    public GameObject sumbitButton;
    public GameObject WelcomeObject;
    public GameObject sceneChanager;
    TextMeshProUGUI WelcomeText;

    public string welcomeMessage;
    public string replaceText;


    // Start is called before the first frame update
    void Start()
    {
        WelcomeText = WelcomeObject.GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        playerName = myInput.text;

        sumbitButton.SetActive(false);
        inputField.SetActive(false);


        string newWelcome = welcomeMessage.Replace(replaceText, playerName);
        WelcomeText.text = newWelcome;

        sceneChanager.SetActive(true);

    }

}

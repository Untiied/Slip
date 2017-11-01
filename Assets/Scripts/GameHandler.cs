using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    #region AdVariables
    public static int AdMode = 1;
    public static string AdModeAll = "All Ads On";
    public static string AdModeSome = "Some Ads On";
    public static string AdModeNone = "No Ads On";

    public Text TBox;
    #endregion


    public static bool PostProcessing;
    public static int Coin;
    public static int LevelAmount = 12;
    public GameObject LevelButton;
    public GameObject LevelHolder;
    public GameObject MainMenu;
    public GameObject LevelMenu;
    public GameObject CoinHandler;

    //Singleton for checking to see if alive
    public static GameHandler Instance;

    void Awake()
    {
        /*
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform);
        }*/
    }
    void Start()
    {
        Coin = 5;
        if (Advertisments.Load())
        {
            print("Advertisments Loaded");
        }
        CheckAdMode();
        if (AdMode == 1)
        {
            Advertisments.ShowBanner();
        }
        else if (AdMode == 2)
        {
            Advertisments.ShowBanner();
        }

        CoinHandler.GetComponentInChildren<TextMesh>().text = Coin.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && LevelMenu.activeInHierarchy == true)
        {
            LevelMenu.SetActive(false);
            MainMenu.SetActive(true);
        }

    }

    public void AdButton()
    {
        AdMode++;

        if (AdMode > 3)
        {
            AdMode = 1;
        }

        CheckAdMode();

    }

    void CheckAdMode()
    {
        if (AdMode == 1)
        {
            TBox.text = AdModeAll;
        }
        else if (AdMode == 2)
        {
            TBox.text = AdModeSome;
        }
        else if (AdMode == 3)
        {
            TBox.text = AdModeNone;
        }
    }

    public void LoadLevelMenu()
    {
        MainMenu.SetActive(false);
        LevelMenu.SetActive(true);
        LevelMenu.transform.GetChild(0).transform.gameObject.SetActive(true);

        for (int i = 0; i < LevelAmount - 1; i++)
        {
            GameObject Child = Instantiate(LevelButton) as GameObject;
            Child.transform.SetParent(LevelHolder.transform);
            Child.transform.localScale = new Vector3(1, 1, 1);
            int y = i;
            y++;
            Child.GetComponentInChildren<UnityEngine.UI.Text>().text = y.ToString();

            Child.GetComponent<Button>().onClick.AddListener(() => { GoToLevel(Child); });
        }
    }

    public void GoToLevel(GameObject Button)
    {
        Advertisments.bannerView.Destroy();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level" + Button.GetComponentInChildren<UnityEngine.UI.Text>().text);
    }
}


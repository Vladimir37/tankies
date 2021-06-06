using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }
    
    public enum DefeatTypes
    {
        TankDestroyed,
        HQDestroyed,
    }

    [SerializeField]
    private GameObject defeatWindow;

    [SerializeField]
    private Text defeatTypeText;
    
    [SerializeField]
    private GameObject winWindow;
    
    private Dictionary<DefeatTypes, String> defeatText = new Dictionary<DefeatTypes, string>()
    {
        {DefeatTypes.TankDestroyed, "Ваш танк уничтожен"},
        {DefeatTypes.HQDestroyed, "Ваш штаб уничтожен"},
    };

    public void LoseTheGame(DefeatTypes type)
    {
        defeatTypeText.text = defeatText[type];
        defeatWindow.SetActive(true);

        Time.timeScale = 0;
    }

    public void WinTheGame()
    {
        winWindow.SetActive(true);
        
        Time.timeScale = 0;
    }
}

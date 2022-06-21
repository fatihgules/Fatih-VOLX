using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int Money;
    public int Goal; //LevelComplete Check
    public int Level;

   void Awake()
   {
    Instance=this;
   }


    void Start()
    {
        Money=PlayerPrefs.GetInt("Money");
        Level=PlayerPrefs.GetInt("Level");
    }

    
    void Update()
    {
        
    }

    public void AddGoalScore()
    {
        Goal++;
    }

    public void NextLevel()
    {
        Level++;
        PlayerPrefs.SetInt("Level",Level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    


}

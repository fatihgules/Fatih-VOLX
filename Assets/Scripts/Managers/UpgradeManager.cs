using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance {get; private set;}
    public int SpeedLevel;
    public int SpeedCost;

    public int StackLevel;
    public int StackCost;
    void Awake()
    {
        Instance=this;
    }
    void Start()
    {
   
      InitializeData();


    }



     public void SpeedUp()
     {
        if(SpeedLevel<3)
        {
            if(GameManager.Instance.Money>=SpeedCost)//Check Money&Speed Cost
            {
        var MoneyDataSet=GameManager.Instance.Money-=SpeedCost;//Set MoneyData
        PlayerPrefs.SetInt("Money",MoneyDataSet); //Money Data Save Memory 

        SpeedLevel++;//SpeedLevelUP
        PlayerPrefs.SetInt("SpeedLevel",SpeedLevel);//Save SpeedLevel Save Memory

        var SpeedDataSet=PlayerController.Instance.Speed+=2;//Set Speed Data
        PlayerPrefs.SetFloat("Speed",SpeedDataSet);//Speed Data Save Memory

        var SpeedCostChange= SpeedCost+=50;// Set Cost
        PlayerPrefs.SetInt("SpeedCost",SpeedCostChange);//Cost Data Save Memory

        UIManager.Instance.ChangeSpeedLevelText();// Change Text Value Function
            }
        }
     }


     public void StackUp()
     {
        if(StackLevel<3)
        {
            if(GameManager.Instance.Money>=StackCost)//Check Money&Speed Cost
            {
        var MoneyDataSet=GameManager.Instance.Money-=StackCost;//Set MoneyData
        PlayerPrefs.SetInt("Money",MoneyDataSet); //Money Data Save Memory 

        StackLevel++;//SpeedLevelUP
        PlayerPrefs.SetInt("StackLevel",StackLevel);//Save StackLevel Save Memory

        var StackDataSet=CollectManager.Instance.StackLimit+=1;//Set StackLimit Data
        PlayerPrefs.SetInt("StackLimit",StackDataSet);//Speed Data Save Memory

        var StackCostChange= StackCost+=100;// Set Cost
        PlayerPrefs.SetInt("StackCost",StackCostChange);//Cost Data Save Memory
        UIManager.Instance.ChangeStackLevelText();// Change Text Value Function

            }

        }

     }


     void InitializeData()
     {
    SpeedLevel=PlayerPrefs.GetInt("SpeedLevel");//Get SpeedLevel Data 
    SpeedCost=PlayerPrefs.GetInt("SpeedCost");//Get SpeedCost Data

    StackCost=PlayerPrefs.GetInt("StackCost");//Get StackCost Data;
    StackLevel=PlayerPrefs.GetInt("StackLevel");//Get StackLevel Data;
    if(SpeedLevel==0)
    {
        SpeedCost=50;
        PlayerController.Instance.Speed=5;
          }

    else {
        SpeedCost=SpeedCost;
    }//First Game SpeedCost Settings

    if(StackLevel==0)
    {StackCost=100;
     CollectManager.Instance.StackLimit=3;
      } 

    else {
    StackCost=StackCost;
    }//First Game StackCost Settings
     }



}

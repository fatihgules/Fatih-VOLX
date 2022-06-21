using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static UIManager Instance {get; private set;}
    #endregion
    
    public GameObject UpgradeUI;
    public GameObject LevelCompleteUI;
    public TextMeshProUGUI SpeedLevelText;
    public TextMeshProUGUI SpeedCostText;
    public TextMeshProUGUI StackLevelText;
    public TextMeshProUGUI StackCostText;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI LevelText;

  

    void Awake()
    {
        Instance=this;
    }

    void Start()
    {
        //Data Start Text Get&&Check
        DataTextValuesCheck();

        
        var LevelData=GameManager.Instance.Level+1;
        LevelText.text=("LEVEL "+LevelData);
        MoneyText.text=GameManager.Instance.Money.ToString();

    }




    
   public void UpgradeOpen()
   {
     UpgradeUI.gameObject.SetActive(true);
   }

   public void UpgradeClose()
   {
    UpgradeUI.gameObject.SetActive(false);
   }

   public void ChangeMoneyText()
   {
    var MoneyChangeData= GameManager.Instance.Money+=2;
    PlayerPrefs.SetInt("Money",MoneyChangeData);
    MoneyText.text=GameManager.Instance.Money.ToString();

   }


   public void LevelComplete()
   {
      var GoalData=GameManager.Instance.Goal;
      if(GoalData==2)
      {
        LevelCompleteUI.gameObject.SetActive(true);
      }
   }




   public void ChangeSpeedLevelText()
   {
    var SpeedLevelData=UpgradeManager.Instance.SpeedLevel+1;
     if(UpgradeManager.Instance.SpeedLevel<3)
     {
        
      SpeedLevelText.text=("LEVEL "+SpeedLevelData);
      SpeedCostText.text=("Cost:"+UpgradeManager.Instance.SpeedCost);
      MoneyText.text=GameManager.Instance.Money.ToString();
     }

     else
     {
      SpeedLevelText.text=("LEVEL "+SpeedLevelData);
      SpeedCostText.text=("MAX");
     }

   
   }

   public void ChangeStackLevelText()
   {
    var StackLevelData=UpgradeManager.Instance.StackLevel+1;
     if(UpgradeManager.Instance.StackLevel<3)
     {

         StackLevelText.text=("LEVEL "+StackLevelData);
         StackCostText.text=("Cost:"+UpgradeManager.Instance.StackCost);
         MoneyText.text=GameManager.Instance.Money.ToString();
     }
     else
     {
         StackLevelText.text=("LEVEL "+StackLevelData);
         StackCostText.text=("MAX");
     }
   }


   public void DataTextValuesCheck()
   {
    ChangeStackLevelText();
    ChangeSpeedLevelText();

   }


}

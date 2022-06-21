using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
   public List<GameObject> MoneyList= new List<GameObject>();
   public Transform MoneySpawnPoint;
   public GameObject MoneyPrefab;
   
     public void MoneyClone()
     {
        GameObject MoneyObj=Instantiate(MoneyPrefab);
        MoneyObj.transform.position=new Vector3(MoneySpawnPoint.position.x,MoneyList.Count+.5f,MoneySpawnPoint.position.z);
        MoneyList.Add(MoneyObj);
     }

     public void DeleteMoney()
     {
        Destroy(MoneyList[MoneyList.Count-1]);
        MoneyList.RemoveAt(MoneyList.Count-1);
     }



}

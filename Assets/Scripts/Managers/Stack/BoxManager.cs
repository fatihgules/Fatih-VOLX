using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public List<GameObject> Box=new List<GameObject>();
    public GameObject BoxPrefab;
    public Transform BoxSpawnPoint;
    bool isStack;
    public float StackDuration;
    public int StackLimit;
    void Start()
    {
        StartCoroutine(SpawnBox(StackDuration));//Work SpawnBox 
    }

    IEnumerator SpawnBox(float duration)
    {
        while(true)
        {
          if(isStack)
          {
          GameObject BoxObj=Instantiate(BoxPrefab,BoxSpawnPoint);
          BoxObj.transform.position=new Vector3(BoxSpawnPoint.position.x,Box.Count+.5f,BoxSpawnPoint.position.z);//Clone Object y+
          Box.Add(BoxObj);// BoxPrefab AddList
           if(Box.Count>=StackLimit)//Box Count&StackLimit Check
           {
           isStack=false;
           }
          }

         else if(Box.Count<StackLimit){
            isStack=true;
         }


          yield return new WaitForSeconds(duration);//Box Clone Time
        }
        
    }


    public void DeleteBox()
    {
        if(Box.Count>0)//List item Check
        {
          Destroy(Box[Box.Count-1]);
          Box.RemoveAt(Box.Count-1);
          
        }
    }


}

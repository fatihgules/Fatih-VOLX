using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUs : MonoBehaviour
{
   public void Web()
   {
     string URL = "https://www.linkedin.com/in/fatih-g%C3%BCle%C5%9F-2697a611b";
     Application.OpenURL(URL);
   }
}

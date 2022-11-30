using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Timer : MonoBehaviour
{
   private float startTime = -1f;

   public void StartTimer()
   {
      startTime = Time.time;
   }
   
   public float StopTimer()
   {
      startTime = -1f;
      return Time.time - startTime;
   }
}

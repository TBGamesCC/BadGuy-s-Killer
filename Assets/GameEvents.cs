using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{
    public struct ThifeData
    {
        public int AddMoney;
        public bool IsDie;
    }
    public static  Action< ThifeData> ThiefDie;
}

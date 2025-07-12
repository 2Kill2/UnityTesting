using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyTypes : MonoBehaviour
{
    //Gun = walks up to the player and shoots at them
    //Sniper = stays at a distance and shoots at the player, runs away when the player gets too close
    //Boss = A Hind D helicopter that flies around and shoots at the player, hovers in a figure eight 
    public enum EnemyType
    {
        Gun,
        Sniper,
        Boss
    }
}

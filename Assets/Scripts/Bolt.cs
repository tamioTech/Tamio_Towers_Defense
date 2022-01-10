using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] int damage = 10;


    public int BoltDamage()
    {
        return damage;
    }


}

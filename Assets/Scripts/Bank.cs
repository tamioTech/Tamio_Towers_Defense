using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int GetCurrentBalance { get { return currentBalance; } }
    
    // Start is called before the first frame update
    void Awake()
    {
        currentBalance = startingBalance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
    }
}

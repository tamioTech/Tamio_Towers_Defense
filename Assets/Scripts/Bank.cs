using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int GetCurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI gameOverText;


    // Start is called before the first frame update
    void Awake()
    {
        currentBalance = startingBalance;
        gameOverText.gameObject.SetActive(false);
        UpdateGoldDisplay();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateGoldDisplay();

    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateGoldDisplay();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    private void UpdateGoldDisplay()
    {
        goldText.text = "Gold: " + currentBalance;

    }
}

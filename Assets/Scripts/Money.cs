using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount;
    public TextMeshProUGUI amountTXT;

    void Start()
    {
        amount = 100;
    }

    // Update is called once per frame
    void Update()
    {
        amountTXT.text = "$" + amount.ToString();
        
    }
    public void Buying(int cost)
    {
        amount -= cost;
    }
}

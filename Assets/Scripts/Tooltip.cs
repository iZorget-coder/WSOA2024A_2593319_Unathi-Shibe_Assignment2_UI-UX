using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;
    public TextMeshProUGUI text;
    public Vector3 offset;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else { Instance = this; }
    }
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition + offset; 

    }
    public void ShowTip(string message)
    {
          gameObject.SetActive(true);
        text.text = message;
    }
    public void HideTip(string message)
    {
        gameObject.SetActive(false);
        text.text = string.Empty;
    }
}

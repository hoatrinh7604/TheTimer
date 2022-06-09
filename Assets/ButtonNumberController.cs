using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonNumberController : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI textValue;
    [SerializeField] int hour, minute;

    private void Start()
    {
        button.onClick.AddListener(() => OnPressButton());
    }

    public void SetInfo(int hour, int minute)
    {
        this.hour = hour;
        this.minute = minute;
        textValue.text = hour + "h" + minute + "m";
    }

    public void OnPressButton()
    {
        GamePlayController.Instance.OnPressHandle(hour, minute);
        button.gameObject.SetActive(false);
    }
}

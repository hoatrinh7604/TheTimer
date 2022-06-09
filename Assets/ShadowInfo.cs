using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowInfo : MonoBehaviour
{
    [SerializeField] int triangle;
    [SerializeField] RectTransform hour, minute;
    [SerializeField] float[] hourScale, minuteScale;
    public int GetTriangle()
    {
        return triangle;
    }

    public void UpdateTime(int hourTime, int minuteTime)
    {
        float scaleH = 0;
        float scale_m = 0;
        int temp = minuteTime / 5;

        scale_m += hourScale[temp];
        if (temp == 11)
        {
            scale_m += (minuteScale[0] - minuteScale[temp]) * (minuteTime - temp * 5) / 5;
        }
        else
        {
            scale_m += (minuteScale[temp + 1] - minuteScale[temp]) * (minuteTime - temp * 5) / 5;
        }

        if (hourTime == 11)
        {
            scaleH += hourScale[hourTime] + (hourScale[0] - hourScale[hourTime]) * minuteTime / 60;
        }else
        {
            scaleH += hourScale[hourTime] + (hourScale[hourTime+1] - hourScale[hourTime]) * minuteTime / 60;
        }

        hour.transform.localRotation = Quaternion.Euler(hour.transform.localRotation.x, hour.transform.localRotation.y, scaleH);
        minute.transform.localRotation = Quaternion.Euler(minute.transform.localRotation.x, minute.transform.localRotation.y, scale_m);
    }
}

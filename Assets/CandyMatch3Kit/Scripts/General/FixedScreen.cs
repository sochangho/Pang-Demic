using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedScreen : MonoBehaviour
{
    private void Start()
    {
        SetResolution(); // 초기에 게임 해상도 고정
    }

    /* 해상도 설정하는 함수 */
    public void SetResolution()
    {
        Camera camera = GetComponent<Camera>();

        Rect rect = camera.rect;

        float scaleheight = ((float)Screen.width / Screen.height) / ((float)9 / 16);
        float scalewidth = 1f / scaleheight;

        if(scaleheight < 1) {

            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {

            rect.width = scaleheight;
            rect.x = (1f - scalewidth) / 2f;

        }

        camera.rect = rect;
   
    }
}



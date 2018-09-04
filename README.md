# UnityMsgBox
![image](https://user-images.githubusercontent.com/31759313/45017027-6f466200-b061-11e8-96d4-664c929ec0e6.png)
유니티 대화상자 예제소스입니다.

핵심은 아래 코드입니다.
CreateMsg.cs

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMsg : MonoBehaviour
{

    public Image image;
    public Text text;
    public static CreateMsg instance;
    private string[] mLine;
    private bool isShow = false;
    private bool isEnd = false;
    private int idx;
    private int page;
    // Use this for initialization
    void Start()
    {
        if (!instance)
            instance = this;

        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 다음 대화를 보고 싶으면 어떤 행동을 해야 하는지 설정한다.(여기서는 마우스 좌클릭)
        {
            if (isEnd) // 끝나면 지운다
            {
                init();
            }
            if (isShow) // 대화상자가 활성화 돼있으면
            {
                page++;
                idx = 0;
            }

            if (page == mLine.Length - 1)
            { // 마지막 페이지 입니다.
                isEnd = true;
            }
        }
        if (mLine != null && page < mLine.Length)
        {
            if (isShow && idx < mLine[page].Length)
            {
                text.text = mLine[page].Substring(0, idx);
                idx++;
            }

        }

    }

    public void show(string[] line)
    {
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        mLine = line;
        isShow = true;
    }
    public void init()
    {
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        isEnd = false;
        isShow = false;
        idx = 0;
        page = 0;
    }
}
```

# 사용법

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMsg : MonoBehaviour
{

    private string[] lines = { "테스트1테스트1테스트1테스트1테스트1테스트1테스트1테스트1테스트1테스트1",
        "테스트2테스트2테스트2테스트2테스트2테스트2테스트2테스트2테스트2테스트2테스트2",
        "테스트3테스트3테스트3테스트3테스트3테스트3테스트3테스트3테스트3테스트3테스트3" };

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 대화상자가 활성화되는 타이밍을 설정한다.(여기서는 마우스 우클릭)
        {
            CreateMsg.instance.show(lines);
        }
    }
}

```

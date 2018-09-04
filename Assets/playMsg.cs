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

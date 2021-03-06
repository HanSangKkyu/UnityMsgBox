﻿using System.Collections;
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

            if (page == mLine.Length - 1)
            { // 마지막 페이지 입니다.
                init();
            }

            if (isShow) // 대화상자가 활성화 돼있으면
            {
                page++;
                idx = 0;
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

    public void show(string[] lines)
    {
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        mLine = lines;
        isShow = true;
    }

    public void show(string line)
    {
        image.gameObject.SetActive(true);
        text.gameObject.SetActive(true);

        string[] convertLine = new string[1]; ;
        convertLine[0] = line;
        mLine = convertLine;
        isShow = true;
    }
    public void init()
    {
        image.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        isShow = false;
        idx = 0;
        page = 0;
    }

}

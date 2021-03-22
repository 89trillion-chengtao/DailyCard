using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using script;

public class DailyManage : MonoBehaviour
{
    [SerializeField] private Card cardItemPrefab;
    [SerializeField] private RectTransform cardWindow;
    [SerializeField] private TextMeshProUGUI Countdown;

    private DailyData dailyData;
    private int Count = 6; // 商品格子对数量
    private int curCountTime;
    private void Start()
    {
        LoadData();
        LoadCardItems();
        StartCoroutine(CountDownTimer());
    }

    private void LoadCardItems()
    {
        foreach (var dailyProduct in dailyData.dailyProduct)
        {
            Card item = Instantiate(cardItemPrefab, cardWindow);
            item.SetUp(dailyProduct);
        }

        if (dailyData.dailyProduct.Count < Count)
        {
            for (int i = 0; i < Count - dailyData.dailyProduct.Count; i++)
            {
                Card item = Instantiate(cardItemPrefab, cardWindow);
                item.SetUp(null);
            }
        }
        
        curCountTime = TimeUtil.GetTimeSec(dailyData.dailyProductCountDown);
    }
    
    private void LoadData()
    {
        string str = "";
        string path = "./data.json";
        str = File.ReadAllText(path);
        dailyData = JsonConvert.DeserializeObject<DailyData>(str);
    }
    
    IEnumerator CountDownTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            curCountTime -= 1;
            Countdown.text = "Refresh time: " + $"{TimeUtil.TimeFormatInHrsMinSec(curCountTime)}";
        }
    }
        
}
        

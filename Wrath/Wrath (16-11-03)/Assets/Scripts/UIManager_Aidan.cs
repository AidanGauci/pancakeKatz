using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager_Aidan : MonoBehaviour {

    public Text allyText;
    public Text allyCount;
    public Text swordText;
    public Text[] saveAllyTexts;
    public Image[] saveAllyBackgrounds;
    public Image swordTextBackground;
    public Image[] healthIcons;
    public int allyCurrentCount { get; private set; }
    public bool wallTriggered = false;

    float deactivateTime1;
    float deactivateTime2;

    void Update()
    {
        if (deactivateTime1 <= Time.time)
        {
            saveAllyTexts[0].text = "";
            saveAllyTexts[0].gameObject.SetActive(false);
            saveAllyBackgrounds[0].gameObject.SetActive(false);
        }
        if (deactivateTime2 <= Time.time)
        {
            saveAllyTexts[1].text = "";
            saveAllyTexts[1].gameObject.SetActive(false);
            saveAllyBackgrounds[1].gameObject.SetActive(false);
        }
        if (wallTriggered && !FindObjectOfType<Jailer_Aidan>().swordTaken)
        {
            swordText.gameObject.SetActive(true);
            swordTextBackground.gameObject.SetActive(true);
            swordText.text = "Get back to work!";
        }
        else if (!wallTriggered && !FindObjectOfType<Jailer_Aidan>().swordTaken)
        {
            swordText.text = "Press 'E' to pick up sword";
            swordText.gameObject.SetActive(false);
            swordTextBackground.gameObject.SetActive(false);
        }
    }

    public void OnAllyCountChange()
    {
        allyCurrentCount++;
        allyCount.text = allyCurrentCount + "/20";
    }

    public void ActivateText(string toSay, float stayTime)
    {
        if (saveAllyTexts[0].gameObject.activeSelf)
        {
            deactivateTime2 = Time.time + stayTime;
            saveAllyTexts[1].text = toSay;
            saveAllyTexts[1].gameObject.SetActive(true);
            saveAllyBackgrounds[1].gameObject.SetActive(true);
        }
        else
        {
            deactivateTime1 = Time.time + stayTime;
            saveAllyTexts[0].text = toSay;
            saveAllyTexts[0].gameObject.SetActive(true);
            saveAllyBackgrounds[0].gameObject.SetActive(true);
        }
    }
}

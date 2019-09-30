using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGMT_Summary : MonoBehaviour
{
    private bool resume;

    public Main_Game scriptMainGame;
    public Transform container;
    public Transform template;
    private float templateHeight = -100f;

    private static readonly string TEXT_PSEUDONYM = "Template_Pseudonym";
    private static readonly string TEXT_PLAYS     = "Template_Plays";
    private static readonly string TEXT_SCORE     = "Template_Score";
    private static readonly string TEXT_HP        = "Template_HP";

    private List<Transform> transforms;


    private void Awake()
    {
        resume = false;
        container.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            resume = !resume;
            container.gameObject.SetActive(resume);

            if (resume)
                CreerTable();
            else
                EffacerTable();
            template.gameObject.SetActive(!resume);
        }
    }




    private void CreerTable()
    {
        transforms = new List<Transform>();
        int i = 1;
        foreach (Player player in scriptMainGame.game.players)
            CreerTableRang(player, i++);
    }


    private void CreerTableRang(Player player, int rang)
    {
        Transform tableTransform = Instantiate(template, container);
        RectTransform tableRectTransform = tableTransform.GetComponent<RectTransform>();
        tableRectTransform.anchoredPosition = new Vector2(0, templateHeight * rang);

        tableTransform.Find(TEXT_PSEUDONYM).GetComponent<TMPro.TextMeshProUGUI>().text = player.pseudonym;
        tableTransform.Find(TEXT_PLAYS).GetComponent<TMPro.TextMeshProUGUI>().text = player.plays.ToString();
        tableTransform.Find(TEXT_SCORE).GetComponent<TMPro.TextMeshProUGUI>().text = player.points + " / " + scriptMainGame.game.pointsRequired;
        tableTransform.Find(TEXT_HP).GetComponent<TMPro.TextMeshProUGUI>().text = ((float)player.hp / (float)scriptMainGame.game.defaultHP * 100).ToString() + " %";
        
        transforms.Add(tableTransform);
    }


    private void EffacerTable()
    {
        foreach (Transform transform in transforms)
            Destroy(transform.gameObject, 0);
    }
}

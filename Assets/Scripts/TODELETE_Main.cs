using System.Collections.Generic;
using System.Xml;
using UnityEngine;


public class TODELETE_Main : MonoBehaviour
{
    void Start()
    {
        List<Monster> monsters = MGMT_Xml.GetDefaultMonsters();

        foreach (Monster monster in monsters)
            monster.Display();
    }
}

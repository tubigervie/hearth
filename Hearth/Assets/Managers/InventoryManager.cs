using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    SessionManager session;

    public void Init()
    {
        session = SessionManager.singleton;

        LoadInventory();
    }

    public void LoadInventory()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum ItemType
{
    wood, crystal
}

[System.Serializable]
public class Item
{
    public string itemID;
    public ItemType itemType;
    public int value;
}

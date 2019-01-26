using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    public static SessionManager singleton;

    [Header("In Inventory")]
    public int woodCount = 0;
    public int gemCount = 0;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string id)
    {
        Item i = null;
        i = ResourceManager.singleton.GetResourceItem(id);
        if(i != null)
        switch(i.itemType)
        {
            case ItemType.wood:
                woodCount += i.value;
                break;
            case ItemType.crystal:
                break;
        }
    }
}

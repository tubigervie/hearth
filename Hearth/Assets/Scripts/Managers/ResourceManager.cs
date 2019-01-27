using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
   public Dictionary<string, int> itemIDs = new Dictionary<string, int>();

    public static ResourceManager singleton;

    private void Awake()
    {
        singleton = this;
        LoadItemIds();
    }

    private void LoadItemIds()
    {
        ItemsScriptableObject obj = Resources.Load("ItemsScriptableObject") as ItemsScriptableObject;
        if (obj == null)
        {
            Debug.Log("ItemsScriptableObject could not be loaded.");
            return;
        }
        for(int i = 0; i < obj.resourceItems.Count; i++)
        {
            if(itemIDs.ContainsKey(obj.resourceItems[i].itemID))
            {
                Debug.Log("Item is a duplicate");
            }
            else
            {
                //Debug.Log(obj.resourceItems[i].itemID + " has been added!");
                itemIDs.Add(obj.resourceItems[i].itemID, i);
            }
        }
    }

    int GetIndexFromString(Dictionary<string, int> d, string id)
    {
        int index = -1;
        d.TryGetValue(id, out index);
        return index;
    }

    public Item GetResourceItem(string id)
    {
        ItemsScriptableObject obj = Resources.Load("ItemsScriptableObject") as ItemsScriptableObject;
        if (obj == null)
        {
            Debug.Log("ItemsScriptableObject couldn't be loaded!");
            return null;
        }
        int index = GetIndexFromString(itemIDs, id);
        if (index == -1)
            return null;
        return obj.resourceItems[index];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

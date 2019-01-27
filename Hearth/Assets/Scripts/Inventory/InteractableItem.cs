using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public string itemName; //MUST MATCH ITS EQUIVALENT ITEM ID
    public bool isRespawnable;
    bool startCount;
    public float count = 30;
    [SerializeField] GameObject model;
    [SerializeField] BoxCollider itemCollider;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(startCount)
        {
            count -= Time.deltaTime;
            if(count <= 0)
            {
                count = 30;
                itemCollider.enabled = true;
                model.SetActive(true);
                startCount = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Im in");
        SessionManager.singleton.AddItem(itemName);
        if(isRespawnable && gameObject.activeSelf)
        {
            itemCollider.enabled = false;
            model.SetActive(false);
            startCount = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftList : MonoBehaviour
{
    [SerializeField] 
    private GameObject listObject;
    [SerializeField] 
    private Text name, desc, requestIngredient;
    [SerializeField] 
    private Image profile;
    [SerializeField]
    private Transform content;
    [SerializeField] 
    private CraftInfo[] craftInfos;
    [SerializeField] 
    private ItemInfo[] itemInfos;
    public void Start()
    {
        for (int i = 0; i < craftInfos.Length; i++)
        {
            profile.sprite = craftInfos[i].profileSprite;
            name.text = string.Format("{0}", craftInfos[i].name);
            desc.text = string.Format("{0}", craftInfos[i].desc);
            requestIngredient.text = string.Format("I1 : {0} I2 : {1} I3 : {2}", craftInfos[i].namu, craftInfos[i].hwayack, craftInfos[i].chul);
            GameObject temp = Instantiate(listObject, content);
            temp.GetComponent<CraftObject>().SetInfo(craftInfos[i], itemInfos[i]);
            temp.SetActive(true);
        }
    }
}

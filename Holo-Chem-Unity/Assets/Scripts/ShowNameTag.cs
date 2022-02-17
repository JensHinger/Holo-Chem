using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowNameTag : MonoBehaviour
{
    private GameObject parent;
    private GameObject nametag;
    private GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        nametag = parent.transform.Find("sign").gameObject;
        text = nametag.transform.Find("Text (TMP)").gameObject;
        TextMeshPro tmp = text.GetComponent<TextMeshPro>();
        tmp.text = gameObject.name.Remove(gameObject.name.Length - 7);
    }

    // asdaSF
    public void ShowSign()
    {
        nametag.SetActive(true);
    }

    public void HideSign()
    {
        nametag.SetActive(false);
    }
}

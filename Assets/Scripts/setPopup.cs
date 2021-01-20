using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setPopup : MonoBehaviour
{
    public string title;
    public string desc;
    public string src;
    public Sprite img;

    private GameObject iPopup;
    private Canvas iCanvas;
    private Text iTitle;
    private Text iDesc;
    private Image iImg;
    private Image iSrc;
    // Start is called before the first frame update
    void Start()
    {
        iPopup = GameObject.FindGameObjectWithTag("Popup");
        iCanvas = iPopup.GetComponent<Canvas>();
        iTitle = GameObject.FindGameObjectWithTag("popTitle").GetComponent<Text>();
        iDesc = GameObject.FindGameObjectWithTag("popDesc").GetComponent<Text>();
        iImg = GameObject.FindGameObjectWithTag("popPic").GetComponent<Image>();
        iSrc = GameObject.FindGameObjectWithTag("popSrc").GetComponent<Image>();
    }

    public void onClick() {
        iCanvas.enabled = true;
        iTitle.text = title;
        iImg.sprite = img;
        iDesc.text = desc;
        global.activeURL = src;
        if(src.Equals("")) {
            iSrc.enabled = false;
        }
        else {
            iSrc.enabled = true;
        }
    }

    public void redirect() {
        if(!global.activeURL.Equals("")) {
            Application.OpenURL(global.activeURL);
        }
    }
    public void redirect(string url) {
        if(!url.Equals("")) {
            global.activeURL = url;
        }
        redirect();
    }
}

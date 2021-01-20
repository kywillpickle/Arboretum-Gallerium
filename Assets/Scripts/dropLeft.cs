using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLeft : MonoBehaviour
{
    private RectTransform iRectTransform;
    public bool slidOut = false;
    private bool disabled = false;
    private int animCount = 0;
    private float xSize;
    // Start is called before the first frame update
    void Start()
    {
        iRectTransform = GetComponent<RectTransform>();
        xSize = 540*Screen.width/GetComponentInParent<RectTransform>().rect.width/15;
    }

    // Update is called once per frame
    void Update()
    {
        if(animCount > 0) {
            if(slidOut == false) {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x-xSize, iRectTransform.position.y, iRectTransform.position.z), iRectTransform.rotation);
                animCount--;
            }
            else {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x+xSize, iRectTransform.position.y, iRectTransform.position.z), iRectTransform.rotation);
                animCount--;
            }
            if(animCount == 0) {
                disabled = false;
            }
        }
        if(global.menuOut != slidOut) {
            animCount = 15-animCount;
            disabled=true;
            if(slidOut) {
                slidOut=false;
            }
            else {
                slidOut=true;
            }
        }
    }

    public void menuButtonDown() {
        if(!disabled) {
            if(slidOut) {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x-xSize, iRectTransform.position.y, iRectTransform.position.z), iRectTransform.rotation);
                slidOut = false;
                global.menuOut = false;
                disabled = true;
                animCount = 14;
            }
            else {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x+xSize, iRectTransform.position.y, iRectTransform.position.z), iRectTransform.rotation);
                slidOut = true;
                global.menuOut = true;
                global.keyOut = false;
                disabled = true;
                animCount = 14;
            }
        }
    }
}

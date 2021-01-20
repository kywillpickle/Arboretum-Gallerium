using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDown : MonoBehaviour
{
    private RectTransform iRectTransform;
    public bool slidOut = false;
    private bool disabled = false;
    private int animCount = 0;
    private float ySize;
    // Start is called before the first frame update
    void Start()
    {
        iRectTransform = GetComponent<RectTransform>();
        ySize = 720*Screen.height/GetComponentInParent<RectTransform>().rect.height/15;
    }

    // Update is called once per frame
    void Update()
    {
        if(animCount > 0) {
            if(slidOut == false) {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x, iRectTransform.position.y+ySize, iRectTransform.position.z), iRectTransform.rotation);
                animCount--;
            }
            else {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x, iRectTransform.position.y-ySize, iRectTransform.position.z), iRectTransform.rotation);
                animCount--;
            }
            if(animCount == 0) {
                disabled = false;
            }
        }
        if(global.keyOut != slidOut) {
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

    public void keyButtonDown() {
        if(!disabled) {
            if(slidOut) {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x, iRectTransform.position.y+ySize, iRectTransform.position.z), iRectTransform.rotation);
                slidOut = false;
                global.keyOut = false;
                disabled = true;
                animCount = 14;
            }
            else {
                iRectTransform.SetPositionAndRotation(new Vector3(iRectTransform.position.x, iRectTransform.position.y-ySize, iRectTransform.position.z), iRectTransform.rotation);
                slidOut = true;
                global.menuOut = false;
                global.keyOut = true;
                disabled = true;
                animCount = 14;
            }
        }
    }
}

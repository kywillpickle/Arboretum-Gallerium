using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMv : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0) {

        }
        else if(Input.touchCount == 1) {
            Touch iTouch = Input.GetTouch(0);
            Vector3 mvV = new Vector3(iTouch.deltaPosition.x/3, 0, iTouch.deltaPosition.y/3);
            if(mvV.x +gameObject.transform.position.x > maxX || mvV.x +gameObject.transform.position.x < minX) {
                mvV.x = 0;
            }
            if(mvV.z +gameObject.transform.position.z > maxZ || mvV.z +gameObject.transform.position.z < minZ) {
                mvV.z = 0;
            }
            this.gameObject.transform.position += mvV;
        }
        else if(Input.touchCount == 2) {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            float delPinchX = 0;
            float delPinchY = 0;
            if(touch1.position.x < touch2.position.x) {
                delPinchX = touch2.deltaPosition.x - touch1.deltaPosition.x;
            }
            else {
                delPinchX = touch1.deltaPosition.x - touch2.deltaPosition.x;
            }
            if(touch1.position.y < touch2.position.y) {
                delPinchY = touch2.deltaPosition.y - touch1.deltaPosition.y;
            }
            else {
                delPinchY = touch1.deltaPosition.y - touch2.deltaPosition.y;
            }
            Vector3 mvV = new Vector3((touch1.deltaPosition.x+touch2.deltaPosition.x)/6, -2*(Mathf.Max(delPinchX+delPinchY)), (touch1.deltaPosition.x+touch2.deltaPosition.x)/6);
            if(mvV.x +gameObject.transform.position.x > maxX || mvV.x +gameObject.transform.position.x < minX) {
                mvV.x = 0;
            }
            if(mvV.y +gameObject.transform.position.y > maxY || mvV.y +gameObject.transform.position.y < minY) {
                mvV.y = 0;
            }
            if(mvV.z +gameObject.transform.position.z > maxZ || mvV.z +gameObject.transform.position.z < minZ) {
                mvV.z = 0;
            }
            this.gameObject.transform.position += mvV;
        }
    }
}

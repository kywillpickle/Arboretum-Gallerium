using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class gpsLocate : MonoBehaviour
{
    private LocationService gpsPos;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform.Equals(RuntimePlatform.Android) && !Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.CoarseLocation);
            }
        gpsPos = Input.location;
    }

    // Update is called once per frame
    void Update()
    {
        print(gpsPos.lastData.longitude+", "+gpsPos.lastData.latitude);
        x = (gpsPos.lastData.longitude+121.7515f)/0.0283f*4980/2;
        y = (gpsPos.lastData.latitude-38.5333f)/0.0148f*3300/2;
        this.gameObject.transform.position = new Vector3(x, 10, y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ConnectionBetweenTwoSpot : MonoBehaviour
{ 
    public RectTransform Origin;
    public RectTransform Target;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        Vector2 target = Target.localPosition;
        Vector2 origin = Origin.localPosition;
        _image.transform.localPosition = (target + origin) / 2;
        _image.rectTransform.sizeDelta = new Vector2(1, Vector3.Distance(origin, target));

        // rotation
        double angle = Mathf.Atan2(target.y - origin.y, target.x - origin.x) * 180 / Mathf.PI;
        _image.transform.rotation = Quaternion.Euler(0, 0, (float)angle + 270);
    }
}

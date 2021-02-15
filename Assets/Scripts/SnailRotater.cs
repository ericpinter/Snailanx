using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailRotater : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] index;
    public float fixedAngle;
    public bool isFixed;
    

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = (this.transform.rotation.eulerAngles.z - this.transform.localEulerAngles.z +360000f) % 360f;
        if (isFixed) angle = fixedAngle;

        if (angle > 315 || (angle > 0 && angle < 45))
        {
            _spriteRenderer.sprite = index[0];
            if (!isFixed) this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else if (angle >= 45 && angle < 135)
        {
            _spriteRenderer.sprite = index[1];
            if (!isFixed) this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -angle);
        }
        else if (angle >= 135 && angle < 225)
        {
            _spriteRenderer.sprite = index[2];
            if (!isFixed) this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        else if (angle >= 225 && angle < 315)
        {
            _spriteRenderer.sprite = index[3];
            if (!isFixed) this.gameObject.transform.localRotation = Quaternion.Euler(0, 0,-angle);
        }
    }
}

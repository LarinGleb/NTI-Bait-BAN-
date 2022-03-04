using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float Horizontal { 
        get {return input.x;} 
    }
    public float Vertical { 
        get {return input.y;} 
    }

    public Vector2 Direction { 
        get {return new Vector2(Horizontal, Vertical);} 
    }

    public bool OnJoystick {
        get {return onJoyStick;}
    }

    [SerializeField] private float handleRange = 1;
    [SerializeField] private float deadZone = 0;

    [SerializeField] protected RectTransform background = null;
    [SerializeField] private RectTransform handle = null;

    private RectTransform baseRect = null;
    private AxisOptions axisOptions = AxisOptions.Both;
    private Canvas canvas;
    private Camera cam;
    private bool onJoyStick = false;


    private Vector2 input = Vector2.zero;

    protected virtual void Start()
    {
        baseRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        handle.anchoredPosition = Vector2.zero;

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        onJoyStick = false;
        input = Vector2.zero;
        handle.anchoredPosition = input;

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        onJoyStick = true;
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam = null;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            cam = canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        Vector2 radius = background.sizeDelta / 2;
        input = (eventData.position - position) / (radius * canvas.scaleFactor);
        FormatInput();
        HandleInput(input.magnitude, input.normalized, radius, cam);
        handle.anchoredPosition = input * radius * handleRange;
    }

    protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
                input = normalised;
        }
        else
            input = Vector2.zero;
    }

    private void FormatInput()
    {
        if (axisOptions == AxisOptions.Horizontal)
            input = new Vector2(input.x, 0f);
        else if (axisOptions == AxisOptions.Vertical)
            input = new Vector2(0f, input.y);
    }

}

public enum AxisOptions { Both, Horizontal, Vertical }
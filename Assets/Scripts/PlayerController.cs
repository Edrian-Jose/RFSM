using UnityEngine;

class PlayerController: MonoBehaviour 
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            AButtonUp?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            QButtonUp?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            WButtonUp?.Invoke();
        }
       if (Input.GetKeyUp(KeyCode.E))
        {
            EButtonUp?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            RButtonUp?.Invoke();
        }
        
        
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
            LeftMousePressed?.Invoke(worldPosition, hitData);
        } 
        if(Input.GetMouseButtonDown(1))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
            RightMousePressed?.Invoke(worldPosition, hitData);
        }

    }

    public event VoidHandler QButtonUp;
    public event VoidHandler WButtonUp;
    public event VoidHandler EButtonUp;
    public event VoidHandler RButtonUp;
    public event VoidHandler AButtonUp;
    public delegate void VoidHandler();
    public delegate void MouseHandler(Vector2 worldPosition, RaycastHit2D hitData);
    public event MouseHandler RightMousePressed;
    public event MouseHandler LeftMousePressed;
}
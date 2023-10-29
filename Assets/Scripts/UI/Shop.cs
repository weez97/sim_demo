using UnityEngine;
using DG.Tweening;

public class Shop : MonoBehaviour, IUiScreen
{
    private bool isShowing;

    public Transform categoriesBar, gridContainer;
    public GameObject categoryButton, shopButton;

    public void Hide()
    {
        throw new System.NotImplementedException();
    }

    public bool IsShowing()
    {
        return isShowing;
    }

    public void Show()
    {
        transform.DOPunchScale(new(1,1,1), .5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

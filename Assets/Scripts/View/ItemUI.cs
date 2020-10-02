using UnityEngine;


//our class attached to the gameobject with the visual representation of the item
public class ItemUI : MonoBehaviour
{
    
    [SerializeField] private UILabel title = null;
    [SerializeField] private UILabel description = null;
    [SerializeField] private UILabel price = null;
    [SerializeField] private UILabel amount = null;
    [SerializeField] private UISprite image = null;

    private bool _selected = false;
    private bool _equipped = false;
    private GameObject _go = null;


    public void Init(string title, string description, string price, string amount, string imgName)
    {
        _go = this.gameObject;
        this.title.text = title;
        this.description.text = description;
        this.price.text = price;
        this.amount.text = amount;
        image.spriteName = imgName;
    }


    public void SetActive()
    {
        _go.SetActive(true);
    }

    public void SetInactive()
    {
        _go.SetActive(false);
    }


    public void SetSelected()
    {
        _selected = true;
    }

    public void SetDeselected()
    {
        _selected = false;
    }


    public void SetEquipped()
    {
        _equipped = true;
    }

    public void SetUnequipped()
    {
        _equipped = false;
    }


}

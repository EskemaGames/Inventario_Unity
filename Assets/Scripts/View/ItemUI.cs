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
    private uint id = 0;
    
    public uint GetId
    {
        get { return id; }
    }

    public void Init(uint id, string title, string description, string price, string amount, string imgName)
    {
        _go = this.gameObject;
        this.id = id;
        this.title.text = title;
        this.description.text = description;
        this.price.text = price;
        this.amount.text = amount;
        image.spriteName = imgName;
    }
    
    public void InitEmpty()
    {
        _go = this.gameObject;
        id = 0;
        title.text = "";
        description.text = "";
        price.text = "";
        amount.text = "";
        image.spriteName = "";
        
        SetInactive();
    }


    public void SetActive()
    {
        _go.SetActive(true);
    }

    public void SetInactive()
    {
        _go.SetActive(false);
    }

    public void ResetItem()
    {
        id = 0;
    }


    public void SetSelected()
    {
        _selected = true;
        //PlaySound("SOUND_SELECTED");
        //Particles.Spawn();
    }

    public void SetDeselected()
    {
        _selected = false;
    }


    public void SetEquipped()
    {
        _equipped = true;
        //PlaySound("SOUND_EQUIPPED");
        //Particles.Spawn();
    }

    public void SetUnequipped()
    {
        _equipped = false;
    }


}

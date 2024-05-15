using UnityEngine;
using UnityEngine.UI;

public class CartManager : MonoBehaviour
{
    public GameObject cartItem;

    private Button _button;
    private ARTapToPlaceObject _arTapToPlaceObject;

    void Start()
    {
        _arTapToPlaceObject = FindObjectOfType<ARTapToPlaceObject>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChooseCartItem);
    }

    private void ChooseCartItem()
    {
        _arTapToPlaceObject.objectToPlace = cartItem;
    } 
}

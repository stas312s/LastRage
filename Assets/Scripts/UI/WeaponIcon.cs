using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponIcon: MonoBehaviour
    {
        [SerializeField]private Image _image;
        
        public void SetSprite( Sprite weaponSprite)
        {
            _image.sprite = weaponSprite;
            _image.gameObject.SetActive(true);
        }
        
    }
    
    
}
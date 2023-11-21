using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponIcon: MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _background;
        [SerializeField] private Sprite _activate;
        [SerializeField] private Sprite _disactivate;
            
        
        public void SetSprite( Sprite weaponSprite)
        {
            _image.sprite = weaponSprite;
            _image.gameObject.SetActive(true);
        }

        public void Activate(bool state)
        {
            _background.sprite = state ? _activate : _disactivate;
        }
        
        
        
    }
    
    
}
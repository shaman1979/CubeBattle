using UnityEngine;

namespace CubeBattle.BuyUnits
{
    public class PlaceUnitModeView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public void PreviewShow(Sprite image, Vector3 startPosition)
        {
            gameObject.SetActive(true);
            PositionChange(startPosition);
            SpriteChange(image);
        }

        public void PreviewHide()
        {
            gameObject.SetActive(false);
        }

        public void PositionChange(Vector3 position)
        {
            transform.position = position;
        }

        private void SpriteChange(Sprite image)
        {
            if (image)
            {
                spriteRenderer.sprite = image;
            }
            else
            {
                Debug.LogError($"Отсутствует изображение для превью.");
            }
        }
    }
}
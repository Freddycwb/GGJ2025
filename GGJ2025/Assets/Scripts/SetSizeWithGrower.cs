using UnityEngine;

public class SetSizeWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;
	[SerializeField] private Sprite[] playerSprites;
	[SerializeField] private Sprite[] shadowSprites;
	private SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = playerSprites[0];
    }

    public void OnStageChanged() {
		sr.sprite = playerSprites[grower.stage];
		// transform.localScale = new Vector2(1 + grower.stage * grower.growAmount, 1 + grower.stage * grower.growAmount);
	}
}

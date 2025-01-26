using UnityEngine;

public class SetSizeWithGrower : MonoBehaviour
{
	[SerializeField] private Grower grower;
	[SerializeField] private Sprite[] playerSprites;
	[SerializeField] private Sprite[] shadowSprites;
	[SerializeField] private float scale_offset = 1.0f;
	private SpriteRenderer sr;
	[SerializeField] private GameObject face;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
		sr.sprite = playerSprites[0];
    }

    public void OnStageChanged() {
		sr.sprite = playerSprites[grower.stage];
		face.transform.localScale = new Vector3(0.25f + grower.stage * (1 + grower.growAmount) * scale_offset, 0.25f + grower.stage * (1 + grower.growAmount) * scale_offset, 0);
	}
}

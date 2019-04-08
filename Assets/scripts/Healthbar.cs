using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Player player;
    private RectTransform _rTransform;
    // Start is called before the first frame update
    void Awake()
    {
        _rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rTransform.anchorMax = new Vector2(player.GetHealth(), 1);
    }
}

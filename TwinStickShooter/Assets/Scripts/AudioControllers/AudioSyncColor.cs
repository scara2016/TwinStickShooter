using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncColor : AudioSyncer
{
    public Color beatColor;
    public Color restColor;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void OnBeat()
    {
        base.OnBeat();

        StopCoroutine("MoveToColor");
        StartCoroutine("MoveToColor", beatColor);
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, restColor, resSmoothTime * Time.deltaTime);
    }

    private IEnumerator MoveToColor(Color _target)
    {
        Color _curr = spriteRenderer.color;
        Color _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Color.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;
            spriteRenderer.color = _curr;

            yield return null;
        }
        m_isBeat = false;
    }
}

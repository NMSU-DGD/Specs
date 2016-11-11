using UnityEngine;
using System.Collections;

public class OrderSort : MonoBehaviour {

    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private bool dynamicSort;

	void Awake () {
        sr.sortingOrder = (int)transform.position.x + (int)transform.position.y * 10;
	}

	void Update () {

        if( dynamicSort )
            sr.sortingOrder = (int)transform.position.x + (int)transform.position.y * 10;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �L���[�u�̈ړ����x
    private float speed = -12;

    // ���ňʒu
    private float deadLine = -10;

    //�L���[�u�Ɍ��ʉ����Đ�������
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSource����̃R���|�[�l���g���擾
        AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փˎ��Ɍ��ʉ����Đ�
        AudioSource.Play();  
}

    // Update is called once per frame
    void Update()
    {
        // �L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // ��ʊO�ɏo����j������
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
}

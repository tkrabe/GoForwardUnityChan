using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������i�A�j���[�V�����j
    Animator animator;

    //Unity�������ړ�������R���|�[�l���g������i�W�����v������j
    Rigidbody2D rigid2D;

    // �n�ʂ̈ʒu�i�A�j���[�V�����j
    private float groundLevel = -3.0f;

    // �W�����v�̑��x�̌����i�W�����v������j
    private float dump = 0.8f;

    // �W�����v�̑��x�i�W�����v������j
    float jumpVelocity = 20;

    // �Q�[���I�[�o�[�ɂȂ�ʒu�i�Q�[���I�[�o�[����j
    private float deadLine = -9;


    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����i�A�j���[�V�����j
        this.animator = GetComponent<Animator>();

        // Rigidbody2D�̃R���|�[�l���g���擾����i�W�����v������j
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����A�j���[�V�������Đ����邽�߂ɁAAnimator�̃p�����[�^�𒲐߂���i�A�j���[�V�����j
        this.animator.SetFloat("Horizontal", 1);

        // ���n���Ă��邩�ǂ����𒲂ׂ�i�A�j���[�V�����j
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        // �W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���i������炷�j
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // ���n��ԂŃN���b�N���ꂽ�ꍇ�i�W�����v������j//Input.GetMouseButtonDown(0)���̕����}�E�X�̍��N���b�N���ꂽ�u�Ԃɐ^���itrue�j�����肵�Ă���
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            // ������̗͂�������i�W�����v������j
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // �N���b�N����߂��������ւ̑��x����������i�W�����v������j
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���i�Q�[���I�[�o�[����j
        if (transform.position.x < this.deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������i�Q�[���I�[�o�[����j
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            // ���j�e�B������j������i�Q�[���I�[�o�[����j
            Destroy(gameObject);
        }

        }
}

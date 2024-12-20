using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.1f;

    public GameObject afterimagePrefab; // 복제될 잔상 오브젝트의 프리팹
    public float afterimageLifetime = 0.2f; // 잔상이 유지될 시간

    private Rigidbody characterRigidbody;
    private bool isDashing = false;
    private float dashTime = 0f;
    private float lastDashTime = -10f;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = characterRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);

        // 대쉬 입력을 처리
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            isDashing = true;
            dashTime = Time.time;
            lastDashTime = Time.time;
            StartCoroutine(CreateAfterimage()); // 대쉬 시 잔상 생성
        }

        // 대쉬 중이면 대쉬 속도로 설정
        if (isDashing)
        {
            velocity *= dashSpeed;
            if (Time.time > dashTime + dashDuration)
            {
                isDashing = false;
            }
        }
        else
        {
            velocity *= speed;
        }

        velocity.y = fallSpeed;
        characterRigidbody.velocity = velocity;
    }

    IEnumerator CreateAfterimage()
    {
        while (isDashing)
        {
            GameObject afterimage = Instantiate(afterimagePrefab, transform.position, transform.rotation);
            Destroy(afterimage, afterimageLifetime); // 잔상을 일정 시간 후 삭제
            yield return new WaitForSeconds(0.01f); // 잔상을 일정 간격으로 생성
        }
    }
}

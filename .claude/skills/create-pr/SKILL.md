---
name: create-pr
description: Github Pull Request 를 프로젝트 규칙에 따라 작성하고 생성한다. PR 승인과 머지는 하지 않는다.
---

# Github Pull Request 생성

> 규칙은 아래 문서에만 있다. 이 스킬은 절차와 참조 위치만 안내한다.

## 참조 문서

- 절차 : `Docs/Claude/WorkFlowRules.md` 의 `7. PR 작성`, `8. 사용자 검수 (PR)`
- 양식 : `Docs/Template/PullRequestTemplate.md`
- 컨벤션 : `Docs/Context/GitConvention.md`

## 절차

1. 위 참조 문서를 읽는다.
2. 작업 브랜치가 원격에 Push 되어 있는지 확인한다.
    - 되어 있지 않으면 사용자에게 Push 를 요청하고, 완료될 때까지 진행하지 않는다.
3. 관련 이슈 번호를 확인한다.
    - 있으면 `close #이슈번호` 로 연결하고, 이슈의 DoD 를 `작업 완료 확인` 에 옮긴다.
    - 없으면 `관련 이슈` 섹션에 "없음" 을 기재한다.
4. 브랜치의 변경 내용을 읽고, 양식에 따라 PR 초안을 작성해 사용자에게 보여준다.
5. 승인을 받으면 `gh` CLI 로 PR 을 생성한다.
6. 생성된 PR 링크를 사용자에게 알린다.
    - PR 의 승인과 머지는 사용자가 직접 한다.

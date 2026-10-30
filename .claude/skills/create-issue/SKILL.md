---
name: create-issue
description: Github Issue 를 프로젝트 규칙에 따라 작성하고 등록한다. 이슈화 여부 판단부터 이슈 등록까지 수행한다.
---

# Github Issue 생성

> 규칙은 아래 문서에만 있다. 이 스킬은 절차와 참조 위치만 안내한다.

## 참조 문서

- 절차 : `Docs/Claude/WorkFlowRules.md` 의 `2. 이슈화 여부`, `3. 이슈 생성`
- 섹션별 작성 규칙, Label : `Docs/Documentation/Github Issue Rule`
- 양식 : `Docs/Template/IssueTemplate.md`

## 절차

1. 위 참조 문서를 읽는다.
2. 업무 분류에 따라 이슈화 여부를 판단한다. (`WorkFlowRules.md` 2장)
3. `배경 / 목적` 에 기재할 내용을 사용자에게 질문한다.
    - 답을 받지 못하면 이슈를 생성하지 않고 종료한다.
    - `버그 발생` 은 재현 절차, 기대 동작, 실제 동작을 질문한다.
4. 양식과 작성 규칙에 따라 이슈 초안을 작성해 사용자에게 보여준다.
    - Label 도 함께 제시한다.
5. 승인을 받으면 `gh` CLI 로 등록한다.
    - 담당자(Assignees)는 사용자(`@me`)로 지정한다.
    - Label 이 저장소에 없으면 `gh label list` 로 확인 후 새로 등록하고 사용한다.
6. 등록된 이슈 번호와 링크를 사용자에게 알린다.

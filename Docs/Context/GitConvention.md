# Git 컨벤션 (Git Convention)

## Commit Convention

> commit 시 상황에 맞는 gitmoji 를 접두어처럼 사용한다.
> 
> commit 내용은 동사로 시작하며, 영어로 간결하게 작성한다.

| gitmoji | 사용처 | 예시 |
| --- | --- | --- |
| :sparkles: | 기능 개발, 구현 | :sparkles: Implement Player's Movement |
| :bug: | 버그 수정 | :bug: Fix Player's Movement |
| :art: | 기능 변동 없는 가시성을 위한 코드 변경 | :art: Improve Structure |
| :memo: | Docs 이하 폴더의 문서 생성 및 삭제/수정 | :memo: Modify `example.md` |
| :recycle: | 기능 개선을 위한 로직 변경 | :recycle: Implement A* Algorithm instead NavMeshAgent |
| :truck: | 파일 위치 이동 업무 | :truck: Move `example.cs` → `Example/` |
| :fire: | 파일, 코드 삭제 | :fire: Delete `example.md` |

## Branch Convention

> 작업 범위가 깊어지지 않도록 이슈 하나의 완료를 기준으로 Pull Request 한다.
>
> 브랜치 명은 `접두어/사용자계정명-업무제목` 으로 한다.
>
> 업무제목을 선정할 때에는 대문자를 사용하지 않으며, 하이픈 문자 (`-`)를 통해 작성한다.

| 접두어 | 사용처 | 예시 |
| --- | --- | --- |
| feature | 기능 개발, 구현 | feature/joosjae01-game-manager |
| fix | 버그 수정 (로직 변경) | fix/joosjae01-player-collision |
| docs | 문서 생성 및 수정 | docs/joosjae01-modify-document |

## Pull Request Convention

> PR 제목은 `Commit Convention` 을 따른다. (gitmoji 접두어 + 동사로 시작하는 영어)
>
> 이슈 제목 규칙 (`GithubIssueRule.md`) 과 혼동하지 않는다.

| 예시 |
| --- |
| :sparkles: Implement Player's Sprite Animation |
| :art: Apply Soldier Asset to Player |
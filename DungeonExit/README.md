# 프로젝트 이름 DungeonExit

## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [주요기능](#주요기능)
3. [사용한 무료 에셋](#Asset_From_Unity)
4. [개발기간](#개발기간)
5. [기술스택](#기술스택)
6. [프로젝트 파일 구조](#프로젝트-파일-구조)
7. [Trouble Shooting](#trouble-shooting)


## 👨‍🏫 프로젝트 소개
- 프로젝트 명 : DungeonExit
- 프로젝트 설명 : 던전내부에서 장애물을 피해 탈출하는 게임
- 프로젝트 시작 계기 : 3인칭 플랫포머 장르를 참고해서 만들게 됨
- 프로젝트 구성 인원 : 유원영


## 💜 주요기능

## ⏲️ 개발기간
- 총 8일   { 2025.11.06(목) ~ 2025.11.13(목) }


### 🖥️ Language
*  C#


### 🔧 Version Control
*  Git + GitHub


### 🧩 IDE
* Visual Studio


### 🧰 Framework
* net9.0


## Asset From Unity

*Lite Dungeon Pack - Low Poly 3D Art by Gridness
https://assetstore.unity.com/packages/3d/environments/dungeons/lite-dungeon-pack-low-poly-3d-art-by-gridness-242692

*LowPoly Magician RIO
https://assetstore.unity.com/packages/3d/characters/humanoids/lowpoly-magician-rio-288942

*Inferno World Free - Low Poly 3D Models
https://assetstore.unity.com/packages/3d/environments/fantasy/inferno-world-free-low-poly-3d-models-328402

-License agreement : Standard Unity Asset Store EULA


### 🚀 배포 (Deploy)
- **빌드 환경:** Unity 2022.3.62f2
- **배포 방식:** 
- **결과물:** 


## 프로젝트 파일 구조

📦Assets
 ┣ 📂Animations
 ┃ ┣ 📂Chest
 ┃ ┃ ┣ 📜Chest.controller
 ┃ ┃ ┣ 📜Chest.controller.meta
 ┃ ┃ ┣ 📜idle.anim
 ┃ ┃ ┣ 📜idle.anim.meta
 ┃ ┃ ┣ 📜OpenChest.anim
 ┃ ┃ ┗ 📜OpenChest.anim.meta
 ┃ ┣ 📂Door
 ┃ ┃ ┣ 📜Door.controller
 ┃ ┃ ┣ 📜Door.controller.meta
 ┃ ┃ ┣ 📜DoorOpen.anim
 ┃ ┃ ┣ 📜DoorOpen.anim.meta
 ┃ ┃ ┣ 📜idle.anim
 ┃ ┃ ┗ 📜idle.anim.meta
 ┃ ┣ 📂Lever
 ┃ ┃ ┣ 📜DoorLever.controller
 ┃ ┃ ┣ 📜DoorLever.controller.meta
 ┃ ┃ ┣ 📜LeverIdle.anim
 ┃ ┃ ┣ 📜LeverIdle.anim.meta
 ┃ ┃ ┣ 📜LeverOn.anim
 ┃ ┃ ┗ 📜LeverOn.anim.meta
 ┃ ┣ 📂Player
 ┃ ┃ ┣ 📜Dying.anim
 ┃ ┃ ┣ 📜Dying.anim.meta
 ┃ ┃ ┣ 📜Falling.anim
 ┃ ┃ ┣ 📜Falling.anim.meta
 ┃ ┃ ┣ 📜Idle.anim
 ┃ ┃ ┣ 📜Idle.anim.meta
 ┃ ┃ ┣ 📜Jump.anim
 ┃ ┃ ┣ 📜Jump.anim.meta
 ┃ ┃ ┣ 📜Jump_Land.anim
 ┃ ┃ ┣ 📜Jump_Land.anim.meta
 ┃ ┃ ┣ 📜Jump_Up.anim
 ┃ ┃ ┣ 📜Jump_Up.anim.meta
 ┃ ┃ ┣ 📜PlayerAnimator.controller
 ┃ ┃ ┣ 📜PlayerAnimator.controller.meta
 ┃ ┃ ┣ 📜Running.anim
 ┃ ┃ ┗ 📜Running.anim.meta
 ┃ ┣ 📜Chest.meta
 ┃ ┣ 📜Door.meta
 ┃ ┣ 📜Lever.meta
 ┃ ┗ 📜Player.meta
 ┣ 📂Font
 ┃ ┣ 📜NEXON Lv1 Gothic Low OTF SDF.asset
 ┃ ┣ 📜NEXON Lv1 Gothic Low OTF SDF.asset.meta
 ┃ ┣ 📜NEXON Lv1 Gothic Low OTF.otf
 ┃ ┗ 📜NEXON Lv1 Gothic Low OTF.otf.meta
 ┣ 📂Player_Input
 ┃ ┣ 📜PlayerInput.inputactions
 ┃ ┗ 📜PlayerInput.inputactions.meta
 ┣ 📂Prefabs
 ┃ ┣ 📜ItemSlot.prefab
 ┃ ┣ 📜ItemSlot.prefab.meta
 ┃ ┣ 📜Lava_Flat.prefab
 ┃ ┣ 📜Lava_Flat.prefab.meta
 ┃ ┣ 📜LeverChestSet.prefab
 ┃ ┣ 📜LeverChestSet.prefab.meta
 ┃ ┣ 📜LeverDoorSet.prefab
 ┃ ┣ 📜LeverDoorSet.prefab.meta
 ┃ ┣ 📜Obstacle_SawBlade_Big (1).prefab
 ┃ ┗ 📜Obstacle_SawBlade_Big (1).prefab.meta
 ┃ ┣ 📂Icons
 ┃ ┃ ┣ 📜character.png
 ┃ ┃ ┣ 📜character.png.meta
 ┃ ┃ ┣ 📜HealthPotion.png
 ┃ ┃ ┣ 📜HealthPotion.png.meta
 ┃ ┃ ┣ 📜JumpPotion.png
 ┃ ┃ ┣ 📜JumpPotion.png.meta
 ┃ ┃ ┣ 📜Square.png
 ┃ ┗ ┗ 📜Square.png.meta
 ┣ 📂Scenes
 ┃ ┣ 📜MainScene.unity
 ┃ ┗ 📜MainScene.unity.meta
 ┣ 📂ScriptableData
 ┃ ┣ 📂FieldObjData
 ┃ ┃ ┣ 📜Chest.asset
 ┃ ┃ ┣ 📜Chest.asset.meta
 ┃ ┃ ┣ 📜ClearObject.asset
 ┃ ┃ ┣ 📜ClearObject.asset.meta
 ┃ ┃ ┣ 📜Door.asset
 ┃ ┃ ┣ 📜Door.asset.meta
 ┃ ┃ ┣ 📜Lever.asset
 ┃ ┃ ┗ 📜Lever.asset.meta
 ┃ ┣ 📂ItemObjData
 ┃ ┃ ┣ 📜Potion_Health.asset
 ┃ ┃ ┣ 📜Potion_Health.asset.meta
 ┃ ┃ ┣ 📜Potion_Jump.asset
 ┃ ┃ ┗ 📜Potion_Jump.asset.meta
 ┃ ┣ 📜FieldObjData.meta
 ┃ ┗ 📜ItemObjData.meta
 ┣ 📂Scripts
 ┃ ┣ 📂FieldObject
 ┃ ┃ ┣ 📜Chest.cs
 ┃ ┃ ┣ 📜Chest.cs.meta
 ┃ ┃ ┣ 📜ClearObject.cs
 ┃ ┃ ┣ 📜ClearObject.cs.meta
 ┃ ┃ ┣ 📜DamageZone.cs
 ┃ ┃ ┣ 📜DamageZone.cs.meta
 ┃ ┃ ┣ 📜Door.cs
 ┃ ┃ ┣ 📜Door.cs.meta
 ┃ ┃ ┣ 📜FieldInteractObject.cs
 ┃ ┃ ┣ 📜FieldInteractObject.cs.meta
 ┃ ┃ ┣ 📜JumpFloor.cs
 ┃ ┃ ┣ 📜JumpFloor.cs.meta
 ┃ ┃ ┣ 📜Lever.cs
 ┃ ┃ ┗ 📜Lever.cs.meta
 ┃ ┣ 📂Item
 ┃ ┃ ┣ 📜ItemData.cs
 ┃ ┃ ┣ 📜ItemData.cs.meta
 ┃ ┃ ┣ 📜ItemObject.cs
 ┃ ┃ ┣ 📜ItemObject.cs.meta
 ┃ ┃ ┣ 📜ItemSlot.cs
 ┃ ┃ ┗ 📜ItemSlot.cs.meta
 ┃ ┣ 📂Manager
 ┃ ┃ ┣ 📜CharacterManager.cs
 ┃ ┃ ┣ 📜CharacterManager.cs.meta
 ┃ ┃ ┣ 📜GameManager.cs
 ┃ ┃ ┣ 📜GameManager.cs.meta
 ┃ ┃ ┣ 📜InteractionObjManager.cs
 ┃ ┃ ┣ 📜InteractionObjManager.cs.meta
 ┃ ┃ ┣ 📜UIManager.cs
 ┃ ┃ ┗ 📜UIManager.cs.meta
 ┃ ┣ 📂MoveObject
 ┃ ┃ ┣ 📜MovingFloor.cs
 ┃ ┃ ┗ 📜MovingFloor.cs.meta
 ┃ ┣ 📂Obstacles
 ┃ ┃ ┣ 📜SawBlade.cs
 ┃ ┃ ┗ 📜SawBlade.cs.meta
 ┃ ┣ 📂Player
 ┃ ┃ ┣ 📜Interaction.cs
 ┃ ┃ ┣ 📜Interaction.cs.meta
 ┃ ┃ ┣ 📜Player.cs
 ┃ ┃ ┣ 📜Player.cs.meta
 ┃ ┃ ┣ 📜PlayerCondition.cs
 ┃ ┃ ┣ 📜PlayerCondition.cs.meta
 ┃ ┃ ┣ 📜PlayerController.cs
 ┃ ┃ ┗ 📜PlayerController.cs.meta
 ┃ ┣ 📂UI
 ┃ ┃ ┣ 📜Condition.cs
 ┃ ┃ ┣ 📜Condition.cs.meta
 ┃ ┃ ┣ 📜UICondition.cs
 ┃ ┃ ┣ 📜UICondition.cs.meta
 ┃ ┃ ┣ 📜UIInventory.cs
 ┃ ┃ ┗ 📜UIInventory.cs.meta
 ┃ ┣ 📜AnimationHandler.cs
 ┃ ┣ 📜AnimationHandler.cs.meta
 ┃ ┣ 📜Bootstrapper.cs
 ┃ ┣ 📜Bootstrapper.cs.meta
 ┃ ┣ 📜FieldObject.meta
 ┃ ┣ 📜Item.meta
 ┃ ┣ 📜Manager.meta
 ┃ ┣ 📜MoveObject.meta
 ┃ ┣ 📜Obstacles.meta
 ┃ ┣ 📜Player.meta
 ┃ ┣ 📜ThirdPersonCamera.cs
 ┃ ┣ 📜ThirdPersonCamera.cs.meta
 ┃ ┗ 📜UI.meta
 ┣ 📜Animations.meta
 ┣ 📜Font.meta
 ┣ 📜Player_Input.meta
 ┣ 📜Prefabs.meta
 ┣ 📜Resources.meta
 ┣ 📜Scenes.meta
 ┣ 📜ScriptableData.meta
 ┣ 📜Scripts.meta
 ┣ 📜Settings.meta
 ┗ 📜TextMesh Pro.meta

 ## Trouble Shooting

 https://anuzik.tistory.com/
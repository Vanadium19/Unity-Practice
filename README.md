# Unity Practice

Учебный 3D-проект на Unity с модульной архитектурой: игрок перемещается по уровню, собирает монеты, получает урон от ловушек, взаимодействует с дверями и управляет состоянием через UI-команды.

## Кратко о проекте

Проект демонстрирует:
- модульную организацию кода через `asmdef`-сборки;
- внедрение зависимостей через `Zenject`;
- паттерн команд для UI-действий;
- разделение доменной логики (`Core`), представлений (`View`) и связующего слоя (`Presenter`/`Controller`).

Основные игровые циклы:
- движение и обзор от 3-го лица;
- прыжок и базовая анимация персонажа;
- сбор монет и ведение баланса кошелька;
- получение урона от ловушек и `KillZone`;
- лечение персонажа за монеты;
- открытие/закрытие дверей по триггеру;
- меню: старт игры, перезапуск, возврат в меню, выход.

## Видео геймплея

[![Watch the video](https://img.youtube.com/vi/iGBPWP2k0s/0.jpg)](https://youtu.be/-iGBPWP2k0s)

> Нажмите на картинку или перейдите по ссылке:  
> 🔗 https://youtu.be/-iGBPWP2k0s

## Технический стек

- Unity: `2022.3.62f3` (LTS)
- Язык: C#
- Архитектура: модульная, DI
- Сцены:
  - `Assets/_Main/Scenes/MainMenu.unity`
  - `Assets/_Main/Scenes/Game.unity`

## Управление

По текущей реализации `InputService`:
- Движение: `W/A/S/D` (оси `Horizontal`/`Vertical`)
- Обзор: мышь (`Mouse X`, `Mouse Y`)
- Прыжок: `Space`

## Плагины и библиотеки

### Основные runtime-зависимости

- `Zenject` (`Assets/Plugins/Zenject`)  
  Контейнер зависимостей, биндинги и управление жизненным циклом сервисов/контроллеров.

- `UniTask` (`com.cysharp.unitask` в `Packages/manifest.json`)  
  Лёгкий async/await слой для Unity. Используется в интерфейсах команд (`IAsyncCommand`).

- `DOTween` (`Assets/Plugins/Demigiant/DOTween`)  
  Tween-анимации и инфраструктура анимаций (настроен через `Assets/Resources/DOTweenSettings.asset`).

- `TextMeshPro` (`com.unity.textmeshpro`)  
  UI-текст (например, health/wallet view).

### Дополнительные плагины и инструменты

- `Odin Inspector` (`Assets/Plugins/Sirenix`)  
  Инспектор/редакторские расширения.

- `Procedural UI Image` (`Assets/Plugins/ProceduralUIImage`)  
  Процедурные UI-элементы и модификаторы.

- `SimpleFolderIcon` (`Assets/Tools/SimpleFolderIcon`)  
  Editor-инструмент для иконок папок в Project view.

### Графические/контент-паки в проекте

- `Assets/AurynSky`
- `Assets/LowPolyDungeonsLite`
- `Assets/JC_LP_MedievalCharacters_LITE`
- `Assets/JC_StylizedModularCharacters`
- `Assets/JC_StylizedNature_Lite`
- `Assets/PolyKebap`

## Архитектура модулей

Ключевые модули в `Assets/_Main/Scripts`:

- `RootModule`  
  Точка входа сцены, глобальные биндинги и оркестрация (`Bootstrapper`, `GameSceneInstaller`, `GameSceneController`, `KillZone`).

- `InputModule`  
  Карта ввода (`IInputMap`) и реализация (`InputService`), подключаемая через `ScriptableObjectInstaller`.

- `PlayerModule`  
  Логика игрока: движение, взаимодействия с дверями/монетами, провайдер зависимостей игрока, команда лечения.

- `ComponentsModule`  
  Базовые компоненты домена: движение, поворот, здоровье/урон, кошелёк.

- `UIModule`  
  Меню, кнопки-команды, view/presenter для здоровья и валюты.

- `CommandsModule`  
  Унифицированные async-команды и базовые кнопки выполнения команд.

- `CoinsModule`  
  Монета как сущность и визуальное вращение.

- `DoorModule`  
  Дверь (интерфейс + реализация), инсталлер и анимация открытия/закрытия.

- `TrapsModule`  
  Периодический урон целям в триггере ловушки.

- `EntityModule`  
  Слой сущностей/прокси для универсальной выдачи интерфейсов компонентов.

- `CommonModule`  
  Общие константы и данные (например, параметры анимации).

## Структура проекта

```text
Unity-Practice/
├── Assets/
│   ├── _Main/
│   │   ├── Scenes/
│   │   │   ├── MainMenu.unity
│   │   │   └── Game.unity
│   │   ├── Prefabs/
│   │   ├── Scripts/
│   │   │   ├── RootModule/
│   │   │   ├── InputModule/
│   │   │   ├── PlayerModule/
│   │   │   ├── ComponentsModule/
│   │   │   ├── UIModule/
│   │   │   ├── CommandsModule/
│   │   │   ├── CoinsModule/
│   │   │   ├── DoorModule/
│   │   │   ├── TrapsModule/
│   │   │   ├── EntityModule/
│   │   │   └── CommonModule/
│   │   ├── Configs/
│   │   └── Resources/
│   ├── Plugins/
│   │   ├── Zenject/
│   │   ├── Demigiant/DOTween/
│   │   ├── Sirenix/
│   │   └── ProceduralUIImage/
│   ├── Tools/
│   └── (контент-паки и ассеты)
├── Packages/
│   ├── manifest.json
│   └── packages-lock.json
├── ProjectSettings/
└── README.md
```

## Как запустить

1. Откройте проект в Unity Hub с версией `2022.3.62f3`.
2. Убедитесь, что в Build Settings добавлены сцены:
   - `Assets/_Main/Scenes/MainMenu.unity`
   - `Assets/_Main/Scenes/Game.unity`
3. Запустите `MainMenu` и нажмите `Play`.

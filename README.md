# Assignment 5: Lightsaber Shader Graph

## Demo

https://github.com/user-attachments/assets/784478c4-4d26-46a6-8fac-5ea700354eb3


## How to Run
1. Open the project in Unity 6 (URP).
2. Open `Assets/Scenes/SampleScene` and press Play.
3. Click the Game view and press **Space** to extend/collapse the lightsabers.

## Features
- Custom URP Shader Graph with a pulsing glow (Time → Noise Sine Wave → Remap → Lerp → Emission), with BladeColor, OuterGlow, InnerGlow, and PulseSpeed exposed in the Inspector
- Bloom post-processing through the Global Volume
- Extend/collapse script using a BladeBase pivot so blades retract into the hilt
- **Extensions:** three lightsabers in different colors, and a point light on each blade that lights up the floor and turns off when the blade collapses

## Notes
- Uses Unity's new Input System (`Keyboard.current`) because Unity 6 defaults to it.

## Resources
- Assignment 5 instructions
- Unity Shader Graph and URP documentation

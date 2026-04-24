# FORTNITE Game Setup Guide

## Overview
A complete multiplayer-style shooter game with player movement, shooting, AI enemies, and health systems.

## Scripts Included

### Player Systems
- **PlayerMovement.cs** - WASD movement with jumping using Rigidbody physics
- **PlayerShooting.cs** - Fire bullets with Left Mouse Click
- **PlayerHealth.cs** - Health system (100 HP default), integrates with GameManager

### Enemy Systems
- **EnemyAI.cs** - Pathfinding toward player, stops at range
- **EnemyShooting.cs** - Automatic shooting when player in range
- **EnemyHealth.cs** - Health system (50 HP default), destroyed on death

### Core Systems
- **Bullet.cs** - Damage system, distinguishes player vs enemy bullets
- **GameManager.cs** - Singleton pattern, handles game states and scene reloading
- **UIManager.cs** - Displays player health and game status

## Setup Instructions

### 1. **Create Player GameObject**
   - Create a new Capsule or Cube for player
   - Add Components:
     - **Rigidbody** (Body Type: Dynamic, Freeze Rotation: X, Y, Z)
     - **Collider** (Box or Capsule)
     - **PlayerMovement** script
     - **PlayerShooting** script
     - **PlayerHealth** script
   - Tag it as "Player"

### 2. **Create Bullet Prefab**
   - Create a new Sphere or Cube
   - Add Components:
     - **Rigidbody** (Body Type: Dynamic)
     - **Sphere Collider** (is Trigger: False)
     - **Bullet** script (set damage value)
   - Create empty GameObject named "Bullet" with these
   - Drag into Assets folder to create prefab
   - Delete from scene

### 3. **Setup Player Shooting**
   - Create empty child GameObject under Player called "BulletSpawn"
   - Position it at gun's origin (front of player)
   - Assign to PlayerShooting's `bulletSpawn` Transform
   - Assign Bullet prefab to PlayerShooting's `bulletPrefab`

### 4. **Create Enemy GameObject**
   - Duplicate the Player Capsule
   - Remove PlayerMovement, PlayerShooting, PlayerHealth scripts
   - Add **EnemyAI** script
   - Add **EnemyShooting** script
   - Add **EnemyHealth** script
   - Assign player's Transform to EnemyAI's `player` field
   - Create "BulletSpawn" child for EnemyShooting
   - Assign bullet prefab to EnemyShooting

### 5. **Create Ground**
   - Create a Plane or Cube (large)
   - Add Collider
   - Tag it as "Ground"
   - This enables jumping detection

### 6. **Create GameManager**
   - Create empty GameObject named "GameManager"
   - Add **GameManager** script
   - This persists across scenes

### 7. **Setup Input Manager** (Unity Editor)
   - Open Project Settings → Input Manager
   - Ensure these inputs exist:
     - "Horizontal" (A/D or Arrow Keys)
     - "Vertical" (W/S or Arrow Keys)
     - "Jump" (Space)
     - "Fire1" (Left Mouse Click)

### 8. **Create UI (Optional)**
   - Create Canvas
   - Add Text element named "HealthText"
   - Add another Text for "StatusText"
   - Create empty GameObject "UIManager"
   - Add **UIManager** script
   - Assign Text elements to UIManager

## Gameplay

### Controls
- **WASD / Arrow Keys** - Move
- **Space** - Jump
- **Left Mouse Click** - Shoot

### Systems
- Player bullets only damage enemies
- Enemy bullets only damage player
- Enemies patrol toward player when visible
- Game pauses when player dies, reloads scene after 2 seconds

## Common Issues

### Enemies Don't Shoot
- Ensure "Player" tag is assigned to player GameObject
- Check bullet prefab is assigned to EnemyShooting
- Verify enemy is in range (default 12 units)

### Player Can't Jump
- Check Ground tag is assigned to ground object
- Verify Rigidbody has gravity enabled
- Ensure collider is touching ground initially

### Bullets Don't Damage
- Check Bullet.cs SetOwner() is being called (should be automatic)
- Verify target has Health script attached
- Check colliders are not set to triggers

## Customization

### Adjust Difficulty
- **EnemyAI.cs**: `moveSpeed`, `stoppingDistance`
- **EnemyShooting.cs**: `fireRate`, `range`, `bulletSpeed`
- **PlayerHealth.cs**: `maxHealth`
- **EnemyHealth.cs**: `maxHealth`
- **Bullet.cs**: `damage`

### Adjust Physics
- **PlayerMovement.cs**: `moveSpeed`, `jumpForce`
- Rigidbody mass and drag values on GameObjects

## Physics Settings (Recommended)
- Default Material Friction: 0
- Default Material Bounce: 0
- Gravity: -9.81

---

Enjoy building your game!

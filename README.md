# FORTNITE Game Project

A fully functional action shooter game built in Unity with player combat, AI enemies, and dynamic gameplay.

## What's Included

### ✅ Complete & Working
- **Player Movement** - WASD + Jump with physics
- **Player Shooting** - Shoot bullets at enemies (Left Click)
- **Player Health System** - 100 HP, dies at 0 HP
- **Enemy AI** - Pathfinding toward player
- **Enemy Shooting** - Automatic fire at player when in range
- **Enemy Health System** - 50 HP per enemy
- **Bullet System** - Player bullets damage enemies, enemy bullets damage player
- **Game Manager** - Handles game states, scene reload on death
- **Enemy Spawner** - Spawns enemies dynamically during gameplay
- **UI Manager** - Displays health and game status (optional setup)

### 📝 Scripts
```
Scripts/
├── PlayerMovement.cs       (Movement physics)
├── PlayerShooting.cs       (Fire bullets)
├── PlayerHealth.cs         (Health & death)
├── EnemyAI.cs             (Pathfinding AI)
├── EnemyShooting.cs       (Enemy shooting)
├── EnemyHealth.cs         (Enemy health)
├── Bullet.cs              (Damage & collision)
├── GameManager.cs         (Game state - SINGLETON)
├── EnemySpawner.cs        (Dynamic spawning)
└── UIManager.cs           (Health display)
```

---

## Quick Start (5 Minutes)

### Unity Scene Setup

1. **Create Player**
   - Capsule or Cube
   - Add Rigidbody (Body Type: Dynamic, Constraints: Freeze Rotation X, Y, Z)
   - Add Collider (not trigger)
   - Attach scripts: PlayerMovement, PlayerShooting, PlayerHealth
   - **Tag: "Player"**

2. **Create Bullet Prefab**
   - Sphere or small Cube
   - Add Rigidbody (Dynamic)
   - Add Collider
   - Attach Bullet.cs script
   - Drag to Assets/ folder → Right-click → Create Prefab → Save
   - Delete from scene

3. **Setup Player Shooting**
   - Add empty child GameObject under Player: "BulletSpawn"
   - Position in front of player (where bullets spawn)
   - In PlayerShooting script:
     - Assign bullet prefab
     - Assign BulletSpawn transform

4. **Create Enemy**
   - Capsule or Cube (different color to player)
   - Add Rigidbody (Dynamic)
   - Add Collider
   - Attach: EnemyAI, EnemyShooting, EnemyHealth
   - Add "BulletSpawn" child like player
   - In EnemyAI: Assign player Transform
   - In EnemyShooting: Assign bullet prefab + bulletSpawn

5. **Create Ground (Required!)**
   - Cube, scale up (e.g., 10, 1, 10)
   - Add Collider
   - **Tag: "Ground"** (needed for jump detection)

6. **Create Game Manager**
   - Empty GameObject named "GameManager"
   - Attach GameManager.cs script
   - Leave it in scene (persists across reloads)

7. **Create Enemy Spawner**
   - Empty GameObject "EnemySpawner"
   - Attach EnemySpawner.cs
   - Assign enemy prefab (duplicate your enemy, save as prefab)
   - Adjust `spawnRate` and `maxEnemies`

8. **Test!**
   - **Controls:**
     - WASD = Move
     - Space = Jump
     - Left Click = Shoot
   - Player should take damage from enemy bullets
   - Enemies should die when hit (50 HP)

---

## Bug Fixes Applied ✅

### Critical Issues Fixed
1. **EnemyShooting crash** → Added null check for Player tag
2. **Bullets damaging everyone** → Now player bullets only hit enemies (and vice versa)
3. **Player death not triggering game over** → Integrated with GameManager
4. **Physics conflicts** → Switched to Rigidbody-based movement
5. **Missing GameManager access** → Added singleton pattern
6. **Double GetComponent calls** → Refactored for performance
7. **No error handling** → Added null checks throughout

---

## Customization

### Adjust Gameplay Balance

**Player Strength**
```csharp
// PlayerMovement.cs
moveSpeed = 5f;       // Higher = faster
jumpForce = 5f;       // Higher = higher jump

// PlayerHealth.cs
maxHealth = 100;      // More HP
```

**Enemy Difficulty**
```csharp
// EnemyAI.cs
moveSpeed = 3.5f;     // Slower = easier
stoppingDistance = 6f; // Larger = keeps more distance

// EnemyShooting.cs
fireRate = 1f;        // Higher = slower shooting
range = 12f;          // Larger = shoots from further

// EnemyHealth.cs
maxHealth = 50;       // Lower = easier to kill
```

**Spawning**
```csharp
// EnemySpawner.cs
spawnRate = 3f;       // Higher = longer between spawns
maxEnemies = 10;      // More = harder game
```

---

## Next Steps (Optional Enhancements)

- [ ] Add weapon upgrades (faster fire rate, more damage)
- [ ] Add ammo/reload system (limited bullets)
- [ ] Add score system (points for kills)
- [ ] Add particles/effects (muzzle flash, blood)
- [ ] Add sound effects (gunshot, hit, death)
- [ ] Add multiple enemy types (faster, tank, melee)
- [ ] Add levels/waves (increasing difficulty)
- [ ] Add UI polish (crosshair, kill counter)

---

## Troubleshooting

### Game won't start
- Check GameManager exists in scene
- Verify Player is tagged "Player"
- Check console for errors

### Player can't move
- Verify Rigidbody has gravity enabled
- Check PlayerMovement script is attached
- Test: Select player → press Play → press W key

### Player can't shoot
- Check bullet prefab is assigned
- Verify bullet prefab has Rigidbody + Collider
- Check BulletSpawn child exists and is assigned

### Enemies don't spawn
- Check EnemySpawner script is attached
- Verify enemy prefab is assigned
- Check Player tag is set correctly

### Enemies don't shoot
- Ensure Player tag exists
- Check EnemyShooting's bulletSpawn is set
- Verify enemy is < 12 units from player

---

## File Structure
```
/workspaces/FORTNITE/
├── Scripts/
│   ├── PlayerMovement.cs
│   ├── PlayerShooting.cs
│   ├── PlayerHealth.cs
│   ├── EnemyAI.cs
│   ├── EnemyShooting.cs
│   ├── EnemyHealth.cs
│   ├── Bullet.cs
│   ├── GameManager.cs
│   ├── EnemySpawner.cs
│   └── UIManager.cs
├── README.md (this file)
└── SETUP_GUIDE.md (detailed setup)
```

---

## Physics Settings (Recommended)
Edit → Project Settings → Physics

- **Gravity:** -9.81 (default)
- **Default Material Friction:** 0.4
- **Default Material Bounce Combine:** Average

---

**Your game is ready to play! Enjoy! 🎮**

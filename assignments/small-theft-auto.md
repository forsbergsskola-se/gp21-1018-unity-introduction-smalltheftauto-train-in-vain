# Assignment: Small Theft Auto

Please use the Unity Project under `projects/SmallTheftAuto` for this Assignment.\
This is a Group Assignment for 4 people per Group.\
I recommend the following work schedule:
- Between 9:00 and 16:00 (or 18:00)
- 2 Groups of Pair Programming Students 
  - one Student streams his Screen, the other follows and comments
  - switch the role of the active (typing) Programmer for each feature, but at least every 1.5 hours!
  - There have to be regular commits from EVERY TEAM MEMBER
  - Team Members without regular contributions will not receive a passing Grade
- Swap the Pairs every other day, make sure to work with every single team member of your team!
- I know, that it's much more comfortable, to:
  - Work alone, at your own pace, but you need to learn to communicate, discuss, etc. It's the best way of improving code quality and team quality!
  - Stick with the same team members every day, but you should get to know each other and learn, whom it is easier to work with, learn to work with people that might not be so easy to work with and give each other feedback and the chance to improve!
  - Commit only as soon as a whole feature is done, or the game is half-way done, but that's unprofessional and impossible to collaborate with, due to Merge Conflicts, so commit regularly and in small batches. It's better to lose 1 hour worth of work, if you have a huge, unresolvable conflict, than losing 5 days worth of work!
Here's the set of features that I'll be looking for:

| Component | Feature  | Unity Components | Data | Score |
|--------------|-------|------------------|------|-------|
|Camera| Perspective is Top-Down | `Camera`, `Transform` | <ul><li>- [x] </li></ul> | 5 |
|Camera| Follows Player with small Delay | `MonoBehaviour`, `Update`, `Vector3.Lerp` | <ul><li>- [x] </li></ul> | 5 |
|Player| Player can walk forward and backward | `Rigidbody2d`, `Collider`, `Input.GetAxis`, `Rigidbody2d.SetVelocity` | <ul><li>- [x] </li></ul> | 5 |
|Player| Player can rotate left and right | | <ul><li>- [x] </li></ul> | 5 |
|Car| Player can enter Cars | | <ul><li>- [x] </li></ul> | 5 |
|Car| Player can leave Cars | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car can accelerate | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car can brake | Can stop moving? | <ul><li>- [x] </li></ul> | 5 |
|Car| Car can turn | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car can drive in reverse | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car takes damage when colliding with Cars or Walls | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car starts burning when under certain health-threshold | | <ul><li>- [x] </li></ul> | 5 |
|Car| Car explodes when at zero health | | <ul><li>- [x] </li></ul> | 5 |
|Car| Player dies if he is in the car when it explodes | | <ul><li>- [x] </li></ul> | 5 |
|UI| Player's Health can be seen | | <ul><li>- [x] </li></ul> | 5 |
|UI| Player's Money can be seen | | <ul><li>- [X] </li></ul> | 5 |
|UI| Player's Score can be seen | | <ul><li>- [X] </li></ul> | 5 |
|UI| BONUS: Minimap can be seen | | <ul><li>- [x] </li></ul> | 5 |
|Quest| Player can interact with Phonebox to receive quest | | <ul><li>- [x] </li></ul> | 5 |
|Quest| Player cannot interact with Phonebox if already on quest | | <ul><li>- [x] </li></ul> | 5 |
|Quest| Quest yields Money Reward, if completed | | <ul><li>- [x] </li></ul> | 5 |
|Weapon| Player can switch Weapon between Hands, Pistol and Machine Gun | | <ul><li>- [ ] </li></ul> | 5 |
|Weapon| Player can use Weapon to Attack | | <ul><li>- [x] </li></ul> | 5 |
|Weapon| Weapons need to reload | | <ul><li>- [ ] </li></ul> | 5 |
|UI| Player's chosen Weapon can be seen | | <ul><li>- [X] </li></ul> | 5 |
|UI| Player's Weapon's shots until reload can be seen | | <ul><li>- [ ] </li></ul> | 5 |
|Weapon| Attacks can hit cars | | <ul><li>- [x] </li></ul> | 5 |
|Environment| There is houses | | <ul><li>- [x] </li></ul> | 5 |
|Environment| There is streets | | <ul><li>- [x] </li></ul> | 5 |
|Environment| BONUS: Traffic | | <ul><li>- [ ] </li></ul> | 20 |
|Environment| BONUS: Pedestrians | | <ul><li>- [ ] </li></ul> | 20 |
|Fire| Fire exists that deals damage to the player while he is standing in the Fire | | <ul><li>- [x] </li></ul> | 5 |
|Fire| Fires are spawned by exploding cars | | <ul><li>- [x] </li></ul> | 5 |
|Fire| Fires extinguish after a while | | <ul><li>- [x] </li></ul> | 5 |
|Heart| Heart Powerups exist that heal the Player by a certain amount when he collects them | | <ul><li>- [ ] </li></ul> | 5 |
|Water| Water exists that makes the Player drown, if he jumps into it. Resulting in Death. | | <ul><li>- [x] </li></ul> | 5 |
|Death| Text "WASTED" is displayed. Player respawns after a few seconds. He loses half of his money. | | <ul><li>- [x] </li></ul> | 5 |
|SavePoint| SavePoint-Powerups exist that save the Player's Progress, if he is not on a quest right now. When loading, the player's Health and Money is loaded and he spawns at the SavePoint that he touched last. | | <ul><li>- [ ] </li></ul> | 5 |

| | | | | Total: 180 |
------------------------------


Current Score: 155

Current percent: 86.11% 

Current grade: VG - Magna Cum Laude (A) 

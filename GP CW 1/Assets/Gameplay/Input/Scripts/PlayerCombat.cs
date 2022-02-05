using SKhorozian.FPSController.Character;
using SKhorozian.FPSController.Input;

public class PlayerCombat : CharacterCombat
{
    private void Start() {
        InputManager.Instance.OnPrimaryFireInput.AddListener(FireWeaponPrimary);
        InputManager.Instance.OnSecondaryFireInput.AddListener(FireWeaponSecondary);
    }
}


/**
 * Enum keeping track of all buttons, nrButtons is how many registered buttons there is in total (it has to be last!)
 */
public enum Button {
    left, right, up, down, jump, jumpAlt, resetTime, nrButtons
}

/**
 * The controller manager interface, lets players and clones use the "same" functions for input management
 */
public interface IControlManager {
    float Horizontal();
    float Vertical();
    bool JumpButtonDown();
    bool JumpButtonUp();
    bool IsResetButtonUp();
}

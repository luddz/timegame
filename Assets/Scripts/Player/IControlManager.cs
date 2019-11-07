


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

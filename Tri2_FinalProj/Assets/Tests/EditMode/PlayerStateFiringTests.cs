/*
Shreeja Das:

This testing suite consists of unit tests verifying individual behaviors, preventing tests from being brittle (over-dependent on implementation details). Tradeoffs made when choosing to check behavior vs. 
implementation were things like focusing on observable outcomes like state transitions, object instantiation, and log messages rather than method calls, variable updates, or the internal programmatic details. 
This allows tests to be resilient and not brittle tests that could break with minor changes to the code. However, this means we lose out on the ability to check for specific lines of code execution and more specific 
debugging information, striking a balance between test coverage and execution time.

Some strategies used when designing this test suite include equivalence partitioning, such as, when checking that advanceState() works as expected given various cooldown values. I also use Boundary Value Testing to
ensure that transitions happen at expected events like when cooldown = 1 or when cooldown = 0, potentially flagging one-off-errors in the code. Since the PlayerStateFiringTests were based on code that originally takes 
advantage of the State Pattern, we used state transition tests to confirm that events like when space is pressed, the player’s state is correctly changed (ie: ensuring working game logic). We tried to steer clear from too 
many tests of this sort (ie: checking the order of state changes, etc.) to prevent brittle tests that would require a lot of updates for minor refactoring. Lastly, we used Unity-specific tests to check log messages to 
ensure the class behaves as expected functionally and visually. 

Designing this, I learned the importance of balancing specificity and flexibility. While it was a challenge to ensure that tests remain robust while not resisting future refactor, 
I enjoyed working with mocking frameworks like NSubstitute to keep unit tests isolated while maintaining high-ish code coverage.

*/



using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStateFiringTests
{
    private PlayerStateFiring playerStateFiring;
    private PlayerController mockPlayer;
    private Rigidbody2D mockRigidbody;
    private GameObject mockProjectilePrefab;
    private GameObject mockSpeedPrefab;
    private PlayerState mockReturnState;

    [SetUp]
    public void Setup()
    {
        mockPlayer = Substitute.For<PlayerController>();
        mockRigidbody = Substitute.For<Rigidbody2D>();
        mockProjectilePrefab = new GameObject("ProjectilePrefab");
        mockSpeedPrefab = new GameObject("SpeedPrefab");
        mockReturnState = Substitute.For<PlayerState>();
    }

    // Equivalence Partitioning: Valid cooldown values
    [Test]
    public void AdvanceState_DecreasesCooldown()
    {
        int initialCooldown = 3;
        playerStateFiring = new PlayerStateFiring(mockPlayer, mockRigidbody, initialCooldown, mockProjectilePrefab, mockSpeedPrefab, mockReturnState);

        playerStateFiring.advanceState();

        Assert.AreEqual(initialCooldown - 1, playerStateFiring.cooldown);
    }

    // Boundary Value Testing: Cooldown at 1 transitions state
    [Test]
    public void AdvanceState_SwitchesState_AtBoundaryCooldown()
    {
        playerStateFiring = new PlayerStateFiring(mockPlayer, mockRigidbody, 1, mockProjectilePrefab, mockSpeedPrefab, mockReturnState);

        playerStateFiring.advanceState();

        mockPlayer.Received(1).setState(mockReturnState);
    }

    // Boundary Value Testing: Cooldown at 0 should immediately switch state
    [Test]
    public void AdvanceState_ZeroCooldown_ImmediatelyTransitions()
    {
        playerStateFiring = new PlayerStateFiring(mockPlayer, mockRigidbody, 0, mockProjectilePrefab, mockSpeedPrefab, mockReturnState);

        playerStateFiring.advanceState();

        mockPlayer.Received(1).setState(mockReturnState);
    }

    // Edge Case: Negative cooldown should not trigger additional transitions
    [Test]
    public void AdvanceState_DoesNotTransition_MultipleTimesForNegativeCooldown()
    {
        playerStateFiring = new PlayerStateFiring(mockPlayer, mockRigidbody, -1, mockProjectilePrefab, mockSpeedPrefab, mockReturnState);

        playerStateFiring.advanceState();

        mockPlayer.DidNotReceive().setState(mockReturnState);
    }

    // State Transition Testing
    [Test]
    public void HandleSpace_TransitionsToFiringState()
    {
        var fireupState = new PlayerStateFireup(mockPlayer, mockRigidbody, mockProjectilePrefab, mockSpeedPrefab, 3);
        fireupState.handleSpace();

        mockPlayer.Received(1).setState(Arg.Any<PlayerStateFiring>());
    }

    [UnityTest]
    public IEnumerator HandleSpace_InstantiatesSpeedPrefab()
    {
        var fireupState = new PlayerStateFireup(mockPlayer, mockRigidbody, mockProjectilePrefab, mockSpeedPrefab, 3);

        fireupState.handleSpace();

        yield return new WaitForSeconds(0.1f);

        var instantiatedObject = GameObject.Find("SpeedPrefab");
        Assert.IsNotNull(instantiatedObject);
    }

    [UnityTest]
    public IEnumerator HandleSpace_LogsMessageInPlayMode()
    {
        var fireupState = new PlayerStateFireup(mockPlayer, mockRigidbody, mockProjectilePrefab, mockSpeedPrefab, 3);

        LogAssert.Expect(LogType.Log, "hit");

        fireupState.handleSpace();

        yield return null;
    }
}

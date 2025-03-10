/*
Julia Thompson:

The unit tests use several different mocks for the parameters taken in by the PlayerController to handle dependencies on other classes, such as the movement commands and player states. In order to test these, 
I just confirmed that the correct state changes or command calls were made. In order to ensure the tests were not brittle, I made sure to focus on each method's intended outcome instead of individual implementation 
details. This meant we could not test specific details of each method, but this will overall be better for refactoring later. I focused on equivalence class partioning, making sure that functions recieved the 
different kinds of inputs they were expected to handle. For example, I tested the update method with different states to make sure they would all handle a space input properly and I tested different kinds of 
arrow keys with the update method to make sure they would stop or move the player as expected.

While some of the object patterns implemented increased the complexity of the code in certain ways, they did help to decrease much of the tight coupling and dependencies that could have further complicated the testing process. 
We had to find the right balance between simplicity, refactorability, and testability in our implementations.

Overall, it was a bit challenging writing tests for methods that did not take in many parameters, but I was able to determine what values affected the functionality of different methods. I also had some issues working with 
Monobehaviors. It was good to get used to NUnit and NSubstitution again, but did take some time to set up, create mocks, and figure out testing in the context of a game.
 */



using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private PlayerController playerController;
    private ICommand mockMoveRightCommand;
    private ICommand mockMoveLeftCommand;
    private ICommand mockStopMovementCommand;
    private ICommand mockShootCommand;
    private ICommand mockPowerShootCommand;
    private PlayerState mockNormalState;
    private PlayerState fireUpState;

    private GameObject fireUpObject;

    [SetUp]
    public void Setup()
    {
        playerController = new GameObject().AddComponent<PlayerController>();

        mockMoveRightCommand = Substitute.For<ICommand>();
        mockMoveLeftCommand = Substitute.For<ICommand>();
        mockStopMovementCommand = Substitute.For<ICommand>();
        mockShootCommand = Substitute.For<ICommand>();
        mockPowerShootCommand = Substitute.For<ICommand>();
        mockNormalState = Substitute.For<PlayerStateNormal>(playerController, playerController.rb, playerController.projectilePrefab, playerController.speedPrefab);
        fireUpState = Substitute.For<PlayerStateNormal>(playerController, playerController.rb, playerController.projectilePrefab, playerController.speedPrefab, 500);
        
        playerController.moveRightCommand = mockMoveRightCommand;
        playerController.moveLeftCommand = mockMoveLeftCommand;
        playerController.stopMovementCommand = mockStopMovementCommand;
        playerController.shootCommand = mockShootCommand;
        playerController.powerShootCommand = mockPowerShootCommand;
        playerController.state = mockNormalState;

        fireUpObject = new GameObject();
        fireUpObject.tag = "FireUp";
        fireUpObject.AddComponent<BoxCollider2D>();
    }

    [Test]
    public void ChangeVelocity_ChangeTo10()
    {
        playerController.velocity = 4;

        playerController.changeVelocity();

        Assert.AreEqual(playerController.velocity, 10);
    }

    [Test]
    public void ChangeVelocity_ChangeTo4()
    {
        playerController.velocity = 10;

        playerController.changeVelocity();

        Assert.AreEqual(playerController.velocity, 4);
    }

    [Test]
    public void SetState_BecomeFireUp()
    {
        playerController.state = mockNormalState;

        playerController.setState(fireUpState);

        Assert.AreEqual(fireUpState, playerController.state);
    }

    [Test]
    public void OnTriggerEnter_SetStateFireUp()
    {
        playerController.state = mockNormalState;
        
        playerController.OnTriggerEnter2D(fireUpObject);

        Assert.AreEqual(fireUpState, playerController.state);
    }

    [Test]
    public void Update_MoveRightOnRightArrow()
    {
        Input.GetKeyDown(KeyCode.RightArrow);

        playerController.Update();

        mockMoveRightCommand.Recieved().Execute();
    }

    [Test]
    public void Update_MoveLeftOnLeftArrow()
    {
        Input.GetKeyDown(KeyCode.LeftArrow);

        playerController.Update();

        mockMoveLeftCommand.Recieved().Execute();
    }

    [Test]
    public void Update_StopMovingOnLeftArrowUp()
    {
        Input.GetKeyUp(KeyCode.LeftArrow);

        playerController.Update();

        mockStopMovementCommand.Recieved().Execute();
    }

    [Test]
    public void Update_StopMovingOnRightArrowUp()
    {
        Input.GetKeyUp(KeyCode.RightArrow);

        playerController.Update();

        mockStopMovementCommand.Recieved().Execute();
    }

    [Test]
    public void Update_FireOnSpace()
    {
        playerController.state = mockNormalState;
        Input.GetKeyDown(KeyCode.Space);

        playerController.Update();

        mockShootCommand.Recieved().Execute();
    }

    [Test]
    public void Update_FireUpgradedOnSpace()
    {
        playerController.state = fireUpState;
        Input.GetKeyDown(KeyCode.Space);

        mockPowerShootCommand.Recieved().Execute();
    }

}

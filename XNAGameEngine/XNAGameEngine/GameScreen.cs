using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace XNAGameEngine
{
    // This describes the screen transition state
    public enum ScreenState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden
    }

    public abstract class GameScreen
    {
        #region Variables
        bool popUp = false;
        TimeSpan transitionOnTime = TimeSpan.Zero;
        TimeSpan transitionOffTime = TimeSpan.Zero;
        float transitionPosition = 1;
        ScreenState screenState =  ScreenState.TransitionOn;
        bool isExiting = false;
        bool newScreenHasFocus;
        GameStateManager gameStateManager;
        PlayerIndex? currentPlayer;   
        #endregion

        #region Properties

        // This is for if we have anything just popup like a menu or something so that
        // instead of the current game screen transitioning off it will just remain 
        // below it
        public bool PopUp
        {
            get { return popUp; }
            protected set { popUp = value; }
        }

        // This tells us how long it takes for it to transition on when activated
        public TimeSpan TransitionOnTime
        {
            get { return transitionOnTime; }
            protected set { transitionOnTime = value; }
        }

        // This tells us how long it takes for it to transition off when activated
        public TimeSpan TransitionOffTime
        {
            get { return transitionOffTime; }
            protected set { transitionOffTime = value; }
        }

        // Gets the current position of the screen transition, ranging
        // from zero (fully active, no transition) to one (transitioned
        // fully off to nothing)
        public float TransitionPosition
        {
            get { return transitionPosition; }
            protected set { transitionPosition = value; }
        }

        // Gets the current alpha of the screen transition, ranging
        // from 1 (fully active, no transition) to 0 (transitioned
        // fully off to nothing)
        public float TransitionAlpha
        {
            get { return 1f - TransitionPosition; }
        }

        // This gets the current transition state
        public ScreenState ScreenState
        {
            get { return screenState; }
            protected set { screenState = value; }
        }

        // This is so the screen automatically removes itself once transition finishes
        public bool IsExiting
        {
            get { return isExiting; }
            protected internal set { isExiting = value; }
        }

        // This checks if the screen is active so i can respond to user input
        public bool IsActive
        {
            get
            {
                return !newScreenHasFocus && (screenState == ScreenState.TransitionOn 
                    || screenState == ScreenState.Active);
            }
        }

        // This gets the manager that this screen belongs to
        public GameStateManager GameStateManager
        {
            get { return gameStateManager; }
            internal set { gameStateManager = value; }
        }

        // Im not sure if we really need this its more if we have multiple players but
        // ill keep it in just in case
        public PlayerIndex? CurrentPlayer
        {
            get { return currentPlayer; }
            internal set { currentPlayer = value; }
        }
        #endregion

        public virtual void LoadContent()
        {
            
        }
        public virtual void UnloadContent()
        {
            
        }
        public virtual void Update()
        {
           
        }
        public virtual void Draw()
        {

        }

    }
}
